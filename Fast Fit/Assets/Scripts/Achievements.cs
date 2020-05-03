using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Achievements
{
    public static void SetLevel1(int value)
    {
        PlayerPrefs.SetInt("Level 1", value);
    }

    public static bool GetLevel1()
    {
        if (PlayerPrefs.HasKey("Level 1"))
        {
            if (PlayerPrefs.GetInt("Level 1") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetLevel2(int value)
    {
        PlayerPrefs.SetInt("Level 2", value);
    }

    public static bool GetLevel2()
    {
        if (PlayerPrefs.HasKey("Level 2"))
        {
            if (PlayerPrefs.GetInt("Level 2") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetLevel3(int value)
    {
        PlayerPrefs.SetInt("Level 3", value);
    }

    public static bool GetLevel3()
    {
        if (PlayerPrefs.HasKey("Level 3"))
        {
            if (PlayerPrefs.GetInt("Level 3") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetLevel4(int value)
    {
        PlayerPrefs.SetInt("Level 4", value);
    }

    public static bool GetLevel4()
    {
        if (PlayerPrefs.HasKey("Level 4"))
        {
            if (PlayerPrefs.GetInt("Level 4") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetMaxLevel(int value)
    {
        PlayerPrefs.SetInt("Max Level", value);
    }

    public static bool GetMaxLevel()
    {
        if (PlayerPrefs.HasKey("Max Level"))
        {
            if (PlayerPrefs.GetInt("Max Level") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetICanDoIt(int value)
    {
        PlayerPrefs.SetInt("I can do it", value);
    }

    public static bool GetICanDoIt()
    {
        if (PlayerPrefs.HasKey("I can do it"))
        {
            if (PlayerPrefs.GetInt("I can do it") == 1)
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

    public static void SetStudent(int value)
    {
        PlayerPrefs.SetInt("Student", value);
    }

    public static bool GetStudent()
    {
        if (PlayerPrefs.HasKey("Student"))
        {
            if (PlayerPrefs.GetInt("Student") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetMathematician(int value)
    {
        PlayerPrefs.SetInt("Mathematician", value);
    }

    public static bool GetMathematician()
    {
        if (PlayerPrefs.HasKey("Mathematician"))
        {
            if (PlayerPrefs.GetInt("Mathematician") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetGeometer(int value)
    {
        PlayerPrefs.SetInt("Geometer", value);
    }

    public static bool GetGeometer()
    {
        if (PlayerPrefs.HasKey("Geometer"))
        {
            if (PlayerPrefs.GetInt("Geometer") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetEngineer(int value)
    {
        PlayerPrefs.SetInt("Engineer", value);
    }

    public static bool GetEngineer()
    {
        if (PlayerPrefs.HasKey("Engineer"))
        {
            if (PlayerPrefs.GetInt("Engineer") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetWalker(int value)
    {
        PlayerPrefs.SetInt("Walker", value);
    }

    public static bool GetWalker()
    {
        if (PlayerPrefs.HasKey("Walker"))
        {
            if (PlayerPrefs.GetInt("Walker") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetHurried(int value)
    {
        PlayerPrefs.SetInt("Hurried", value);
    }

    public static bool GetHurried()
    {
        if (PlayerPrefs.HasKey("Hurried"))
        {
            if (PlayerPrefs.GetInt("Hurried") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetRunner(int value)
    {
        PlayerPrefs.SetInt("Runner", value);
    }

    public static bool GetRunner()
    {
        if (PlayerPrefs.HasKey("Runner"))
        {
            if (PlayerPrefs.GetInt("Runner") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetSurvivor(int value)
    {
        PlayerPrefs.SetInt("Survivor", value);
    }

    public static bool GetSurvivor()
    {
        if (PlayerPrefs.HasKey("Survivor"))
        {
            if (PlayerPrefs.GetInt("Survivor") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetTimeTraveller(int value)
    {
        PlayerPrefs.SetInt("Time Traveller", value);
    }

    public static bool GetTimeTraveller()
    {
        if (PlayerPrefs.HasKey("Time Traveller"))
        {
            if (PlayerPrefs.GetInt("Time Traveller") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetFitter(int value)
    {
        PlayerPrefs.SetInt("Fitter", value);
    }

    public static bool GetFitter()
    {
        if (PlayerPrefs.HasKey("Fitter"))
        {
            if (PlayerPrefs.GetInt("Fitter") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetBossFitter(int value)
    {
        PlayerPrefs.SetInt("Boss Fitter", value);
    }

    public static bool GetBossFitter()
    {
        if (PlayerPrefs.HasKey("Boss Fitter"))
        {
            if (PlayerPrefs.GetInt("Boss Fitter") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetBlockManager(int value)
    {
        PlayerPrefs.SetInt("Block Manager", value);
    }

    public static bool GetBlockManager()
    {
        if (PlayerPrefs.HasKey("Block Manager"))
        {
            if (PlayerPrefs.GetInt("Block Manager") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetGoodShot(int value)
    {
        PlayerPrefs.SetInt("Good Shot", value);
    }

    public static bool GetGoodShot()
    {
        if (PlayerPrefs.HasKey("Good Shot"))
        {
            if (PlayerPrefs.GetInt("Good Shot") == 1)
                return true;
        }
        
        return false;
    }

    public static void SetMasterCalculator(int value)
    {
        PlayerPrefs.SetInt("Master Calculator", value);
    }

    public static bool GetMasterCalculator()
    {
        if (PlayerPrefs.HasKey("Master Calculator"))
        {
            if (PlayerPrefs.GetInt("Master Calculator") == 1)
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
