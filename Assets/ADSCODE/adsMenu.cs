using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class adsMenu : MonoBehaviour
{
    private InterstitialAd interstitialAd;

    public bool close = false;
    public GameObject waitPanel;
    void Start()
    {
        this.Request();
        waitPanel.SetActive(true);
        Invoke("waiting", 3.5f);
    }
    void waiting()
    {
        waitPanel.SetActive(false);
    }

    private void Request()
    {
        string adUnitId = "ca-app-pub-1213308717099564/8653254130";

        this.interstitialAd = new InterstitialAd(adUnitId);

        this.interstitialAd.OnAdClosed += ClosedAd;

        AdRequest request = new AdRequest.Builder().Build();

        this.interstitialAd.LoadAd(request);
    }

    public void show()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            this.interstitialAd.Show();
        }
    }

    private void ClosedAd(object sender, EventArgs args)
    {
        this.Request();
        SceneManager.LoadScene(1);
    }
    private void Update()
    {

    }
}
