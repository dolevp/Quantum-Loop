using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour {


	private BannerView bannerView;
	private InterstitialAd interstitial;

	// Use this for initialization
	public void Start()
	{

		DontDestroyOnLoad (gameObject);
		
		string appId = "ca-app-pub-6666466886819761~6804495357";


		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(appId);

		this.RequestBanner ();
		this.RequestInter ();
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

	private void RequestInter(){

		string adUnitId = "ca-app-pub-6666466886819761/3300364611";

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);

	}

	public void ShowInter(){

		Invoke ("PrivateShowInter", 1.6f);

	}

	public void PrivateShowInter(){

		if (interstitial.IsLoaded()) {
			interstitial.Show();
		}

		this.RequestInter ();


	}






}
