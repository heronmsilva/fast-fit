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

    public static void PostToLeaderboard(int score)
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

    public static void ShowLeaderboardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
    }
}
