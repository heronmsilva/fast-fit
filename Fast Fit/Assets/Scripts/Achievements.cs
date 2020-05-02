using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Achievements
{
    public static void SetMeetLevel1(int value)
    {
        PlayerPrefs.SetInt("Meet Level 1", value);
    }

    public static bool GetMeetLevel1()
    {
        if (PlayerPrefs.HasKey("Meet Level 1"))
        {
            if (PlayerPrefs.GetInt("Meet Level 1") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetMeetLevel2(int value)
    {
        PlayerPrefs.SetInt("Meet Level 2", value);
    }

    public static bool GetMeetLevel2()
    {
        if (PlayerPrefs.HasKey("Meet Level 2"))
        {
            if (PlayerPrefs.GetInt("Meet Level 2") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetMeetLevel3(int value)
    {
        PlayerPrefs.SetInt("Meet Level 3", value);
    }

    public static bool GetMeetLevel3()
    {
        if (PlayerPrefs.HasKey("Meet Level 3"))
        {
            if (PlayerPrefs.GetInt("Meet Level 3") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetMeetLevel4(int value)
    {
        PlayerPrefs.SetInt("Meet Level 4", value);
    }

    public static bool GetMeetLevel4()
    {
        if (PlayerPrefs.HasKey("Meet Level 4"))
        {
            if (PlayerPrefs.GetInt("Meet Level 4") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetMeetMaxLevel(int value)
    {
        PlayerPrefs.SetInt("Meet Max Level", value);
    }

    public static bool GetMeetMaxLevel()
    {
        if (PlayerPrefs.HasKey("Meet Max Level"))
        {
            if (PlayerPrefs.GetInt("Meet Max Level") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetIGotIt(int value)
    {
        PlayerPrefs.SetInt("I got it", value);
    }

    public static bool GetIGotIt()
    {
        if (PlayerPrefs.HasKey("I got it"))
        {
            if (PlayerPrefs.GetInt("I got it") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetBlocksAreMyFriend(int value)
    {
        PlayerPrefs.SetInt("Blocks are my friends", value);
    }

    public static bool GetBlocksAreMyFriend()
    {
        if (PlayerPrefs.HasKey("Blocks are my friends"))
        {
            if (PlayerPrefs.GetInt("Blocks are my friends") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetImImproving(int value)
    {
        PlayerPrefs.SetInt("Im Improving", value);
    }

    public static bool GetImImproving()
    {
        if (PlayerPrefs.HasKey("Im Improving"))
        {
            if (PlayerPrefs.GetInt("Im Improving") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetThisIsActuallyEasy(int value)
    {
        PlayerPrefs.SetInt("This is actually easy", value);
    }

    public static bool GetThisIsActuallyEasy()
    {
        if (PlayerPrefs.HasKey("This is actually easy"))
        {
            if (PlayerPrefs.GetInt("This is actually easy") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetTheMaster(int value)
    {
        PlayerPrefs.SetInt("The Master", value);
    }

    public static bool GetTheMaster()
    {
        if (PlayerPrefs.HasKey("The Master"))
        {
            if (PlayerPrefs.GetInt("The Master") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetTheProfessional(int value)
    {
        PlayerPrefs.SetInt("The Professional", value);
    }

    public static bool GetTheProfessional()
    {
        if (PlayerPrefs.HasKey("The Professional"))
        {
            if (PlayerPrefs.GetInt("The Professional") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetRookie(int value)
    {
        PlayerPrefs.SetInt("Rookie", value);
    }

    public static bool GetRookie()
    {
        if (PlayerPrefs.HasKey("Rookie"))
        {
            if (PlayerPrefs.GetInt("Rookie") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetApprentice(int value)
    {
        PlayerPrefs.SetInt("Apprentice", value);
    }

    public static bool GetApprentice()
    {
        if (PlayerPrefs.HasKey("Apprentice"))
        {
            if (PlayerPrefs.GetInt("Apprentice") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetTeacher(int value)
    {
        PlayerPrefs.SetInt("Teacher", value);
    }

    public static bool GetTeacher()
    {
        if (PlayerPrefs.HasKey("Teacher"))
        {
            if (PlayerPrefs.GetInt("Teacher") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetBlockBuilder(int value)
    {
        PlayerPrefs.SetInt("Block Builder", value);
    }

    public static bool GetBlockBuilder()
    {
        if (PlayerPrefs.HasKey("Block Builder"))
        {
            if (PlayerPrefs.GetInt("Block Builder") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetBreaker(int value)
    {
        PlayerPrefs.SetInt("Breaker", value);
    }

    public static bool GetBreaker()
    {
        if (PlayerPrefs.HasKey("Breaker"))
        {
            if (PlayerPrefs.GetInt("Breaker") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetTheCompletionist(int value)
    {
        PlayerPrefs.SetInt("The Completionist", value);
    }

    public static bool GetTheCompletionist()
    {
        if (PlayerPrefs.HasKey("The Completionist"))
        {
            if (PlayerPrefs.GetInt("The Completionist") == 1)
                return true;
        }
        
        return false;
    }
}
