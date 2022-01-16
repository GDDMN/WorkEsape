using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class LoseGame : MonoBehaviour
    {
        GameSceneManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameSceneManager>();   
        }

        private void OnCollisionEnter(Collision collision)
        {
            _gameManager.SetLoseState();  
        }
    }
}

