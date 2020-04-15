using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject level = null;
    [SerializeField] private GameObject pausedScreen = null;
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text crossesText = null;
    [SerializeField] private Text levelText = null;
    [SerializeField] private Text crossBonusText = null;
    [SerializeField] private Text speedBonusText = null;
    [SerializeField] private Image levelFill = null;
    [SerializeField] private Image outline = null;
    [SerializeField] private List<Image> lifeImages = new List<Image>();
    
    private GameManager gm;
    private AnimationBuffer animBuffer;
    private float startTime;

    private void Start()
    {
        gm = GetComponent<GameManager>();
        animBuffer = GetComponent<AnimationBuffer>();

        startTime = Time.time;
    }

    public void ShowCrossBonus(int bonus)
    {
        crossBonusText.text = "SEQUENCE x" + bonus.ToString();
        crossBonusText.GetComponent<Animator>().Play("InfoTextFade");
    }

    public void ShowFastForwardBonus(int bonus)
    {
        speedBonusText.text = "x" + bonus.ToString() + " FORWARD";
        speedBonusText.GetComponent<Animator>().Play("InfoTextFade");
    }

    public void Pause()
    {
        pausedScreen.SetActive(true);
    }

    public void Resume()
    {
        pausedScreen.SetActive(false);
    }

    public void UpdateUIHeader()
    {
        UpdateUIScore();
        UpdateUICrosses();
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

    private void UpdateUIScore()
    {
        scoreText.text = gm.Score.ToString();
    }

    private void UpdateUICrosses()
    {
        crossesText.text = gm.Crosses.ToString();
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
