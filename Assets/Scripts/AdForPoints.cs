using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;

public class AdForPoints : MonoBehaviour {


    //Called when the player watches an ad in return for points
    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //If the player finishes the ad they will receive 50 extra points
                AnalyticsEvent.Custom("adWatched");
                PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("Total") + 50);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");            
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                
                break;
        }

    }

    //Whenever a player presses a button to buy the skin this method is called
    //It checks if the player has enough points and if so, updates their total,
    //Sets the PlayerPrefs skin index to the index of the skin they just purchased,
    //And sends an event that the player has just purchased an item
    public void GetSkin(int index)
    {
        if (PlayerPrefs.GetInt("Total") >= 100)
        {
            PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("Total") - 100);
            PlayerPrefs.SetInt("Skin Index", index);
            AnalyticsEvent.Custom("itemPurchased", new Dictionary<string, object>
        {
            { "points", PlayerPrefs.GetInt("Total") }
        });

        }
    }

}
