using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class LoseState : MonoBehaviour, IGameState
    {
        HypercasualLoose _looseUI;
        PlayerController _player;
        public LoseState()
        {
            _looseUI = FindObjectOfType<HypercasualLoose>();
            
            if (_looseUI!= null) _looseUI.gameObject.SetActive(false);
        }
        public void Entry()
        {
            _player = FindObjectOfType<PlayerController>();
            _looseUI.gameObject.SetActive(true);
            _player.input.SetLose();
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

