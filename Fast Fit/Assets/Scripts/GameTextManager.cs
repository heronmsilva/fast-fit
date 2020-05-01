using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using TMPro;

public class GameTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pausedTitleText = null;
    [SerializeField] private TextMeshProUGUI continueText = null;

    [SerializeField] private ButtonManagerBasic resumeButton = null;
    [SerializeField] private ButtonManagerBasic finishButton = null;

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
        continueText.text = Texts.Continue;

        resumeButton.GetComponent<ButtonManagerBasic>().buttonText = Texts.Resume;
        finishButton.GetComponent<ButtonManagerBasic>().buttonText = Texts.Finish;
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
