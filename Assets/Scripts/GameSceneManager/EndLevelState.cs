using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class EndLevelState : MonoBehaviour, IGameState
    {
        HypercasualEndLvl _endLvlUI;
        public void Entry()
        {
            _endLvlUI = FindObjectOfType<HypercasualEndLvl>();
            _endLvlUI.gameObject.SetActive(true);
            _endLvlUI.SetEndLvlTrigger();
        }
        public void OnUpdate()
        {

        }
        public void Exit()
        {

            _endLvlUI.gameObject.SetActive(false);
        }
    }
}
