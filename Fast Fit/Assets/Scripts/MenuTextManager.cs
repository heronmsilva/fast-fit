using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tapToPlayText = null;

    [SerializeField] private TextMeshProUGUI recordsTitleText = null;
    [SerializeField] private TextMeshProUGUI controlsTitleText = null;
    [SerializeField] private TextMeshProUGUI settingsTitleText = null;

    [SerializeField] private TextMeshProUGUI topScoreText = null;
    [SerializeField] private TextMeshProUGUI longestRunText = null;
    [SerializeField] private TextMeshProUGUI topFitsInARunText = null;
    [SerializeField] private TextMeshProUGUI topStreakText = null;
    [SerializeField] private TextMeshProUGUI runsText = null;

    [SerializeField] private TextMeshProUGUI moveInfoText = null;
    [SerializeField] private TextMeshProUGUI fastForwardInfoText = null;
    [SerializeField] private TextMeshProUGUI rookieRotateLeftText = null;
    [SerializeField] private TextMeshProUGUI rookieRotateRightText = null;
    [SerializeField] private TextMeshProUGUI rookieFlipHorizontally = null;
    [SerializeField] private TextMeshProUGUI rookieFlipVertically = null;
    [SerializeField] private TextMeshProUGUI proRotateRightText = null;
    [SerializeField] private TextMeshProUGUI proFlipVerticallyText = null;

    [SerializeField] private TextMeshProUGUI graphicsText = null;
    [SerializeField] private TextMeshProUGUI musicText = null;
    [SerializeField] private TextMeshProUGUI sfxText = null;

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
        controlsTitleText.text = Texts.Controls;
        settingsTitleText.text = Texts.Settings;

        topScoreText.text = Texts.Score;
        longestRunText.text = Texts.LongestRun;
        topFitsInARunText.text = Texts.Fits;
        topStreakText.text = Texts.TopStreak;
        runsText.text = Texts.Runs;

        moveInfoText.text = Texts.MoveInfo;
        fastForwardInfoText.text = Texts.FastForwardInfo;
        rookieRotateLeftText.text = Texts.RotateLeft;
        rookieRotateRightText.text = Texts.RotateRight;
        rookieFlipHorizontally.text = Texts.FlipHorizontally;
        rookieFlipVertically.text = Texts.FlipVertically;
        proRotateRightText.text = Texts.RotateRight;
        proFlipVerticallyText.text = Texts.FlipVertically;

        graphicsText.text = Texts.Graphics;
        musicText.text = Texts.Music;
        sfxText.text = Texts.SoundEffects;
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
