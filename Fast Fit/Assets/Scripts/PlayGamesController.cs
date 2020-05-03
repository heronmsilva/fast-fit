using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayGamesController : MonoBehaviour
{
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
                
            }
            else
            {

            }
        });
    }

    public static void PostToHighScoreLeaderboard(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_high_score, null);
    }

    public static void PostToRunTimeLeaderboard(float time)
    {
        Social.ReportScore((int) time, GPGSIds.leaderboard_longest_run, null);
    }

    public static void PostToBestStreakLeaderboard(int streak)
    {
        Social.ReportScore(streak, GPGSIds.leaderboard_best_streak, null);
    }

    public static void UnlockLevel1Achievement()
    {
        Social.ReportProgress(GPGSIds.achievement_level_1, 100f, null);
    }

    public static void UnlockLevel2Achievement()
    {
        Social.ReportProgress(GPGSIds.achievement_level_2, 100f, null);
    }

    public static void UnlockLevel3Achievement()
    {
        Social.ReportProgress(GPGSIds.achievement_level_3, 100f, null);
    }

    public static void UnlockLevel4Achievement()
    {
        Social.ReportProgress(GPGSIds.achievement_level_4, 100f, null);
    }

    public static void UnlockMaxLevelAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_max_level, 100f, null);
    }

    public static void UnlockICanDoItAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_i_can_do_it, 100f, null);
    }

    public static void UnlockImImprovingAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_im_improving, 100f, null);
    }

    public static void UnlockBlocksAreMyFriendsAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_blocks_are_my_friends, 100f, null);
    }

    public static void UnlockThisIsActuallyEasyAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_this_is_actually_easy, 100f, null);
    }

    public static void UnlockTheMasterAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_the_master, 100f, null);
    }

    public static void UnlockTheProfessionalAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_the_professional, 100f, null);
    }

    public static void UnlockRookieAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_rookie, 100f, null);
    }

    public static void UnlockStudentAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_student, 100f, null);
    }

    public static void UnlockMathematicianAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_mathematician, 100f, null);
    }

    public static void UnlockGeometerAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_geometer, 100f, null);
    }

    public static void UnlockEngineerAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_engineer, 100f, null);
    }

    public static void UnlockWalkerAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_walker, 100f, null);
    }

    public static void UnlockHurriedAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_hurried, 100f, null);
    }

    public static void UnlockRunnerAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_runner, 100f, null);
    }

    public static void UnlockSurvivorAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_survivor, 100f, null);
    }

    public static void UnlockTimeTravellerAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_time_traveller, 100f, null);
    }

    public static void UnlockFitterAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_fitter, 100f, null);
    }

    public static void UnlockBossFitterAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_boss_fitter, 100f, null);
    }

    public static void UnlockBlockManagerAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_block_manager, 100f, null);
    }

    public static void UnlockGoodShotAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_good_shot, 100f, null);
    }

    public static void UnlockMasterCalculatorAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_master_calculator, 100f, null);
    }

    public static void UnlockTheCompletionistAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_the_completionist, 100f, null);
    }

    public static void ShowHighScoreLeaderboardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
    }

    public static void ShowRunTimeLeaderboardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_longest_run);
    }

    public static void ShowBestStreakLeaderboardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_best_streak);
    }

    public static void ShowAchievementsUI()
    {
        PlayGamesPlatform.Instance.ShowAchievementsUI();
    }
}
