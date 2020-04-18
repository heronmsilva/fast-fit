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
    [SerializeField] private AudioClip UIButtonClick = null;
    [SerializeField] private AudioClip UIButtonClose = null;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SetupSavedControls();
        SetupSavedSettings();
        SetupRecords();
    }
    
    private void SetupRecords()
    {
        topScoreText.text = PlayerPrefManager.GetTopScore().ToString();
        topCrossesText.text = PlayerPrefManager.GetTopCrosses().ToString();
        topStreakText.text = PlayerPrefManager.GetTopStreak().ToString();
        TimeSpan timeSpan = TimeSpan.FromSeconds(PlayerPrefManager.GetTopTime());
        string time = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        topTimeText.text = time;
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
        audioSource.PlayOneShot(UIButtonClose);
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
        controlsScreen.SetActive(false);
        recordsScreen.SetActive(false);
    }

    public void Settings()
    {
        audioSource.PlayOneShot(UIButtonClick);
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
        controlsScreen.SetActive(false);
        recordsScreen.SetActive(false);
    }

    public void Controls()
    {
        audioSource.PlayOneShot(UIButtonClick);
        mainScreen.SetActive(false);
        settingsScreen.SetActive(false);
        controlsScreen.SetActive(true);
        recordsScreen.SetActive(false);
    }

    public void Records()
    {
        audioSource.PlayOneShot(UIButtonClick);
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
