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

    private void Start()
    {
        controlsDropdown.AddOptions(GameManager.Controls);
        controlsDropdown.value = PlayerPrefManager.GetControls();
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

    public void UpdateControls(int index)
    {
        PlayerPrefManager.SetControls(index);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
