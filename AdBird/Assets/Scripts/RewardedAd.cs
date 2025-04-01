using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static RewardedAd Instance { get; private set; }

    private string _androidAdUnitId = "Rewarded_Android";
    private string _iOSAdUnitId = "Rewarded_iOS";
    private string _adUnitId;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId
#elif UNITY_EDITOR
        _adUnitId = _androidAdUnitId; //Only for testing the functionality in the Editor
#endif
    }

    public void LoadAndShow()
    {
        if (Advertisement.isSupported)
        {
            Time.timeScale = 0;
            Debug.Log("Loading ad " + _adUnitId);
            Advertisement.Load(_adUnitId, this);
        }
    }

    public void ShowRewardedAd()
    {
        Advertisement.Show(_adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (_adUnitId.Equals(placementId)) ShowRewardedAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {placementId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (!(placementId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED)))
            Application.Quit();
        Time.timeScale = 1;
    }
}
