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

    private AdManager adManager;

    private void Awake()
    {
        adManager = GetComponent<AdManager>();
    }

    private void Start()
    {
        UpdateGameOverUI();

        StartCoroutine(adManager.ShowBannerAd());
    }

    private void UpdateGameOverUI()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(PlayerPrefManager.GetLastTime());
        string time = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        TimeSpan topTimeSpan = TimeSpan.FromSeconds(PlayerPrefManager.GetTopTime());
        string topTime = string.Format("{0:D2}:{1:D2}", topTimeSpan.Minutes, topTimeSpan.Seconds);

        scoreText.text = PlayerPrefManager.GetLastScore().ToString();
        topScoreText.text = "(" + PlayerPrefManager.GetTopScore().ToString() + ")";
        crossesText.text = PlayerPrefManager.GetLastCrosses().ToString();
        topCrossesText.text = "(" + PlayerPrefManager.GetTopCrosses().ToString() + ")";
        streakText.text = PlayerPrefManager.GetLastStreak().ToString();
        topStreakText.text = "(" + PlayerPrefManager.GetTopStreak().ToString() + ")";
        timeText.text = time;
        topTimeText.text = "(" + topTime + ")";
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
