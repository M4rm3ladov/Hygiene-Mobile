using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdsManager : MonoBehaviour//, IUnityAdsListener
{
    //Action onRewardedSuccess;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4498323");
        //Advertisement.AddListener(this);
    }

    public void PlayAd(){//Action onSuccess){
        //onRewardedSuccess = onSuccess;
        //if(Advertisement.IsReady("Rewarded_Android")){
            Advertisement.Show("Rewarded_Android");
        //}else{
            //Debug.Log("Reward not ready");
        //}
    }
    /*public void OnUnityAdsReady(string placementId){
        Debug.Log("Ads Ready");
    }
    public void OnUnityAdsDidError(string message){
        Debug.Log("Error: " + message);
    }
    public void OnUnityAdsDidStart(string placementId){
        Debug.Log("Video Started");
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult){
        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished){
            onRewardedSuccess.Invoke();
        }
    }*/
}
