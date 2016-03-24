using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{

	public void CreateAdBanner()
    {
        BannerView bannerView = new BannerView("ca-app-pub-2928229545764146/7802988518", AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }
}
