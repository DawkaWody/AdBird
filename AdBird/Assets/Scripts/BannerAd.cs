using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    public static BannerAd Instance { get; private set; }

    BannerPosition _bannerPosition = BannerPosition.TOP_CENTER;
    string _androidAdUnitId = "Banner_Android";
    string _iOsAdUnitId = "Banner_iOS";
    string _adUnitId;

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
        _adUnitId = _androidAdUnitId;
#elif UNITY_EDITOR
        _adUnitId = _androidAdUnitId;
#endif
        Advertisement.Banner.SetPosition(_bannerPosition);
    }

    public void LoadAndShow()
    {
        if (Advertisement.isSupported)
        {
            BannerLoadOptions options = new BannerLoadOptions
            {
                errorCallback = OnBannerError
            };
            Advertisement.Banner.Load(_adUnitId, options);
            Advertisement.Banner.Show(_adUnitId);
        }
    }

    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }
}
