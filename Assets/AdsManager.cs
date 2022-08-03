using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

namespace PurpleDrank
{
    public class AdsManager : Singleton<AdsManager>
    {
        public string gameID;
        public bool testMode;

        int lvlcomplets = 0;
        private void Awake()
        {
            if(Advertisement.isSupported)
            {
                Advertisement.Initialize(gameID, testMode);
            }
        }
        public void ShowBanner()
        {

        }
        public void ShowVideoAds()
        {
            lvlcomplets++;
            if(Advertisement.IsReady() & lvlcomplets >= 3)
            {
                Advertisement.Show("video");
                lvlcomplets = 0;
            }
        }
        public void ShowReverdedVideoAds()
        {
            if(Advertisement.IsReady())
            {
                Advertisement.Show("rewardedVideo");
            }
        }
    }
}

