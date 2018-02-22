using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour {


	private BannerView bannerView;

	// Use this for initialization
	public void Start()
	{
		
		string appId = "ca-app-pub-6666466886819761~6804495357";


		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(appId);

		this.RequestBanner ();
	}
	
	private void RequestBanner()
	{
		
		string adUnitId = "ca-app-pub-6666466886819761/9318978055";
	
		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();

		// Load the banner with the request.
		bannerView.LoadAd(request);
	}

	public void ShowBanner(){


	}

	public void RequestInter(){

		string adUnitId = "ca-app-pub-6666466886819761/3300364611";

	}

	public void ShowInter(){


	}


}
