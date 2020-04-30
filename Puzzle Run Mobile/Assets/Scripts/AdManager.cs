using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private string androidGameID = "3568508";
    [SerializeField] private string nonRewardedPID = "video";
    [SerializeField] private string rewardedPID = "rewardedVideo";
    [SerializeField] private string bannerPID = "banner";

    public bool isAdPlaying;

    private string gameId;
    private bool testMode = true;

    private void Start()
    {
        gameId = androidGameID;

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    public IEnumerator ShowBannerAd()
    {
        while (! Advertisement.IsReady(bannerPID))
            yield return null;

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(bannerPID);
    }

    public void ShowNonRewardedAd()
    {
        StartCoroutine(ShowAd(nonRewardedPID));
    }

    public void ShowRewardedAd()
    {
        StartCoroutine(ShowAd(rewardedPID));
    }

    private IEnumerator ShowAd(string placementId)
    {
        while (! Advertisement.IsReady(placementId))
            yield return null;

        isAdPlaying = true;
        Advertisement.Show(placementId);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        isAdPlaying = false;

        if (placementId != rewardedPID) return;

        switch (showResult)
        {
            case ShowResult.Finished:
                GameManager.Instance.RewardGameOver();
                break;
            case ShowResult.Skipped:
                GameManager.Instance.LoadGameOver();
                break;
            case ShowResult.Failed:
                GameManager.Instance.LoadGameOver();
                break;
            default:
                GameManager.Instance.LoadGameOver();
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId) {}
    public void OnUnityAdsReady(string placementId) {}
    public void OnUnityAdsDidError(string placementId) {}
}
