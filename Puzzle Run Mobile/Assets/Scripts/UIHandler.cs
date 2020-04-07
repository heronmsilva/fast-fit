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
    [SerializeField] private Image nextAnimImage = null;
    [SerializeField] private List<Image> lifeImages = new List<Image>();
    [SerializeField] private List<Sprite> nextAnimsIcons = new List<Sprite>();
    
    private GameManager gm;
    private AnimationBuffer animBuffer;
    private float startTime;

    private void Start()
    {
        gm = GetComponent<GameManager>();
        animBuffer = GetComponent<AnimationBuffer>();

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
        UpdateNextAnimation();
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

    private void UpdateUITime()
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

    private void UpdateNextAnimation()
    {
        switch (animBuffer.GetNextAnimation())
        {
            case "None":
                nextAnimImage.GetComponent<Image>().sprite = nextAnimsIcons[0];
                break;
            case "Fade":
                nextAnimImage.GetComponent<Image>().sprite = nextAnimsIcons[1];
                break;
            case "FadeRotateX":
                nextAnimImage.GetComponent<Image>().sprite = nextAnimsIcons[2];
                break;
            case "FadeRotateXY":
                nextAnimImage.GetComponent<Image>().sprite = nextAnimsIcons[3];
                break;
            case "FadeRotateY":
                nextAnimImage.GetComponent<Image>().sprite = nextAnimsIcons[4];
                break;
            case "RotateX":
                nextAnimImage.GetComponent<Image>().sprite = nextAnimsIcons[5];
                break;
            case "RotateXY":
                nextAnimImage.GetComponent<Image>().sprite = nextAnimsIcons[6];
                break;
            case "RotateY":
                nextAnimImage.GetComponent<Image>().sprite = nextAnimsIcons[7];
                break;
        }
    }
}
