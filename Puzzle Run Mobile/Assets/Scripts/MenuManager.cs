﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;   

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainWindow = null;
    [SerializeField] private GameObject settingsWindow = null;
    [SerializeField] private GameObject controllerButton = null;
    [SerializeField] private GameObject controllerWindow = null;
    [SerializeField] private GameObject recordsWindow = null;
    [SerializeField] private GameObject rankingsWindow = null;

    [SerializeField] private GameObject rookieControllerInfo = null;
    [SerializeField] private GameObject proControllerInfo = null;

    [SerializeField] private TextMeshProUGUI topScoreText = null;
    [SerializeField] private TextMeshProUGUI topFitsText = null;
    [SerializeField] private TextMeshProUGUI topTimeText = null;
    [SerializeField] private TextMeshProUGUI topStreakText = null;

    [SerializeField] private AudioMixer audioMixer = null;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        UpdateRecords();

        ShowControllerInfo(GameManager.Controls[PlayerPrefManager.GetControls()]);

        SetupQualitySettings();
        SetupSoundSettings();

        if (! PlayerPrefManager.getTutorialDone())
            controllerButton.GetComponent<Animator>().Play("ControllerScaleAnimation");

        HideWindows();
        mainWindow.SetActive(true);
    }

    private void SetupQualitySettings()
    {
        QualitySettings.SetQualityLevel(PlayerPrefManager.GetQualityLevel());
    }

    private void SetupSoundSettings()
    {
        float musicVolume = PlayerPrefManager.GetMusicVolume();
        float sfxVolume = PlayerPrefManager.GetSFXVolume();

        audioMixer.SetFloat("Music", musicVolume);
        audioMixer.SetFloat("SFX", sfxVolume);
    }
    
    private void UpdateRecords()
    {
        topScoreText.text = PlayerPrefManager.GetTopScore().ToString();
        topFitsText.text = PlayerPrefManager.GetTopCrosses().ToString();
        topStreakText.text = PlayerPrefManager.GetTopStreak().ToString();
        
        TimeSpan timeSpan = TimeSpan.FromSeconds(PlayerPrefManager.GetTopTime());
        topTimeText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }

    private void ShowControllerInfo(string controls)
    {
        rookieControllerInfo.SetActive(false);
        proControllerInfo.SetActive(false);

        switch (controls)
        {
            case "ROOKIE":
                rookieControllerInfo.SetActive(true);
                break;
            case "PRO":
                proControllerInfo.SetActive(true);
                break;
            default:
                proControllerInfo.SetActive(true);
                break;
        }
    }

    private void HideWindows()
    {
        mainWindow.SetActive(false);
        settingsWindow.SetActive(false);
        controllerWindow.SetActive(false);
        recordsWindow.SetActive(false);
        rankingsWindow.SetActive(false);
    }

    public void Close()
    {
        HideWindows();
        mainWindow.SetActive(true);
    }

    public void ShowRecordsWindow()
    {
        HideWindows();
        recordsWindow.SetActive(true);
    }

    public void ShowRankingsWindow()
    {
        HideWindows();
        rankingsWindow.SetActive(true);
    }

    public void ShowControllerWindow()
    {
        PlayerPrefManager.SetTutorialDone(1);
        controllerButton.GetComponent<Animator>().Play("New State");

        HideWindows();
        controllerWindow.SetActive(true);
    }

    public void ShowSettingsWindow()
    {
        HideWindows();
        settingsWindow.SetActive(true);
    }

    public void SetControls(int index)
    {
        PlayerPrefManager.SetControls(index);
        ShowControllerInfo(GameManager.Controls[index]);
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
