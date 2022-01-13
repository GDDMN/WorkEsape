using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class PlayerController : MonoBehaviour
    {
        private GameObject Player;
        private InputHandle Input = new InputHandle();
        private GameSceneManager _sceneManager;
        private void Awake()
        {
            Player = this.gameObject;
            _sceneManager = FindObjectOfType<GameSceneManager>();
        }

        public void PlayerControllerUpdate()
        {
            IGameState gameState = _sceneManager.GetState();
            if (gameState.GetType() == typeof(PlayState))
            {
                Command command = Input.handleInput();
                if (command != null)
                {
                    command.execute(Player);
                }
            }
        }
    }

}
