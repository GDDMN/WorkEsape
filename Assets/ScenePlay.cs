using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class ScenePlay : MonoBehaviour
    {
        GameSceneManager _gameSceneManager;
        PlayerController _playerController;
        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
            _gameSceneManager = FindObjectOfType<GameSceneManager>();
        }

        private void Update()
        {
            IGameState gameState = _gameSceneManager.GetState();
            if(gameState.GetType() == typeof(PlayState))
            {
                if(_playerController!= null)
                    _playerController.PlayerControllerUpdate();
            }
        }
    }
}

