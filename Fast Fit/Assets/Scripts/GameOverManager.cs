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

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(UpdateGameOverUI());

        achievementManager.UpdateAchievements();
    }

    private IEnumerator UpdateGameOverUI()
    {
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
    }

    private void ShowTopTime()
    {
        if (PlayerPrefManager.GetLastTime() < PlayerPrefManager.GetTopTime())
        {
            topTimeText.GetComponent<Animator>().Play("TopTimeShow");
            return;
        }

        newBestTimeText.GetComponent<Animator>().Play("NewBestTimeShow");
    }

    private void ShowTopScore()
    {
        if (PlayerPrefManager.GetLastScore() < PlayerPrefManager.GetTopScore())
        {
            topScoreText.GetComponent<Animator>().Play("TopScoreShow");
            return;
        }

        newBestScoreText.GetComponent<Animator>().Play("NewBestScoreShow");

        PlayGamesController.PostToHighScoreLeaderboard(PlayerPrefManager.GetTopScore());
    }

    private void ShowTopFits()
    {
        if (PlayerPrefManager.GetLastFits() < PlayerPrefManager.GetTopFits())
        {
            topFitsText.GetComponent<Animator>().Play("TopFitsShow");
            return;
        }

        newBestFitsText.GetComponent<Animator>().Play("NewBestFitsShow");
    }

    private void ShowTopStreak()
    {
        if (PlayerPrefManager.GetLastStreak() < PlayerPrefManager.GetTopStreak())
        {
            topStreakText.GetComponent<Animator>().Play("TopStreakShow");
            return;
        }

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
