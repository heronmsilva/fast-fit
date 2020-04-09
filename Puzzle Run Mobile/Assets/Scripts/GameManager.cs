using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float wallDistance = 40;
    [SerializeField] private float startSpeed = 5;
    [SerializeField] private float speedIncreaseDelta = 0.1f;
    [SerializeField] private float pitchIncreaseDelta = 0.001f;
    [SerializeField] private int maxCrossSequence = 10;
    [SerializeField] private int startLives = 1;
    [SerializeField] private int maxLives = 5;
    [SerializeField] private int speedUpScale = 25;
    [SerializeField] private Difficulty startDifficulty = Difficulty.Level0;
    [SerializeField] private GameObject gameOverScreen = null;
    [SerializeField] private TouchDetector touchDetector = null;

    private static GameManager instance;
    private Spawner spawner;
    private UIHandler UIHandler;
    private AnimationBuffer animBuffer;
    private AudioHandler audioHandler;
    private Difficulty currDifficulty;
    private float speed, startTime;
    private int lives;
    private int score = 0;
    private int crossSequence = 0;
    private bool gameOver = false;

    public static GameManager Instance { get { return instance; } }
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
    public float FastForwardedTime { get { return touchDetector.TotalFastForward; } }
    public int Score { get { return score; } }
    public int CrossSequence { get { return crossSequence; } }
    public int MaxCrossSequence { get { return maxCrossSequence; } }
    public int Lives { get { return lives; } }
    public int MaxLives { get { return maxLives; } }
    public int SpeedUpScale { get { return speedUpScale; } }
    public Vector2 MinXY { get { return spawner.MinXY; } }
    public Vector2 MaxXY { get { return spawner.MaxXY; } }
    public Difficulty CurrDifficulty { get { return currDifficulty; } }
    public GameObject Piece { get { return spawner.Piece; } }
    public bool IsGameOver { get { return gameOver; } }

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
        touchDetector = touchDetector.GetComponent<TouchDetector>();
    }

    private void Start()
    {
        speed = startSpeed;
        lives = startLives;
        currDifficulty = startDifficulty;
        startTime = Time.time;

        animBuffer.ResetQueue();
    }

    private void Update()
    {
        if (! spawner.Wall) // First spawn
        {
            spawner.SpawnObjects();
            UIHandler.UpdateUIHeader();
        }

        if (spawner.Wall.GetComponent<MoveTo>().IsConcluded && ! spawner.IsRespawning)
        {
            StopFastForward();
            speed += speedIncreaseDelta;
            audioHandler.IncreaseBackgroundPitch(pitchIncreaseDelta);
            crossSequence += 1;
            if (crossSequence == maxCrossSequence)
            {
                crossSequence = 0;
                IncreaseDifficulty();
                IncreaseLives();
                UIHandler.PlayLevelUpAnimation();
            }
            ScorePoints();
            UIHandler.PlayCrossAnimation();
            StartCoroutine(spawner.DelayedRespawn(0.5f));
            StartCoroutine(audioHandler.PlayWallCross(0.25f));
        }
        UIHandler.UpdateUIHeader();
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
                gameOverScreen.SetActive(true);
                UpdatePlayerPrefs();
                UIHandler.UpdateGameOverUI();
            }
        }
    }

    public void GameOver()
    {
        // Since several collisions might be triggering gameover
        // it has to be checked if it has already been triggered
        if (! gameOver)
        {
            audioHandler.PlayWallBump();
            gameOver = true;
            Time.timeScale = 0;
        }
    }

    // The animations should be delayed by 1/4
    // of the total time that the wall takes to
    // get to the destination
    public float GetAnimationDelay()
    {
        return (wallDistance / speed) / 4;
    }
    
    // The animations should take 1/4
    // of the total time that the wall takes to
    // get to the destination
    public float GetAnimationSpeed()
    {
        return 1 / ((wallDistance / speed) / 4);
    }

    private void StopFastForward()
    {
        if (gameOver) return;
        
        touchDetector.StopFastForward();
    }

    private void UpdatePlayerPrefs()
    {
        PlayerPrefManager.SetLastScore(score);

        if (score > PlayerPrefManager.GetTopScore())
            PlayerPrefManager.SetTopScore(score);
    }

    private void UseLife()
    {
        lives -= 1;
        crossSequence = 0;
        animBuffer.ResetQueue();
        spawner.RespawnObjects();
        gameOver = false;
        Time.timeScale = 1;
        StopFastForward();
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
        int points = (int) ((Time.time - startTime) * speed * ((int) currDifficulty + 1));
        spawner.ShowScoredPoints(points);
        score += points;
    }
}
