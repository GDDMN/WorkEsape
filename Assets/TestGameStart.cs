using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class TestGameStart : MonoBehaviour
    {
        GameSceneManager _sceneManager;
        private void Awake()
        {
            _sceneManager = FindObjectOfType<GameSceneManager>();
            _sceneManager.SetPlayState();
        }
    }
}

