using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class PlayState : MonoBehaviour, IGameState
    {
        Joystick fixedJoystick;
        PlayerController _playerController;
        GameSceneManager _gameSceneManager;

        UIResourceLabel[] _allLabels;

        public PlayState()
        {
            
        }
        public void Entry()
        {
            _allLabels = FindObjectsOfType<UIResourceLabel>();
            foreach (var lable in _allLabels)
            {
                lable.UpdateUI();
            }
            
            _playerController = FindObjectOfType<PlayerController>();
            _gameSceneManager = FindObjectOfType<GameSceneManager>();
            fixedJoystick = _playerController._fixedJoystick;
            fixedJoystick.gameObject.SetActive(true);
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
            Destroy(fixedJoystick.gameObject);
        }
    }
}
