using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class PlayState : MonoBehaviour, IGameState
    {
        PlayerController _playerController;
        GameSceneManager _gameSceneManager;
        public void Entry()
        {
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
            
        }
    }
}
