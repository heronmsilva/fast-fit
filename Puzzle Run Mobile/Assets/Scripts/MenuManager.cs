using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen = null;
    [SerializeField] private GameObject settingsScreen = null;
    [SerializeField] private GameObject controlsScreen = null;
    [SerializeField] private GameObject recordsScreen = null;
    [SerializeField] private GameObject touchControlsArea = null;
    [SerializeField] private GameObject floatingControlsArea = null;
    [SerializeField] private GameObject fixedControlsArea = null;
    [SerializeField] private Dropdown controlsDropdown = null;
    [SerializeField] private Dropdown graphicsDropdown = null;
    [SerializeField] private Text topScoreText = null;
    [SerializeField] private Text topCrossesText = null;
    [SerializeField] private Text topTimeText = null;
    [SerializeField] private Text topStreakText = null;

    private void Start()
    {
        SetupSavedControls();
        SetupSavedSettings();
        SetupRecords();
    }
    
    private void SetupRecords()
    {
        topScoreText.text = "TOP SCORE: " + PlayerPrefManager.GetTopScore();
        topCrossesText.text = "TOP CROSSES: " + PlayerPrefManager.GetTopCrosses();
        TimeSpan timeSpan = TimeSpan.FromSeconds(PlayerPrefManager.GetTopTime());
        string time = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        topTimeText.text = "TOP TIME: " + time;
        topStreakText.text = "TOP STREAK: " + PlayerPrefManager.GetTopStreak();
    }

    private void SetupSavedSettings()
    {
        int qualityLevel = PlayerPrefManager.GetQualityLevel();
        QualitySettings.SetQualityLevel(qualityLevel);
        graphicsDropdown.value = qualityLevel;
    }

    private void SetupSavedControls()
    {
        int controls = PlayerPrefManager.GetControls();
        controlsDropdown.AddOptions(GameManager.Controls);
        controlsDropdown.value = controls;
        ShowControlsInfo(GameManager.Controls[controls]);
    }

    public void Main()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
        controlsScreen.SetActive(false);
        recordsScreen.SetActive(false);
    }

    public void Settings()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
        controlsScreen.SetActive(false);
        recordsScreen.SetActive(false);
    }

    public void Controls()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(false);
        controlsScreen.SetActive(true);
        recordsScreen.SetActive(false);
    }

    public void Records()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(false);
        controlsScreen.SetActive(false);
        recordsScreen.SetActive(true);
    }

    public void SetControls(int index)
    {
        PlayerPrefManager.SetControls(index);
        ShowControlsInfo(GameManager.Controls[index]);
    }

    private void ShowControlsInfo(string controls)
    {
        touchControlsArea.SetActive(false);
        floatingControlsArea.SetActive(false);
        fixedControlsArea.SetActive(false);
        switch (controls)
        {
            case "TOUCH":
                touchControlsArea.SetActive(true);
                break;
            case "FLOATING":
                floatingControlsArea.SetActive(true);
                break;
            case "FIXED":
                fixedControlsArea.SetActive(true);
                break;
        }
    }

    public void SetQuality(int index)
    {
        PlayerPrefManager.SetQualityLevel(index);
        QualitySettings.SetQualityLevel(index);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
