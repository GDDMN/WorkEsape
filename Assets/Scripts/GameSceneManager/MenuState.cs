using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class MenuState : MonoBehaviour, IGameState
    {
        FixedJoystick fixedJoystick;
        HypercasualMainMenu _mainMenu;
        public void Entry()
        {
            fixedJoystick = FindObjectOfType<FixedJoystick>();
            fixedJoystick.gameObject.SetActive(false);
            Debug.Log("MenuState");
            _mainMenu = FindObjectOfType<HypercasualMainMenu>();
        }
        public void OnUpdate()
        {

        }
        public void Exit()
        {
            fixedJoystick.gameObject.SetActive(true);
            _mainMenu.gameObject.SetActive(false);
        }
    }
}

