using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI fitsText = null;
    [SerializeField] private TextMeshProUGUI topStreakText = null;
    
    [SerializeField] private TextMeshProUGUI newBestTimeText = null;
    [SerializeField] private TextMeshProUGUI newBestScoreText = null;
    [SerializeField] private TextMeshProUGUI newBestFitsText = null;
    [SerializeField] private TextMeshProUGUI newBestStreakText = null;

    [SerializeField] private TextMeshProUGUI tryAgainText = null;

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
        timeText.text = Texts.Time;
        scoreText.text = Texts.Score;
        fitsText.text = Texts.Fits;
        topStreakText.text = Texts.TopStreak;

        newBestTimeText.text = Texts.NewRecord;
        newBestScoreText.text = Texts.NewRecord;
        newBestFitsText.text = Texts.NewRecord;
        newBestStreakText.text = Texts.NewRecord;

        tryAgainText.text = Texts.TryAgain;
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
