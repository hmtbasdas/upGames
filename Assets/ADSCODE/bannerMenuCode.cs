using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class bannerMenuCode : MonoBehaviour
{
    private BannerView bannerView;
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
    }
    private void RequestBanner()
    {
        this.bannerView = new BannerView("ca-app-pub-1213308717099564/1807632427", AdSize.IABBanner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);
    }
}
