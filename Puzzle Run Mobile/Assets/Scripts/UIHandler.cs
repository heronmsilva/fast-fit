using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject level = null;
    [SerializeField] private GameObject pausedScreen = null;
    [SerializeField] private GameObject UIHeader = null;
    [SerializeField] private GameObject controller = null;
    [SerializeField] private GameObject tutorial = null;
    [SerializeField] private GameObject tutorialPart1 = null;
    [SerializeField] private GameObject tutorialPart2 = null;
    [SerializeField] private GameObject tutorialPart3 = null;
    [SerializeField] private GameObject tutorialPart4 = null;
    [SerializeField] private GameObject tutorialPart5 = null;
    [SerializeField] private GameObject tutorialPart6 = null;
    [SerializeField] private GameObject tutorialObjects = null;
    [SerializeField] private GameObject tutorialObjects2 = null;
    [SerializeField] private GameObject tutorialObjects3 = null;
    [SerializeField] private GameObject tutorialObjects4 = null;
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text crossesText = null;
    [SerializeField] private Text levelText = null;
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

    public void ShowTutorial()
    {
        HideUI();
        tutorial.SetActive(true);
    }

    public void ShowTutorialPart2()
    {
        tutorialPart1.SetActive(false);
        tutorialPart2.SetActive(true);
        tutorialObjects.SetActive(true);
    }

    public void ShowTutorialPart3()
    {
        tutorialPart2.SetActive(false);
        tutorialPart3.SetActive(true);
        tutorialObjects2.SetActive(false);
        tutorialObjects3.SetActive(true);
        controller.SetActive(true);
    }

    public void ShowTutorialPart4()
    {
        tutorialPart3.SetActive(false);
        tutorialPart4.SetActive(true);
        tutorialObjects3.SetActive(false);
        tutorialObjects4.SetActive(true);
    }

    public void ShowTutorialPart5()
    {
        tutorialPart4.SetActive(false);
        tutorialPart5.SetActive(true);
        tutorialObjects4.SetActive(false);
    }

    public void ShowTutorialPart6()
    {
        tutorialPart5.SetActive(false);
        tutorialPart6.SetActive(true);
        UIHeader.SetActive(true);
    }

    public void HideUI()
    {
        UIHeader.SetActive(false);
        controller.SetActive(false);
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
