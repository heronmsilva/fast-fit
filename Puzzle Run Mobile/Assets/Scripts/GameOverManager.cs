using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text topScoreText = null;
    [SerializeField] private Text crossesText = null;
    [SerializeField] private Text topCrossesText = null;
    [SerializeField] private Text timeText = null;
    [SerializeField] private Text topTimeText = null;
    [SerializeField] private Text streakText = null;
    [SerializeField] private Text topStreakText = null;
    [SerializeField] private int adAttempts = 5;

    private AdManager adManager;

    private void Awake()
    {
        adManager = GetComponent<AdManager>();
    }

    private void Start()
    {
        // StartCoroutine(adManager.ShowBannerAd());

        int attempts = PlayerPrefManager.GetAttempts();
        if (attempts % adAttempts == 0)
            adManager.ShowNonRewardedAd();
    }

    private void Update()
    {
        UpdateGameOverUI();
    }

    private void UpdateGameOverUI()
    {
        UpdateTime();
        UpdateScore();
        UpdateCrosses();
        UpdateStreak();
    }

    private void UpdateTime()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(PlayerPrefManager.GetLastTime());
        string time = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        TimeSpan topTimeSpan = TimeSpan.FromSeconds(PlayerPrefManager.GetTopTime());
        string topTime = string.Format("{0:D2}:{1:D2}", topTimeSpan.Minutes, topTimeSpan.Seconds);
        
        timeText.text = time;
        topTimeText.text = "(" + topTime + ")";
    }

    private void UpdateScore()
    {
        scoreText.text = PlayerPrefManager.GetLastScore().ToString();
        topScoreText.text = "(" + PlayerPrefManager.GetTopScore().ToString() + ")";
    }

    private void UpdateCrosses()
    {
        crossesText.text = PlayerPrefManager.GetLastCrosses().ToString();
        topCrossesText.text = "(" + PlayerPrefManager.GetTopCrosses().ToString() + ")";
    }

    private void UpdateStreak()
    {
        streakText.text = PlayerPrefManager.GetLastStreak().ToString();
        topStreakText.text = "(" + PlayerPrefManager.GetTopStreak().ToString() + ")";
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
