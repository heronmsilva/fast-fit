using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private NumberWriter numberWriter = null;
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
        int attempts = PlayerPrefManager.GetAttempts();
        if (attempts % adAttempts == 0)
            adManager.ShowNonRewardedAd();

        StartCoroutine(UpdateGameOverUI());
    }

    private IEnumerator UpdateGameOverUI()
    {
        while (adManager.isAdPlaying) yield return null;

        UpdateTime();

        while (! numberWriter.IsReady())
            yield return null;

        UpdateScore();

        while (! numberWriter.IsReady())
            yield return null;

        UpdateCrosses();

        while (! numberWriter.IsReady())
            yield return null;

        UpdateStreak();
    }

    private void UpdateTime()
    {
        numberWriter.Write(timeText, PlayerPrefManager.GetLastTime(), 1f, true);

        TimeSpan topTimeSpan = TimeSpan.FromSeconds(PlayerPrefManager.GetTopTime());
        topTimeText.text = string.Format("{0:D2}:{1:D2}", topTimeSpan.Minutes, topTimeSpan.Seconds);
    }

    private void UpdateScore()
    {
        numberWriter.Write(scoreText, PlayerPrefManager.GetLastScore(), 1f);
    
        topScoreText.text = PlayerPrefManager.GetTopScore().ToString();
    }

    private void UpdateCrosses()
    {
        numberWriter.Write(crossesText, PlayerPrefManager.GetLastCrosses(), 1f);
        
        topCrossesText.text = PlayerPrefManager.GetTopCrosses().ToString();
    }

    private void UpdateStreak()
    {
        numberWriter.Write(streakText, PlayerPrefManager.GetLastStreak(), 1f);
        
        topStreakText.text = PlayerPrefManager.GetTopStreak().ToString();
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
