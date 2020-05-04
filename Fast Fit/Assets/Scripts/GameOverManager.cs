using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private NumberWriter numberWriter = null;
    [SerializeField] private AdManager adManager = null;    
    [SerializeField] private AchievementManager achievementManager = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI topScoreText = null;
    [SerializeField] private TextMeshProUGUI newBestScoreText = null;
    [SerializeField] private TextMeshProUGUI fitsText = null;
    [SerializeField] private TextMeshProUGUI topFitsText = null;
    [SerializeField] private TextMeshProUGUI newBestFitsText = null;
    [SerializeField] private TextMeshProUGUI timeText = null;
    [SerializeField] private TextMeshProUGUI topTimeText = null;
    [SerializeField] private TextMeshProUGUI newBestTimeText = null;
    [SerializeField] private TextMeshProUGUI streakText = null;
    [SerializeField] private TextMeshProUGUI topStreakText = null;
    [SerializeField] private TextMeshProUGUI newBestStreakText = null;
    [SerializeField] private int adAttempts = 5;

    private AudioSource audioSource;

    private bool finishedUpdate = true;

    private IEnumerator coroutine;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        coroutine = UpdateGameOverUI();
        StartCoroutine(coroutine);

        achievementManager.UpdateAchievements();
    }

    private void Update()
    {
        if (! finishedUpdate)
        {
            #if UNITY_EDITOR
                if (Input.GetMouseButtonUp(0))
                {
                    finishedUpdate = true;
                    StopCoroutine(coroutine);
                    numberWriter.Stop();
                    ShowGameOverUIData();
                    audioSource.Stop();
                }
            #endif

            #if UNITY_ANDROID || UNITY_IOS
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    switch (touch.phase)
                    {
                        case TouchPhase.Ended:
                        case TouchPhase.Canceled:
                            finishedUpdate = true;
                            StopCoroutine(coroutine);
                            numberWriter.Stop();
                            ShowGameOverUIData();
                            audioSource.Stop();
                            break;
                    }   
                }
            #endif
        }
    }

    private void ShowGameOverUIData()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(PlayerPrefManager.GetLastTime());
        timeText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        TimeSpan topTimeSpan = TimeSpan.FromSeconds(PlayerPrefManager.GetTopTime());
        topTimeText.text = Texts.Record + " " + string.Format("{0:D2}:{1:D2}", topTimeSpan.Minutes, topTimeSpan.Seconds);

        scoreText.text = PlayerPrefManager.GetLastScore().ToString();
        topScoreText.text = Texts.Record + " " + PlayerPrefManager.GetTopScore().ToString();
        fitsText.text = PlayerPrefManager.GetLastFits().ToString();
        topFitsText.text = Texts.Record + " " + PlayerPrefManager.GetTopFits().ToString();
        streakText.text = PlayerPrefManager.GetLastStreak().ToString();
        topStreakText.text = Texts.Record + " " + PlayerPrefManager.GetTopStreak().ToString();

        ShowTopTime(10);
        ShowTopScore(10);
        ShowTopFits(10);
        ShowTopStreak(10);
    }

    private IEnumerator UpdateGameOverUI()
    {
        finishedUpdate = false;
        audioSource.Play();

        UpdateTime();

        while (! numberWriter.IsReady())
            yield return null;
            
        ShowTopTime();
        UpdateScore();

        while (! numberWriter.IsReady())
            yield return null;
            
        ShowTopScore();
        UpdateFits();

        while (! numberWriter.IsReady())
            yield return null;

        ShowTopFits();
        UpdateStreak();

        while (! numberWriter.IsReady())
            yield return null;
        
        ShowTopStreak();
        audioSource.Stop();
        finishedUpdate = true;
    }

    private void ShowTopTime(int speed = 1)
    {
        if (PlayerPrefManager.GetLastTime() < PlayerPrefManager.GetTopTime())
        {
            topTimeText.GetComponent<Animator>().SetFloat("Speed", speed);
            topTimeText.GetComponent<Animator>().Play("TopTimeShow");
            return;
        }

        newBestTimeText.GetComponent<Animator>().SetFloat("Speed", speed);
        newBestTimeText.GetComponent<Animator>().Play("NewBestTimeShow");
    }

    private void ShowTopScore(int speed = 1)
    {
        if (PlayerPrefManager.GetLastScore() < PlayerPrefManager.GetTopScore())
        {
            topScoreText.GetComponent<Animator>().SetFloat("Speed", speed);
            topScoreText.GetComponent<Animator>().Play("TopScoreShow");
            return;
        }

        newBestScoreText.GetComponent<Animator>().SetFloat("Speed", speed);
        newBestScoreText.GetComponent<Animator>().Play("NewBestScoreShow");

        PlayGamesController.PostToHighScoreLeaderboard(PlayerPrefManager.GetTopScore());
    }

    private void ShowTopFits(int speed = 1)
    {
        if (PlayerPrefManager.GetLastFits() < PlayerPrefManager.GetTopFits())
        {
            topFitsText.GetComponent<Animator>().SetFloat("Speed", speed);
            topFitsText.GetComponent<Animator>().Play("TopFitsShow");
            return;
        }

        newBestFitsText.GetComponent<Animator>().SetFloat("Speed", speed);
        newBestFitsText.GetComponent<Animator>().Play("NewBestFitsShow");
    }

    private void ShowTopStreak(int speed = 1)
    {
        if (PlayerPrefManager.GetLastStreak() < PlayerPrefManager.GetTopStreak())
        {
            topStreakText.GetComponent<Animator>().SetFloat("Speed", speed);
            topStreakText.GetComponent<Animator>().Play("TopStreakShow");
            return;
        }

        newBestStreakText.GetComponent<Animator>().SetFloat("Speed", speed);
        newBestStreakText.GetComponent<Animator>().Play("NewBestStreakShow");
    }

    private void UpdateTime()
    {
        numberWriter.WriteTime(timeText, PlayerPrefManager.GetLastTime(), 0.01f);

        TimeSpan topTimeSpan = TimeSpan.FromSeconds(PlayerPrefManager.GetTopTime());
        string topTime = string.Format("{0:D2}:{1:D2}", topTimeSpan.Minutes, topTimeSpan.Seconds);
        topTimeText.text = Texts.Record + " " + topTime;
    }

    private void UpdateScore()
    {
        numberWriter.WriteInt(scoreText, PlayerPrefManager.GetLastScore(), 0.01f);
    
        string topScore = PlayerPrefManager.GetTopScore().ToString();
        topScoreText.text = Texts.Record + " " + topScore;
    }

    private void UpdateFits()
    {
        numberWriter.WriteInt(fitsText, PlayerPrefManager.GetLastFits(), 0.01f);
        
        string topFits = PlayerPrefManager.GetTopFits().ToString();
        topFitsText.text = Texts.Record + " " + topFits;
    }

    private void UpdateStreak()
    {
        numberWriter.WriteInt(streakText, PlayerPrefManager.GetLastStreak(), 0.01f);
        
        string topStreak = PlayerPrefManager.GetTopStreak().ToString();
        topStreakText.text = Texts.Record + " " + topStreak;
    }

    public void TryAgain()
    {
        StartCoroutine(TryAgainRoutine());
    }

    private IEnumerator TryAgainRoutine()
    {
        audioSource.Stop();

        int attempts = PlayerPrefManager.GetAttempts();
        if (attempts % adAttempts == 0)
            adManager.ShowNonRewardedAd();

        while (adManager.isAdPlaying) yield return null;
        
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
