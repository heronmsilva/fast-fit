using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject level = null;
    [SerializeField] private GameObject pausedScreen = null;
    [SerializeField] private GameObject gameOverScreen = null;
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text crossesText = null;
    [SerializeField] private Text levelText = null;
    [SerializeField] private Image watchAdTimer = null;
    [SerializeField] private Image levelFill = null;
    [SerializeField] private List<Image> lifeImages = new List<Image>();
    
    private GameManager gm;
    private AnimationBuffer animBuffer;
    private float startTime;

    private void Awake()
    {
        gm = GetComponent<GameManager>();
        animBuffer = GetComponent<AnimationBuffer>();
    }

    private void Start()
    {
        startTime = Time.time;
    }

    public void HideGameOver()
    {
        gameOverScreen.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        watchAdTimer.GetComponent<Animator>().Play("ReduceFillAnimation");
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

    public void PlayUseLifeAnimation()
    {
        Image life = GetLastLife();
        if (life)
            life.GetComponent<Animator>().Play("LifeFade");
    }

    private Image GetLastLife()
    {
        for (int i = lifeImages.Count - 1; i >= 0; i--)
        {
            if (lifeImages[i].enabled)
                return lifeImages[i];
        }
        return null;
    }

    public void PlayLevelUpAnimation()
    {
        level.GetComponent<Animator>().Play("LevelSwing");
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
