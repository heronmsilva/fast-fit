using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Dropdown controlsDropdown = null;

    private void Start()
    {
        controlsDropdown.AddOptions(GameManager.Controls);
        controlsDropdown.value = PlayerPrefManager.GetControls();
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
