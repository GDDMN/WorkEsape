using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class PlayState : MonoBehaviour, IGameState
    {
        FixedJoystick fixedJoystick;
        PlayerController _playerController;
        GameSceneManager _gameSceneManager;

        UIResourceLabel[] _allLabels;

        public PlayState()
        {
            _allLabels = FindObjectsOfType<UIResourceLabel>();
            fixedJoystick = FindObjectOfType<FixedJoystick>();
        }
        public void Entry()
        {
            foreach(var lable in _allLabels)
            {
                lable.UpdateUI();
            }

            fixedJoystick.gameObject.SetActive(true);
            
            _playerController = FindObjectOfType<PlayerController>();
            _gameSceneManager = FindObjectOfType<GameSceneManager>();
            Debug.Log("PlayState");
            
        }
        public void OnUpdate()
        {
            if(_playerController!= null)
                _playerController.PlayerControllerUpdate();
        }
        public void Exit()
        {
            fixedJoystick.gameObject.SetActive(false);
        }
    }
}
