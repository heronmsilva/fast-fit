using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private NumberWriter numberWriter = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI topScoreText = null;
    [SerializeField] private TextMeshProUGUI newBestScoreText = null;
    [SerializeField] private TextMeshProUGUI crossesText = null;
    [SerializeField] private TextMeshProUGUI topCrossesText = null;
    [SerializeField] private TextMeshProUGUI newBestCrossesText = null;
    [SerializeField] private TextMeshProUGUI timeText = null;
    [SerializeField] private TextMeshProUGUI topTimeText = null;
    [SerializeField] private TextMeshProUGUI newBestTimeText = null;
    [SerializeField] private TextMeshProUGUI streakText = null;
    [SerializeField] private TextMeshProUGUI topStreakText = null;
    [SerializeField] private TextMeshProUGUI newBestStreakText = null;
    [SerializeField] private int adAttempts = 5;

    private AdManager adManager;
    private AudioSource audioSource;

    private void Awake()
    {
        adManager = GetComponent<AdManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(UpdateGameOverUI());
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
        UpdateCrosses();

        while (! numberWriter.IsReady())
            yield return null;

        ShowTopCrosses();
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
    }

    private void ShowTopCrosses()
    {
        if (PlayerPrefManager.GetLastCrosses() < PlayerPrefManager.GetTopCrosses())
        {
            topCrossesText.GetComponent<Animator>().Play("TopFitsShow");
            return;
        }

        newBestCrossesText.GetComponent<Animator>().Play("NewBestFitsShow");
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
        topTimeText.text = "Your Best " + topTime;
    }

    private void UpdateScore()
    {
        numberWriter.WriteInt(scoreText, PlayerPrefManager.GetLastScore(), 0.01f);
    
        string topScore = PlayerPrefManager.GetTopScore().ToString();
        topScoreText.text = "Your Best " + topScore;
    }

    private void UpdateCrosses()
    {
        numberWriter.WriteInt(crossesText, PlayerPrefManager.GetLastCrosses(), 0.01f);
        
        string topCrosses = PlayerPrefManager.GetTopCrosses().ToString();
        topCrossesText.text = "Your Best " + topCrosses;
    }

    private void UpdateStreak()
    {
        numberWriter.WriteInt(streakText, PlayerPrefManager.GetLastStreak(), 0.01f);
        
        string topStreak = PlayerPrefManager.GetTopStreak().ToString();
        topStreakText.text = "Your Best " + topStreak;
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
