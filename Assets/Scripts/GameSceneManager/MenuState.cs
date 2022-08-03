using UnityEngine;

namespace PurpleDrank
{
    public class MenuState : IGameState
    {
        private HypercasualMainMenu _mainMenu;
        private SaveGameManager _saveGameManager;

        public MenuState()
        {
            _saveGameManager = GameObject.FindObjectOfType<SaveGameManager>();
        }
        public void Entry()
        {
            Debug.Log("MenuState");
            _mainMenu = GameObject.FindObjectOfType<HypercasualMainMenu>();
        }
        public void OnUpdate()
        {

        }
        public void Exit()
        {
            _mainMenu.gameObject.SetActive(false);
            _saveGameManager.LoadGameProgress();
        }
    }
}

