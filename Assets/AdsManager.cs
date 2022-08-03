using UnityEngine;
using UnityEngine.Advertisements;

namespace PurpleDrank
{
    public class AdsManager : Singleton<AdsManager>
    {
        private int lvlcomplets = 0;

        [SerializeField] private string gameID;
        [SerializeField] private  bool testMode;

        private void Awake()
        {
            if(Advertisement.isSupported)
                Advertisement.Initialize(gameID, testMode);
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
                Advertisement.Show("rewardedVideo");
        }
    }
}

