using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Text timeText = null;
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text topScoreText = null;
    [SerializeField] private Text crossesText = null;
    [SerializeField] private Text topCrossesText = null;

    private void Start()
    {
        UpdateGameOverUI();
    }

    private void UpdateGameOverUI()
    {
        TimeSpan time = TimeSpan.FromSeconds(PlayerPrefManager.GetLastTime());
        string formatedTime = string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
        timeText.text = "TIME\n" + formatedTime;
        scoreText.text = "SCORE\n" + PlayerPrefManager.GetLastScore();
        topScoreText.text = "TOP SCORE\n" + PlayerPrefManager.GetTopScore();
        crossesText.text = "CROSSES\n" + PlayerPrefManager.GetLastCrosses();
        topCrossesText.text = "TOP CROSSES\n" + PlayerPrefManager.GetTopCrosses();
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
