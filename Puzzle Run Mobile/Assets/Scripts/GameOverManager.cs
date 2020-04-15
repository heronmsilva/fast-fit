using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Text scoreText = null;    
    [SerializeField] private Text bestScoreText = null;
    [SerializeField] private Text crossesText = null;
    [SerializeField] private Text bestCrossesText = null;

    private void Start()
    {
        UpdateGameOverUI();
    }

    private void UpdateGameOverUI()
    {
        int score = PlayerPrefManager.GetLastScore();
        int crosses = PlayerPrefManager.GetLastCrosses();

        scoreText.text = "SCORE\n" + score;
        crossesText.text = "CROSSES\n" + crosses;

        if (score == PlayerPrefManager.GetTopScore())
            bestScoreText.gameObject.SetActive(true);
        else
            bestScoreText.gameObject.SetActive(false);

        if (crosses == PlayerPrefManager.GetTopCrosses())
            bestCrossesText.gameObject.SetActive(true);
        else
            bestCrossesText.gameObject.SetActive(false);
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
