using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float wallDistance = 40;
    [SerializeField] private float startSpeed = 5;
    [SerializeField] private float speedIncreaseDelta = 0.1f;
    [SerializeField] private float pitchIncreaseDelta = 0.001f;
    [SerializeField] private int maxCrossSequence = 10;
    [SerializeField] private int startLives = 1;
    [SerializeField] private int maxLives = 5;
    [SerializeField] private int maxSpeed = 25;
    [SerializeField] private Difficulty startDifficulty = Difficulty.Level0;
    [SerializeField] private GameObject touchControls = null;

    private static GameManager instance;
    private static List<string> controls = new List<string> { "FLOATING", "FIXED", "TOUCH" };
    private Spawner spawner;
    private UIHandler UIHandler;
    private AnimationBuffer animBuffer;
    private AudioHandler audioHandler;
    private Difficulty currDifficulty;
    private float speed, startTime;
    private int lives;
    private int score = 0;
    private int crosses = 0;
    private int crossSequence = 0;
    private int crossStreak = 0;
    private int bestCrossStreak = 0;
    private bool fastForward = false;
    private bool gameOver = false;
    private bool paused = false;
    private bool countDown = false;

    public static GameManager Instance { get { return instance; } }
    public static List<string> Controls { get { return controls; } }
    public enum Difficulty 
    {
        Level0,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }

    public float WallDistance { get { return wallDistance; } }
    public float Speed { get { return speed; } }
    public int Score { get { return score; } }
    public int Crosses { get { return crosses; } }
    public int CrossSequence { get { return crossSequence; } }
    public int MaxCrossSequence { get { return maxCrossSequence; } }
    public int Lives { get { return lives; } }
    public int MaxLives { get { return maxLives; } }
    public Vector2 MinXY { get { return spawner.MinXY; } }
    public Vector2 MaxXY { get { return spawner.MaxXY; } }
    public Difficulty CurrDifficulty { get { return currDifficulty; } }
    public GameObject Piece { get { return spawner.Piece; } }
    public bool IsGameOver { get { return gameOver; } }
    public bool IsPaused { get { return paused; } }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        spawner = GetComponent<Spawner>();
        UIHandler = GetComponent<UIHandler>();
        animBuffer = GetComponent<AnimationBuffer>();
        audioHandler = GetComponent<AudioHandler>();
    }

    private void Start()
    {
        speed = startSpeed;
        lives = startLives;
        currDifficulty = startDifficulty;
        audioHandler.StopBackgroundSound();

        SetupCamera();
        animBuffer.ResetQueue();

        StartCoroutine(CountDown());

        int attempts = PlayerPrefManager.GetAttempts() + 1;
        PlayerPrefManager.SetAttempts(attempts);
    }

    private void Update()
    {
        if (countDown) return;
        if (! spawner.Wall) spawner.SpawnObjects();
        CheckWallCross();
        UIHandler.UpdateUIHeader();
    }

    private void SetupCamera()
    {
        float fov = Camera.main.fieldOfView;
        float adaptedFov = GetCameraAspect() * fov / GetDefaultAspect();
        Camera.main.fieldOfView = adaptedFov;
    }

    public float GetCameraAspect()
    {
        return Mathf.Round(100f / Camera.main.aspect) / 100f;
    }

    private float GetDefaultAspect()
    {
        return Mathf.Round(100f * 16 / 9) / 100f;
    }

    private IEnumerator CountDown()
    {
        countDown = true;
        spawner.SpawnCountDown();

        yield return new WaitForSeconds(3f);

        audioHandler.PlayBackgroundSound();
        startTime = Time.time;
        countDown = false;
    }

    private void CheckWallCross()
    {
        if (spawner.Wall.GetComponent<MoveTo>().IsConcluded && !spawner.IsRespawning && !gameOver)
        {
            speed += speedIncreaseDelta;
            audioHandler.IncreaseBackgroundPitch(pitchIncreaseDelta);
            crosses += 1;
            crossSequence += 1;
            crossStreak += 1;
            bestCrossStreak = (crossStreak > bestCrossStreak) ? crossStreak : bestCrossStreak;
            if (crossSequence == maxCrossSequence)
            {
                crossSequence = 0;
                IncreaseDifficulty();
                IncreaseLives();
                UIHandler.PlayLevelUpAnimation();
                StartCoroutine(audioHandler.PlayLevelUp(0.25f));
            }
            else
            {
                StartCoroutine(audioHandler.PlayWallCross(0.25f));
            }
            ScorePoints();
            fastForward = false;
            StartCoroutine(spawner.DelayedRespawn(0.5f));
        }
    }

    private void LateUpdate()
    {
        if (gameOver)
        {
            if (lives > 0)
            {
                UseLife();
            }
            else
            {
                audioHandler.StopBackgroundSound();
                audioHandler.PlayGameOver();
                UpdatePlayerPrefs();
                touchControls.SetActive(false);
                gameOver = false;
                LoadGameOver();
            }
        }
    }

    private void LoadGameOver()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game Over");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        paused = true;
        audioHandler.PauseBackgroundSound();
        UIHandler.Pause();
        touchControls.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        paused = false;
        audioHandler.ResumeBackgroundSound();
        UIHandler.Resume();
        touchControls.SetActive(true);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void GameOver()
    {
        // Since several collisions might be triggering gameover
        // it has to be checked if it has already been triggered
        if (! gameOver)
        {
            gameOver = true;
            Time.timeScale = 0;
        }
    }
    
    // The animations should take 1/4
    // of the total time that the wall takes to
    // get to the destination
    public float GetAnimationSpeed()
    {
        return 1 / (wallDistance / speed);
    }

    public void FastForward()
    {
        fastForward = true;

        spawner.Wall.GetComponent<MoveTo>().SetSpeed(maxSpeed);
        spawner.Wall.GetComponent<WallAnimations>().IncreaseAnimSpeed(1 / (wallDistance / maxSpeed));
    }

    private void UpdatePlayerPrefs()
    {
        PlayerPrefManager.SetLastScore(score);
        if (score > PlayerPrefManager.GetTopScore())
            PlayerPrefManager.SetTopScore(score);

        float totalTime = Time.time - startTime;
        PlayerPrefManager.SetLastTime(totalTime);
        if (totalTime > PlayerPrefManager.GetTopTime())
            PlayerPrefManager.SetTopTime(totalTime);

        PlayerPrefManager.SetLastCrosses(crosses);
        if (crosses > PlayerPrefManager.GetTopCrosses())
            PlayerPrefManager.SetTopCrosses(crosses);
        
        PlayerPrefManager.SetLastStreak(bestCrossStreak);
        if (bestCrossStreak > PlayerPrefManager.GetTopStreak())
            PlayerPrefManager.SetTopStreak(bestCrossStreak);
    }

    private void UseLife()
    {
        audioHandler.PlayRestart();
        lives -= 1;
        crossSequence = 0;
        crossStreak = 0;
        animBuffer.ResetQueue();
        spawner.RespawnObjects();
        gameOver = false;
        Time.timeScale = 1;
    }

    private void IncreaseDifficulty()
    {
        if (currDifficulty == Difficulty.Level5) return;
        
        currDifficulty = (Difficulty) ((int) currDifficulty + 1);
    }

    private void IncreaseLives()
    {
        lives += (lives < maxLives) ? 1 : 0;
    }

    private void ScorePoints()
    {
        int difficultyMultiplier = (int) currDifficulty + 1;
        int fastForwardMultiplier = (fastForward) ? 2 : 1;
        int crossMultiplier = (int) (crossStreak / 10) + 1;
        int points = (int) (crosses * speed * crossMultiplier * difficultyMultiplier * fastForwardMultiplier);
        spawner.ShowScoredPoints(points);
        score += points;
    }
}
