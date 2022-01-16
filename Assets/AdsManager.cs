using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

namespace PurpleDrank
{
    public class AdsManager : MonoBehaviour
    {
        public string gameID;
        public bool testMode;
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
            if(Advertisement.IsReady())
            {
                Advertisement.Show("video");
            }
        }

        public void ShowReverdedVideoAds()
        {

        }
    }
}

