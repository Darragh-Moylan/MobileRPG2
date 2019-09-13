using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {

    public void ShowRewardedAd()
    {
        Debug.Log("Showing Rewarded Ad");


        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    void HandleShowResult(ShowResult result)
    {

        switch (result)
        {
            case ShowResult.Finished: // award
                GameManager.Instance.Player.AddGems(100);
                UIManager.Instance.OpenShop(GameManager.Instance.Player.diamonds);
                Debug.Log("You Finished the ad, here's 100G");
                break;
            case ShowResult.Skipped:
                Debug.Log("You skipped the ad, no gems for you!");
                break;
            case ShowResult.Failed:
                Debug.Log("The video failed, please try again!");
                break;
        }
    }

}
