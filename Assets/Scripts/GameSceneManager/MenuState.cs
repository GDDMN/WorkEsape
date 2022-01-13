using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class MenuState : MonoBehaviour, IGameState
    {
        HypercasualMainMenu _mainMenu;
        public void Entry()
        {
            Debug.Log("MenuState");
            _mainMenu = FindObjectOfType<HypercasualMainMenu>();
        }
        public void OnUpdate()
        {

        }
        public void Exit()
        {
            _mainMenu.gameObject.SetActive(false);
        }
    }
}

