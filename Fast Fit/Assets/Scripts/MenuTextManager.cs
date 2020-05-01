using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tapToPlayText = null;
    [SerializeField] private TextMeshProUGUI recordsTitleText = null;
    [SerializeField] private TextMeshProUGUI topScoreText = null;
    [SerializeField] private TextMeshProUGUI longestRunText = null;
    [SerializeField] private TextMeshProUGUI topFitsInARunText = null;
    [SerializeField] private TextMeshProUGUI topStreakText = null;
    [SerializeField] private TextMeshProUGUI runsText = null;

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
        recordsTitleText.text = Texts.Records;
        topScoreText.text = Texts.TopScore;
        longestRunText.text = Texts.LongestRun;
        topFitsInARunText.text = Texts.TopFitsInARun;
        topStreakText.text = Texts.TopStreak;
        runsText.text = Texts.Runs;
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
