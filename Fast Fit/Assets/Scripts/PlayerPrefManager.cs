using UnityEngine;

public static class PlayerPrefManager
{
    public static void Clear()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void SetPlayedOffline(int value)
    {
        PlayerPrefs.SetInt("Played Offline", value);
    }

    public static bool GetPlayedOffline()
    {
        if (PlayerPrefs.HasKey("Played Offline"))
        {
            if (PlayerPrefs.GetInt("Played Offline") == 1)
            {
                return true;
            }
            return false;
        }
        else return false;
    }

    public static void SetAttempts(int attempts)
    {
        PlayerPrefs.SetInt("Attempts", attempts);
    }

    public static int GetAttempts()
    {
        return (PlayerPrefs.HasKey("Attempts")) ? PlayerPrefs.GetInt("Attempts") : 0;
    }

    public static void SetMoveTutorialDone(int done)
    {
        PlayerPrefs.SetInt("Move Tutorial Done", done);
    }

    public static bool GetMoveTutorialDone()
    {
        if (PlayerPrefs.HasKey("Move Tutorial Done"))
        {
            if (PlayerPrefs.GetInt("Move Tutorial Done") == 1)
            {
                return true;
            }
            return false;
        }
        else return false;
    }

    public static void SetFastForwardTutorialDone(int done)
    {
        PlayerPrefs.SetInt("FastForward Tutorial Done", done);
    }

    public static bool GetFastForwardTutorialDone()
    {
        if (PlayerPrefs.HasKey("FastForward Tutorial Done"))
        {
            if (PlayerPrefs.GetInt("FastForward Tutorial Done") == 1)
            {
                return true;
            }
            return false;
        }
        else return false;
    }

    public static void SetRotateTutorialDone(int done)
    {
        PlayerPrefs.SetInt("Rotate Tutorial Done", done);
    }

    public static bool GetRotateTutorialDone()
    {
        if (PlayerPrefs.HasKey("Rotate Tutorial Done"))
        {
            if (PlayerPrefs.GetInt("Rotate Tutorial Done") == 1)
            {
                return true;
            }
            return false;
        }
        else return false;
    }

    public static void SetFlipTutorialDone(int done)
    {
        PlayerPrefs.SetInt("Flip Tutorial Done", done);
    }

    public static bool GetFlipTutorialDone()
    {
        if (PlayerPrefs.HasKey("Flip Tutorial Done"))
        {
            if (PlayerPrefs.GetInt("Flip Tutorial Done") == 1)
            {
                return true;
            }
            return false;
        }
        else return false;
    }

    public static void SetSFXVolume(float index)
    {
        PlayerPrefs.SetFloat("SFX Volume", index);
    }

    public static float GetSFXVolume()
    {
        return (PlayerPrefs.HasKey("SFX Volume")) ? PlayerPrefs.GetFloat("SFX Volume") : 0;
    }

    public static void SetMusicVolume(float index)
    {
        PlayerPrefs.SetFloat("Music Volume", index);
    }

    public static float GetMusicVolume()
    {
        return (PlayerPrefs.HasKey("Music Volume")) ? PlayerPrefs.GetFloat("Music Volume") : 0;
    }

    public static void SetMasterVolume(float index)
    {
        PlayerPrefs.SetFloat("Master Volume", index);
    }

    public static float GetMasterVolume()
    {
        return (PlayerPrefs.HasKey("Master Volume")) ? PlayerPrefs.GetFloat("Master Volume") : 0;
    }

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

    public static void SetLastStreak(int streak)
    {
        PlayerPrefs.SetInt("Last Streak", streak);
    }

    public static int GetLastStreak()
    {
        return (PlayerPrefs.HasKey("Last Streak")) ? PlayerPrefs.GetInt("Last Streak") : 0;
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

    public static void SetTopFits(int fits)
    {
        PlayerPrefs.SetInt("Top Fits", fits);
    }

    public static int GetTopFits()
    {
        return (PlayerPrefs.HasKey("Top Fits")) ? PlayerPrefs.GetInt("Top Fits") : 0;
    }

    public static void SetLastFits(int fits)
    {
        PlayerPrefs.SetInt("Last Fits", fits);
    }

    public static int GetLastFits()
    {
        return (PlayerPrefs.HasKey("Last Fits")) ? PlayerPrefs.GetInt("Last Fits") : 0;
    }
}
