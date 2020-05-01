using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pausedTitleText = null;

    [SerializeField] private TextMeshProUGUI resumeText = null;
    [SerializeField] private TextMeshProUGUI finishText = null;

    private void Awake() 
    {
        SetupLanguage();
    }

    private void Start()
    {
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        pausedTitleText.text = Texts.GamePaused;

        resumeText.text = Texts.Resume;
        finishText.text = Texts.Finish;
    }

    private void SetupLanguage()
    {
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Portuguese:
                Texts.Language = Texts.Portuguese;
                break;
            case SystemLanguage.English:
            default:
                Texts.Language = Texts.English;
                break;
        }
    }
}
