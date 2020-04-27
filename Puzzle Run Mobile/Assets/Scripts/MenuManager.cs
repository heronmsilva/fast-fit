using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;   

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen = null;
    [SerializeField] private GameObject settingsScreen = null;
    [SerializeField] private GameObject controlsButton = null;
    [SerializeField] private GameObject controlsScreen = null;
    [SerializeField] private GameObject recordsScreen = null;
    [SerializeField] private GameObject rankingsScreen = null;
    [SerializeField] private GameObject touchControlsArea = null;
    [SerializeField] private GameObject floatingControlsArea = null;
    [SerializeField] private GameObject fixedControlsArea = null;
    [SerializeField] private Dropdown controlsDropdown = null;
    [SerializeField] private Dropdown graphicsDropdown = null;
    [SerializeField] private TextMeshProUGUI topScoreText = null;
    [SerializeField] private TextMeshProUGUI topCrossesText = null;
    [SerializeField] private TextMeshProUGUI topTimeText = null;
    [SerializeField] private TextMeshProUGUI topStreakText = null;
    [SerializeField] private AudioClip UIButtonClick = null;
    [SerializeField] private AudioClip UIButtonClose = null;
    [SerializeField] private AudioMixer audioMixer = null;
    [SerializeField] private Slider musicSlider = null;
    [SerializeField] private Slider sfxSlider = null;

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

        if (! PlayerPrefManager.getTutorialDone())
            controlsButton.GetComponent<Animator>().Play("ControllerScaleAnimation");
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

        float musicVolume = PlayerPrefManager.GetMusicVolume();
        audioMixer.SetFloat("Music", musicVolume);
        musicSlider.value = musicVolume;
        float sfxVolume = PlayerPrefManager.GetSFXVolume();
        audioMixer.SetFloat("SFX", sfxVolume);
        sfxSlider.value = sfxVolume;
    }

    private void SetupSavedControls()
    {
        int controls = PlayerPrefManager.GetControls();
        controlsDropdown.AddOptions(GameManager.Controls);
        controlsDropdown.value = controls;
        ShowControlsInfo(GameManager.Controls[controls]);
    }

    public void Close()
    {
        audioSource.PlayOneShot(UIButtonClose);
        ShowMainScreen();
    }

    public void ShowMainScreen()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
        controlsScreen.SetActive(false);
        recordsScreen.SetActive(false);
        rankingsScreen.SetActive(false);
    }

    public void ShowRecordsScreen()
    {
        audioSource.PlayOneShot(UIButtonClick);
        mainScreen.SetActive(false);
        settingsScreen.SetActive(false);
        controlsScreen.SetActive(false);
        recordsScreen.SetActive(true);
        rankingsScreen.SetActive(false);
    }

    public void ShowRankingsScreen()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(false);
        controlsScreen.SetActive(false);
        recordsScreen.SetActive(false);
        rankingsScreen.SetActive(true);
    }

    public void ShowControllerScreen()
    {
        PlayerPrefManager.SetTutorialDone(1);
        controlsButton.GetComponent<Animator>().Play("New State");
        mainScreen.SetActive(false);
        settingsScreen.SetActive(false);
        controlsScreen.SetActive(true);
        recordsScreen.SetActive(false);
        rankingsScreen.SetActive(false);
    }

    public void ShowSettingsScreen()
    {
        audioSource.PlayOneShot(UIButtonClick);
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
        controlsScreen.SetActive(false);
        recordsScreen.SetActive(false);
        rankingsScreen.SetActive(false);
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

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
        PlayerPrefManager.SetMusicVolume(volume);
    }
    
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", volume);
        PlayerPrefManager.SetSFXVolume(volume);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
