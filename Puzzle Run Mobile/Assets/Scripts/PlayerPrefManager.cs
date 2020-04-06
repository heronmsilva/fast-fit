using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefManager
{
    public static void SetTopScore(int score)
    {
        PlayerPrefs.SetInt("Top Score", score);
    }

    public static int GetTopScore()
    {
        return (PlayerPrefs.HasKey("Top Score")) ? PlayerPrefs.GetInt("Top Score") : 0;
    }

    public static void SetLastScore(int score)
    {
        PlayerPrefs.SetInt("Last Score", score);
    }

    public static int GetLastScore()
    {
        return (PlayerPrefs.HasKey("Last Score")) ? PlayerPrefs.GetInt("Last Score") : 0;
    }
}
