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
        Social.ReportScore(score, GPGSIds.leaderboard_high_score, (bool success) =>
        {
            if (success)
            {
                
            }
            else
            {

            }
        });
    }

    public static void PostToRunTimeLeaderboard(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_longest_run, (bool success) =>
        {
            if (success)
            {
                
            }
            else
            {

            }
        });
    }

    public static void PostToBestStreakLeaderboard(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_best_streak, (bool success) =>
        {
            if (success)
            {
                
            }
            else
            {

            }
        });
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
}
