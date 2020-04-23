using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    [SerializeField] private string iOSGameID = "3568509";
    [SerializeField] private string androidGameID = "3568508";

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

        Advertisement.Initialize(gameId, testMode);
    }
}
