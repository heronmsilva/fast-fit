using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayGamesController : MonoBehaviour
{
    [SerializeField] private AchievementManager achievementManager;

    private void Start()
    {
        AuthenticateUser();
    }

    private void AuthenticateUser()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) => 
        {
            if (success == true)
            {
                PlayerPrefManager.SetIsLoggedIn(1);
                if (PlayerPrefManager.GetPlayedOffline())
                {
                    achievementManager.UpdateTopAchievements();
                    PostToHighScoreLeaderboard(PlayerPrefManager.GetTopScore());
                    PlayerPrefManager.SetPlayedOffline(0);
                }
            }
            else
            {
                PlayerPrefManager.SetIsLoggedIn(0);
                PlayerPrefManager.SetPlayedOffline(1);
            }
        });
    }

    public static void PostToHighScoreLeaderboard(int score)
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportScore(score, GPGSIds.leaderboard_high_score, null);
    }

    public static void UnlockLevel1Achievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_level_1, 100f, null);
    }

    public static void UnlockLevel2Achievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_level_2, 100f, null);
    }

    public static void UnlockLevel3Achievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_level_3, 100f, null);
    }

    public static void UnlockLevel4Achievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_level_4, 100f, null);
    }

    public static void UnlockMaxLevelAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_max_level, 100f, null);
    }

    public static void UnlockICanDoItAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_i_can_do_it, 100f, null);
    }

    public static void UnlockImImprovingAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_im_improving, 100f, null);
    }

    public static void UnlockBlocksAreMyFriendsAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_blocks_are_my_friends, 100f, null);
    }

    public static void UnlockThisIsActuallyEasyAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_this_is_actually_easy, 100f, null);
    }

    public static void UnlockTheMasterAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_the_master, 100f, null);
    }

    public static void UnlockTheProfessionalAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_the_professional, 100f, null);
    }

    public static void UnlockRookieAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_rookie, 100f, null);
    }

    public static void UnlockStudentAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_student, 100f, null);
    }

    public static void UnlockMathematicianAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_mathematician, 100f, null);
    }

    public static void UnlockGeometerAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_geometer, 100f, null);
    }

    public static void UnlockEngineerAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_engineer, 100f, null);
    }

    public static void UnlockWalkerAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_walker, 100f, null);
    }

    public static void UnlockHurriedAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_hurried, 100f, null);
    }

    public static void UnlockRunnerAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_runner, 100f, null);
    }

    public static void UnlockSurvivorAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_survivor, 100f, null);
    }

    public static void UnlockTimeTravellerAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_time_traveller, 100f, null);
    }

    public static void UnlockFitterAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_fitter, 100f, null);
    }

    public static void UnlockBossFitterAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_boss_fitter, 100f, null);
    }

    public static void UnlockBlockManagerAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_block_manager, 100f, null);
    }

    public static void UnlockGoodShotAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_good_shot, 100f, null);
    }

    public static void UnlockMasterCalculatorAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_master_calculator, 100f, null);
    }

    public static void UnlockTheCompletionistAchievement()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        Social.ReportProgress(GPGSIds.achievement_the_completionist, 100f, null);
    }

    public static void ShowHighScoreLeaderboardUI()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
    }

    public static void ShowAchievementsUI()
    {
        if (! PlayerPrefManager.GetIsLoggedIn()) return;
        
        PlayGamesPlatform.Instance.ShowAchievementsUI();
    }
}
