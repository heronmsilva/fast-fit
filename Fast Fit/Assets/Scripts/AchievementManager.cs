using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private int achieve1Score = 5000;
    [SerializeField] private int achieve2Score = 25000;
    [SerializeField] private int achieve3Score = 50000;
    [SerializeField] private int achieve4Score = 100000;
    [SerializeField] private int achieve5Score = 175000;
    [SerializeField] private int achieve6Score = 250000;

    [SerializeField] private int achieve1Streak = 7;
    [SerializeField] private int achieve2Streak = 25;
    [SerializeField] private int achieve3Streak = 55;
    [SerializeField] private int achieve4Streak = 100;
    [SerializeField] private int achieve5Streak = 175;

    [SerializeField] private float achieve1Time = 60;
    [SerializeField] private float achieve2Time = 120;
    [SerializeField] private float achieve3Time = 240;
    [SerializeField] private float achieve4Time = 390;
    [SerializeField] private float achieve5Time = 600;

    [SerializeField] private float achieve1Fits = 15;
    [SerializeField] private float achieve2Fits = 35;
    [SerializeField] private float achieve3Fits = 70;
    [SerializeField] private float achieve4Fits = 150;
    [SerializeField] private float achieve5Fits = 250;

    public void UpdateAchievements()
    {
        UpdateScoreAchievements();
        UpdateStreakAchievements();
        UpdateTimeAchievements();
        UpdateFitsAchievements();
        UpdateTheCompletionist();
    }

    public void UpdateLevel1Achievement()
    {
        if (! Achievements.GetLevel1())
        {
            Achievements.SetLevel1(1);
            PlayGamesController.UnlockLevel1Achievement();
        }
    }

    public void UpdateLevel2Achievement()
    {
        if (! Achievements.GetLevel2())
        {
            Achievements.SetLevel2(1);
            PlayGamesController.UnlockLevel2Achievement();
        }
    }

    public void UpdateLevel3Achievement()
    {
        if (! Achievements.GetLevel3())
        {
            Achievements.SetLevel3(1);
            PlayGamesController.UnlockLevel3Achievement();
        }
    }

    public void UpdateLevel4Achievement()
    {
        if (! Achievements.GetLevel4())
        {
            Achievements.SetLevel4(1);
            PlayGamesController.UnlockLevel4Achievement();
        }
    }

    public void UpdateMaxLevelAchievement()
    {
        if (! Achievements.GetMaxLevel())
        {
            Achievements.SetMaxLevel(1);
            PlayGamesController.UnlockMaxLevelAchievement();
        }
    }

    public void UpdateScoreAchievements()
    {
        if (! Achievements.GetICanDoIt() && PlayerPrefManager.GetLastScore() >= achieve1Score)
        {
            Achievements.SetICanDoIt(1);
            PlayGamesController.UnlockICanDoItAchievement();
        }

        if (! Achievements.GetImImproving() && PlayerPrefManager.GetLastScore() >= achieve2Score)
        {
            Achievements.SetImImproving(1);
            PlayGamesController.UnlockImImprovingAchievement();
        }

        if (! Achievements.GetBlocksAreMyFriend() && PlayerPrefManager.GetLastScore() >= achieve3Score)
        {
            Achievements.SetBlocksAreMyFriend(1);
            PlayGamesController.UnlockBlocksAreMyFriendsAchievement();
        }

        if (! Achievements.GetThisIsActuallyEasy() && PlayerPrefManager.GetLastScore() >= achieve4Score)
        {
            Achievements.SetThisIsActuallyEasy(1);
            PlayGamesController.UnlockThisIsActuallyEasyAchievement();
        }

        if (! Achievements.GetTheMaster() && PlayerPrefManager.GetLastScore() >= achieve5Score)
        {
            Achievements.SetTheMaster(1);
            PlayGamesController.UnlockTheMasterAchievement();
        }

        if (! Achievements.GetTheProfessional() && PlayerPrefManager.GetLastScore() >= achieve6Score)
        {
            Achievements.SetTheProfessional(1);
            PlayGamesController.UnlockTheProfessionalAchievement();
        }
    }

    public void UpdateStreakAchievements()
    {
        if (! Achievements.GetRookie() && PlayerPrefManager.GetLastStreak() >= achieve1Streak)
        {
            Achievements.SetRookie(1);
            PlayGamesController.UnlockRookieAchievement();
        }

        if (! Achievements.GetStudent() && PlayerPrefManager.GetLastStreak() >= achieve2Streak)
        {
            Achievements.SetStudent(1);
            PlayGamesController.UnlockStudentAchievement();
        }

        if (! Achievements.GetMathematician() && PlayerPrefManager.GetLastStreak() >= achieve3Streak)
        {
            Achievements.SetMathematician(1);
            PlayGamesController.UnlockMathematicianAchievement();
        }

        if (! Achievements.GetGeometer() && PlayerPrefManager.GetLastStreak() >= achieve4Streak)
        {
            Achievements.SetGeometer(1);
            PlayGamesController.UnlockGeometerAchievement();
        }

        if (! Achievements.GetEngineer() && PlayerPrefManager.GetLastStreak() >= achieve5Streak)
        {
            Achievements.SetEngineer(1);
            PlayGamesController.UnlockEngineerAchievement();
        }
    }

    public void UpdateTimeAchievements()
    {
        if (! Achievements.GetWalker() && PlayerPrefManager.GetLastTime() >= achieve1Time)
        {
            Achievements.SetWalker(1);
            PlayGamesController.UnlockWalkerAchievement();
        }

        if (! Achievements.GetHurried() && PlayerPrefManager.GetLastTime() >= achieve2Time)
        {
            Achievements.SetHurried(1);
            PlayGamesController.UnlockHurriedAchievement();
        }

        if (! Achievements.GetRunner() && PlayerPrefManager.GetLastTime() >= achieve3Time)
        {
            Achievements.SetRunner(1);
            PlayGamesController.UnlockRunnerAchievement();
        }

        if (! Achievements.GetSurvivor() && PlayerPrefManager.GetLastTime() >= achieve4Time)
        {
            Achievements.SetSurvivor(1);
            PlayGamesController.UnlockSurvivorAchievement();
        }

        if (! Achievements.GetTimeTraveller() && PlayerPrefManager.GetLastTime() >= achieve5Time)
        {
            Achievements.SetTimeTraveller(1);
            PlayGamesController.UnlockTimeTravellerAchievement();
        }
    }

    public void UpdateFitsAchievements()
    {
        if (! Achievements.GetFitter() && PlayerPrefManager.GetLastFits() >= achieve1Fits)
        {
            Achievements.SetFitter(1);
            PlayGamesController.UnlockFitterAchievement();
        }

        if (! Achievements.GetBossFitter() && PlayerPrefManager.GetLastFits() >= achieve2Fits)
        {
            Achievements.SetBossFitter(1);
            PlayGamesController.UnlockBossFitterAchievement();
        }

        if (! Achievements.GetBlockManager() && PlayerPrefManager.GetLastFits() >= achieve3Fits)
        {
            Achievements.SetBlockManager(1);
            PlayGamesController.UnlockBlockManagerAchievement();
        }

        if (! Achievements.GetGoodShot() && PlayerPrefManager.GetLastFits() >= achieve4Fits)
        {
            Achievements.SetGoodShot(1);
            PlayGamesController.UnlockGoodShotAchievement();
        }

        if (! Achievements.GetMasterCalculator() && PlayerPrefManager.GetLastFits() >= achieve5Fits)
        {
            Achievements.SetMasterCalculator(1);
            PlayGamesController.UnlockMasterCalculatorAchievement();
        }
    }

    public void UpdateTheCompletionist()
    {
        if (Achievements.GetTheCompletionist()) return;

        if (Achievements.GetLevel1()
        && Achievements.GetLevel2()
        && Achievements.GetLevel3()
        && Achievements.GetLevel4()
        && Achievements.GetMaxLevel()
        && Achievements.GetICanDoIt()
        && Achievements.GetBlocksAreMyFriend()
        && Achievements.GetImImproving()
        && Achievements.GetThisIsActuallyEasy()
        && Achievements.GetTheMaster()
        && Achievements.GetTheProfessional()
        && Achievements.GetRookie()
        && Achievements.GetStudent()
        && Achievements.GetMathematician()
        && Achievements.GetGeometer()
        && Achievements.GetEngineer()
        && Achievements.GetWalker()
        && Achievements.GetHurried()
        && Achievements.GetRunner()
        && Achievements.GetSurvivor()
        && Achievements.GetTimeTraveller()
        && Achievements.GetFitter()
        && Achievements.GetBossFitter()
        && Achievements.GetBlockManager()
        && Achievements.GetGoodShot()
        && Achievements.GetMasterCalculator())
        {
            Achievements.SetTheCompletionist(1);
            PlayGamesController.UnlockTheCompletionistAchievement();
        }
    }
}
