using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen = null;
    [SerializeField] private GameObject settingsScreen = null;
    [SerializeField] private Dropdown controlsDropdown = null;
    [SerializeField] private Dropdown graphicsDropdown = null;

    private void Start()
    {
        controlsDropdown.AddOptions(GameManager.Controls);
        controlsDropdown.value = PlayerPrefManager.GetControls();
        
        int qualityLevel = PlayerPrefManager.GetQualityLevel();
        QualitySettings.SetQualityLevel(qualityLevel);
        graphicsDropdown.value = qualityLevel;
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void Main()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void Settings()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void SetControls(int index)
    {
        PlayerPrefManager.SetControls(index);
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
