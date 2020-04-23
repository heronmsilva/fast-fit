using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private string iOSGameID = "3568509";
    [SerializeField] private string androidGameID = "3568508";
    [SerializeField] private string nonRewardedPID = "video";
    [SerializeField] private string rewardedPID = "rewardedVideo";
    [SerializeField] private string bannerPID = "banner";

    private string gameId;
    private bool testMode = true;

    private void Start()
    {
        #if UNITY_IOS
            gameId = iOSGameID;
        #endif
        #if UNITY_ANDROID
            gameId = androidGameID;
        #endif

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

        Advertisement.Show(placementId);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId != rewardedPID) return;

        switch (showResult)
        {
            case ShowResult.Finished:
                // REWARD
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId) {}
    public void OnUnityAdsReady(string placementId) {}
    public void OnUnityAdsDidError(string placementId) {}
}
