using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;   

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject level = null;
    [SerializeField] private GameObject pausedWindow = null;
    [SerializeField] private GameObject gameOverWindow = null;
    [SerializeField] private GameObject watchAdTimer = null;
    [SerializeField] private GameObject moveTutorial = null;
    [SerializeField] private GameObject fastForwardTutorial = null;
    [SerializeField] private GameObject rookieRotateTutorial = null;
    [SerializeField] private GameObject rookieFlipTutorial = null;
    [SerializeField] private GameObject proRotateTutorial = null;
    [SerializeField] private GameObject proFlipTutorial = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI fitsText = null;
    [SerializeField] private TextMeshProUGUI levelText = null;
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

    public void ShowMoveTutorial()
    {
        moveTutorial.SetActive(true);
        moveTutorial.GetComponent<Animator>().Play("MoveTutorialAnimation");
    }

    public void ShowFastForwardTutorial()
    {
        fastForwardTutorial.SetActive(true);
        fastForwardTutorial.GetComponent<Animator>().Play("FastForwardTutorialAnimation");
    }

    public void ShowRotateTutorial()
    {
        string controls = GameManager.Controls[PlayerPrefManager.GetControls()];
        switch (controls)
        {
            case "ROOKIE":
                rookieRotateTutorial.SetActive(true);
                rookieRotateTutorial.GetComponent<Animator>().Play("RookieRotateTutorialAnimation");
                break;
            case "PRO":
                proRotateTutorial.SetActive(true);
                proRotateTutorial.GetComponent<Animator>().Play("ProRotateTutorialAnimation");
                break;
        }
    }

    public void ShowFlipTutorial()
    {
        string controls = GameManager.Controls[PlayerPrefManager.GetControls()];
        switch (controls)
        {
            case "ROOKIE":
                rookieFlipTutorial.SetActive(true);
                rookieFlipTutorial.GetComponent<Animator>().Play("RookieFlipTutorialAnimation");
                break;
            case "PRO":
                proFlipTutorial.SetActive(true);
                proFlipTutorial.GetComponent<Animator>().Play("ProFlipTutorialAnimation");
                break;
        }
    }

    public void HideGameOver()
    {
        gameOverWindow.SetActive(false);
    }

    public void GameOver()
    {
        gameOverWindow.SetActive(true);
        
        watchAdTimer.GetComponent<Animator>().SetFloat("Speed", 1 / GameManager.Instance.WatchAnAdTimer);
        watchAdTimer.GetComponent<Animator>().Play("Circle Pie");
    }

    public void Pause()
    {
        pausedWindow.SetActive(true);
    }

    public void Resume()
    {
        pausedWindow.SetActive(false);
    }

    public void UpdateUIHeader()
    {
        UpdateUIScore();
        UpdateUIFits();
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
        if (gm.Score == 0) return;
        
        scoreText.text = gm.Score.ToString();
    }

    private void UpdateUIFits()
    {
        if (gm.Fits == 0) return;
        
        fitsText.text = gm.Fits.ToString();
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
        levelFill.fillAmount = (float) gm.FitSequence / gm.MaxFitSequence;
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
