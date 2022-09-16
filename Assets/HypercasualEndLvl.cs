using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PurpleDrank
{
    public class HypercasualEndLvl : Singleton<HypercasualEndLvl>
    {
        public Animator _endLvlAnimation;
        public Button buttonAds;
        public Image finImage;

        public void SetEndLvlTrigger()
        {
            _endLvlAnimation.SetTrigger("EndLvl");
            buttonAds.gameObject.SetActive(true);
        }
    }
}

