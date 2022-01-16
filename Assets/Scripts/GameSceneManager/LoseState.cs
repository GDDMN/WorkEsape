using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class LoseState : MonoBehaviour, IGameState
    {
        HypercasualLoose _looseUI;
        public LoseState()
        {
            _looseUI = FindObjectOfType<HypercasualLoose>();
            if(_looseUI!= null) _looseUI.gameObject.SetActive(false);
        }
        public void Entry()
        {
            _looseUI.gameObject.SetActive(true);
        }

        public void OnUpdate()
        {

        }

        public void Exit()
        {
            _looseUI.gameObject.SetActive(false);
        }
    }
}

