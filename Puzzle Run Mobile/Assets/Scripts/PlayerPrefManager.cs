using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefManager
{
    public static void SetQualityLevel(int index)
    {
        PlayerPrefs.SetInt("Quality Level", index);
    }

    public static int GetQualityLevel()
    {
        return (PlayerPrefs.HasKey("Quality Level")) ? PlayerPrefs.GetInt("Quality Level") : 1;
    }

    public static void SetControls(int index)
    {
        PlayerPrefs.SetInt("Controls", index);
    }

    public static int GetControls()
    {
        return (PlayerPrefs.HasKey("Controls")) ? PlayerPrefs.GetInt("Controls") : 0;
    }

    public static void SetTopStreak(int streak)
    {
        PlayerPrefs.SetInt("Top Streak", streak);
    }

    public static int GetTopStreak()
    {
        return (PlayerPrefs.HasKey("Top Streak")) ? PlayerPrefs.GetInt("Top Streak") : 0;
    }

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

    public static void SetTopTime(float time)
    {
        PlayerPrefs.SetFloat("Top Time", time);
    }

    public static float GetTopTime()
    {
        return (PlayerPrefs.HasKey("Top Time")) ? PlayerPrefs.GetFloat("Top Time") : 0;
    }

    public static void SetLastTime(float time)
    {
        PlayerPrefs.SetFloat("Last Time", time);
    }

    public static float GetLastTime()
    {
        return (PlayerPrefs.HasKey("Last Time")) ? PlayerPrefs.GetFloat("Last Time") : 0;
    }

    public static void SetTopCrosses(int crosses)
    {
        PlayerPrefs.SetInt("Top Crosses", crosses);
    }

    public static int GetTopCrosses()
    {
        return (PlayerPrefs.HasKey("Top Crosses")) ? PlayerPrefs.GetInt("Top Crosses") : 0;
    }

    public static void SetLastCrosses(int crosses)
    {
        PlayerPrefs.SetInt("Last Crosses", crosses);
    }

    public static int GetLastCrosses()
    {
        return (PlayerPrefs.HasKey("Last Crosses")) ? PlayerPrefs.GetInt("Last Crosses") : 0;
    }
}
