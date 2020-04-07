using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject level = null;
    [SerializeField] private Text timeText = null;
    [SerializeField] private Text timeGOText = null;
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text scoreGOText = null;
    [SerializeField] private Text topScoreGOText = null;
    [SerializeField] private Text levelText = null;
    [SerializeField] private Image levelFill = null;
    [SerializeField] private Image outline = null;
    [SerializeField] private List<Image> lifeImages = new List<Image>();
    
    private GameManager gm;
    private float startTime;

    private void Start()
    {
        gm = GetComponent<GameManager>();

        startTime = Time.time;
    }

    public void UpdateGameOverUI()
    {
        UpdateGOUITime();
        UpdateGOUIScore();
        UpdateGOUITopScore();
    }

    public void UpdateUIHeader()
    {
        UpdateUITime();
        UpdateUIScore();
        UpdateUIDifficulty();
        UpdateUIDifficultyFill();
        UpdateUILives();
    }

    public void PlayLevelUpAnimation()
    {
        level.GetComponent<Animator>().Play("LevelSwing");
    }

    public void PlayCrossAnimation()
    {
        outline.GetComponent<Animator>().Play("OutlineFill");
    }

    private void UpdateGOUITime()
    {
        int time = (int) (Time.time - startTime - gm.FastForwardedTime);
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        int minutes = timeSpan.Minutes;
        int seconds = timeSpan.Seconds;
        timeGOText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

    private void UpdateGOUIScore()
    {
        scoreGOText.text = gm.Score.ToString();
    }

    private void UpdateGOUITopScore()
    {
        topScoreGOText.text = PlayerPrefManager.GetTopScore().ToString();
    }

    public void UpdateUITime()
    {
        if (Time.timeScale != 1) return;

        int time = (int) (Time.time - startTime - gm.FastForwardedTime);
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        int minutes = timeSpan.Minutes;
        int seconds = timeSpan.Seconds;
        timeText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

    private void UpdateUIScore()
    {
        scoreText.text = gm.Score.ToString();
    }

    private void UpdateUIDifficulty()
    {
        if (gm.CurrDifficulty == GameManager.Difficulty.Level5)
            levelText.text = "MAX";
        else
            levelText.text = "Lv " + ((int) gm.CurrDifficulty).ToString();
    }

    private void UpdateUIDifficultyFill()
    {
        levelFill.fillAmount = (float) gm.CrossSequence / gm.MaxCrossSequence;
    }

    private void UpdateUILives()
    {
        for (int i = 0; i < gm.MaxLives; i++)
        {
            if (i < gm.Lives)
                lifeImages[i].enabled = true;
            else
                lifeImages[i].enabled = false;
        }
    }
}
