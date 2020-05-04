using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private int achieve1Score = 25000;
    [SerializeField] private int achieve2Score = 100000;
    [SerializeField] private int achieve3Score = 350000;
    [SerializeField] private int achieve4Score = 750000;
    [SerializeField] private int achieve5Score = 5000000;
    [SerializeField] private int achieve6Score = 12000000;

    [SerializeField] private int achieve1Streak = 10;
    [SerializeField] private int achieve2Streak = 25;
    [SerializeField] private int achieve3Streak = 60;
    [SerializeField] private int achieve4Streak = 100;
    [SerializeField] private int achieve5Streak = 200;

    [SerializeField] private float achieve1Time = 60;
    [SerializeField] private float achieve2Time = 120;
    [SerializeField] private float achieve3Time = 240;
    [SerializeField] private float achieve4Time = 540;
    [SerializeField] private float achieve5Time = 900;

    [SerializeField] private float achieve1Fits = 15;
    [SerializeField] private float achieve2Fits = 40;
    [SerializeField] private float achieve3Fits = 85;
    [SerializeField] private float achieve4Fits = 150;
    [SerializeField] private float achieve5Fits = 250;

    public void UpdateAchievements()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;

        UpdateScoreAchievements(PlayerPrefManager.GetLastScore());
        UpdateStreakAchievements(PlayerPrefManager.GetLastStreak());
        UpdateTimeAchievements(PlayerPrefManager.GetLastTime());
        UpdateFitsAchievements(PlayerPrefManager.GetLastFits());

        UpdateTheCompletionist();
    }

    public void UpdateTopAchievements()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;

        UpdateScoreAchievements(PlayerPrefManager.GetTopScore());
        UpdateStreakAchievements(PlayerPrefManager.GetTopStreak());
        UpdateTimeAchievements(PlayerPrefManager.GetTopTime());
        UpdateFitsAchievements(PlayerPrefManager.GetTopFits());

        UpdateTheCompletionist();
    }

    public void UpdateLevel1Achievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;

        if (! Achievements.GetLevel1())
        {
            Achievements.SetLevel1(1);
            PlayGamesController.UnlockLevel1Achievement();
        }
    }

    public void UpdateLevel2Achievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;

        if (! Achievements.GetLevel2())
        {
            Achievements.SetLevel2(1);
            PlayGamesController.UnlockLevel2Achievement();
        }
    }

    public void UpdateLevel3Achievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;

        if (! Achievements.GetLevel3())
        {
            Achievements.SetLevel3(1);
            PlayGamesController.UnlockLevel3Achievement();
        }
    }

    public void UpdateLevel4Achievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;

        if (! Achievements.GetLevel4())
        {
            Achievements.SetLevel4(1);
            PlayGamesController.UnlockLevel4Achievement();
        }
    }

    public void UpdateMaxLevelAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;

        if (! Achievements.GetMaxLevel())
        {
            Achievements.SetMaxLevel(1);
            PlayGamesController.UnlockMaxLevelAchievement();
        }
    }

    public void UpdateScoreAchievements(int score)
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;

        if (! Achievements.GetICanDoIt() && score >= achieve1Score)
        {
            Achievements.SetICanDoIt(1);
            PlayGamesController.UnlockICanDoItAchievement();
        }

        if (! Achievements.GetImImproving() && score >= achieve2Score)
        {
            Achievements.SetImImproving(1);
            PlayGamesController.UnlockImImprovingAchievement();
        }

        if (! Achievements.GetBlocksAreMyFriend() && score >= achieve3Score)
        {
            Achievements.SetBlocksAreMyFriend(1);
            PlayGamesController.UnlockBlocksAreMyFriendsAchievement();
        }

        if (! Achievements.GetThisIsActuallyEasy() && score >= achieve4Score)
        {
            Achievements.SetThisIsActuallyEasy(1);
            PlayGamesController.UnlockThisIsActuallyEasyAchievement();
        }

        if (! Achievements.GetTheMaster() && score >= achieve5Score)
        {
            Achievements.SetTheMaster(1);
            PlayGamesController.UnlockTheMasterAchievement();
        }

        if (! Achievements.GetTheProfessional() && score >= achieve6Score)
        {
            Achievements.SetTheProfessional(1);
            PlayGamesController.UnlockTheProfessionalAchievement();
        }
    }

    public void UpdateStreakAchievements(int streak)
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;

        if (! Achievements.GetRookie() && streak >= achieve1Streak)
        {
            Achievements.SetRookie(1);
            PlayGamesController.UnlockRookieAchievement();
        }

        if (! Achievements.GetStudent() && streak >= achieve2Streak)
        {
            Achievements.SetStudent(1);
            PlayGamesController.UnlockStudentAchievement();
        }

        if (! Achievements.GetMathematician() && streak >= achieve3Streak)
        {
            Achievements.SetMathematician(1);
            PlayGamesController.UnlockMathematicianAchievement();
        }

        if (! Achievements.GetGeometer() && streak >= achieve4Streak)
        {
            Achievements.SetGeometer(1);
            PlayGamesController.UnlockGeometerAchievement();
        }

        if (! Achievements.GetEngineer() && streak >= achieve5Streak)
        {
            Achievements.SetEngineer(1);
            PlayGamesController.UnlockEngineerAchievement();
        }
    }

    public void UpdateTimeAchievements(float time)
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;

        if (! Achievements.GetWalker() && time >= achieve1Time)
        {
            Achievements.SetWalker(1);
            PlayGamesController.UnlockWalkerAchievement();
        }

        if (! Achievements.GetHurried() && time >= achieve2Time)
        {
            Achievements.SetHurried(1);
            PlayGamesController.UnlockHurriedAchievement();
        }

        if (! Achievements.GetRunner() && time >= achieve3Time)
        {
            Achievements.SetRunner(1);
            PlayGamesController.UnlockRunnerAchievement();
        }

        if (! Achievements.GetSurvivor() && time >= achieve4Time)
        {
            Achievements.SetSurvivor(1);
            PlayGamesController.UnlockSurvivorAchievement();
        }

        if (! Achievements.GetTimeTraveller() && time >= achieve5Time)
        {
            Achievements.SetTimeTraveller(1);
            PlayGamesController.UnlockTimeTravellerAchievement();
        }
    }

    public void UpdateFitsAchievements(int fits)
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;

        if (! Achievements.GetFitter() && fits >= achieve1Fits)
        {
            Achievements.SetFitter(1);
            PlayGamesController.UnlockFitterAchievement();
        }

        if (! Achievements.GetBossFitter() && fits >= achieve2Fits)
        {
            Achievements.SetBossFitter(1);
            PlayGamesController.UnlockBossFitterAchievement();
        }

        if (! Achievements.GetBlockManager() && fits >= achieve3Fits)
        {
            Achievements.SetBlockManager(1);
            PlayGamesController.UnlockBlockManagerAchievement();
        }

        if (! Achievements.GetGoodShot() && fits >= achieve4Fits)
        {
            Achievements.SetGoodShot(1);
            PlayGamesController.UnlockGoodShotAchievement();
        }

        if (! Achievements.GetMasterCalculator() && fits >= achieve5Fits)
        {
            Achievements.SetMasterCalculator(1);
            PlayGamesController.UnlockMasterCalculatorAchievement();
        }
    }

    public void UpdateTheCompletionist()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()|| Achievements.GetTheCompletionist()) return;

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
