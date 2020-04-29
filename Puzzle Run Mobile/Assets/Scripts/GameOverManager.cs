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
    [SerializeField] private TextMeshProUGUI crossesText = null;
    [SerializeField] private TextMeshProUGUI topCrossesText = null;
    [SerializeField] private TextMeshProUGUI timeText = null;
    [SerializeField] private TextMeshProUGUI topTimeText = null;
    [SerializeField] private TextMeshProUGUI streakText = null;
    [SerializeField] private TextMeshProUGUI topStreakText = null;
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
        int attempts = PlayerPrefManager.GetAttempts();
        if (attempts % adAttempts == 0)
            adManager.ShowNonRewardedAd();

        StartCoroutine(UpdateGameOverUI());
    }

    private IEnumerator UpdateGameOverUI()
    {
        while (adManager.isAdPlaying) yield return null;
        
        audioSource.Play();

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

        while (! numberWriter.IsReady())
            yield return null;
        
        audioSource.Stop();
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
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
