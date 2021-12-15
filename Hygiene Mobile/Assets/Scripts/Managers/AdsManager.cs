using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using System;

public class AdsManager : MonoBehaviour
{
    private string buttonType;
    public string ButtonType{ get{ return buttonType; } set { buttonType = value; } }
    private RewardedAd rewardedAd;
    private string rewardedAd_Id;
    void Start(){
        rewardedAd_Id = "ca-app-pub-3940256099942544/5224354917";

        MobileAds.Initialize(initStatus => {});

        RequestRewardedAd();
    }
    private void RequestRewardedAd(){
        rewardedAd = new RewardedAd(rewardedAd_Id);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }
    public void ShowRewardedAd(){
        if(rewardedAd.IsLoaded()){
            rewardedAd.Show();
        }
    }
    public void HandleOnAdLoaded(object sender, EventArgs args){
        Debug.Log("loaded: ");
    }
    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args){
        RequestRewardedAd();
    }
    public void HandleRewardedAdClosed(object sender, EventArgs args){
        RequestRewardedAd();
    }
    public void HandleUserEarnedReward(object sender, Reward args){
        if(buttonType == "CatchExtra")
            MenuManager.instance.ContinueWithOneLife();
        else if(buttonType == "CatchDouble")
            MenuManager.instance.DoubleCoins();
    }
}
