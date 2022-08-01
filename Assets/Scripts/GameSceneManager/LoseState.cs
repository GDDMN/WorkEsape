using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class LoseState : IGameState
    {
        HypercasualLoose _looseUI;
        PlayerController _player;
        public LoseState()
        {
            _looseUI = GameObject.FindObjectOfType<HypercasualLoose>();
            
            if (_looseUI!= null) _looseUI.gameObject.SetActive(false);
        }
        public void Entry()
        {
            _player = GameObject.FindObjectOfType<PlayerController>();
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

