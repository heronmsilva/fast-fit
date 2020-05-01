using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tapToPlayText = null;

    private void Awake() 
    {
        SetupLanguage();
    }

    private void Start()
    {
        UpdateTexts();
    }

    public void UpdateTexts()
    {
        tapToPlayText.text = Texts.TapTopPlay;
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
