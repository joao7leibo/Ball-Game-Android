using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class BannerAdsScript : MonoBehaviour
{
  public void Start()
  {
      // Initialize the Google Mobile Ads SDK.
      MobileAds.Initialize((InitializationStatus initStatus) =>
      {
          // This callback is called once the MobileAds SDK is initialized.
      });
      CreateBannerView();
  }
  // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
  private string _adUnitId = "ca-app-pub-5172401259017343/6231486686";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string _adUnitId = "unused";
#endif

  BannerView _bannerView;

  /// <summary>
  /// Creates a 320x50 banner at top of the screen.
  /// </summary>
  public void CreateBannerView()
  {
      Debug.Log("Creating banner view");

      // Create a 320x50 banner at top of the screen
      _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Top);
      LoadAd();
  }
  public void LoadAd()
  {
    // create an instance of a banner view first.
    if(_bannerView == null)
    {
        CreateBannerView();
    }
    // create our request used to load the ad.
    var adRequest = new AdRequest();
    adRequest.Keywords.Add("unity-admob-sample");

    // send the request to load the ad.
    Debug.Log("Loading banner ad.");
    _bannerView.LoadAd(adRequest);
  }
}