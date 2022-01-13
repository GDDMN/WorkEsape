using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace PurpleDrank
{
    public class GameSceneManager : MonoBehaviour
    {
        private Dictionary<Type, IGameState> _gameStates;
        private IGameState _activeState;

        private void Awake()
        {
            InitStates();
            SetMenuState();
        }

        /************************************************************************/
        public void InitStates()
        {
            _gameStates = new Dictionary<Type, IGameState>();
            _gameStates[typeof(MenuState)] = new MenuState();
            _gameStates[typeof(PlayState)] = new PlayState();
            _gameStates[typeof(EndLevelState)] = new EndLevelState();

        }
        private void SetState(IGameState newState)
        {
            if (_activeState != null)
                _activeState.Exit();

            this._activeState = newState;
            this._activeState.Entry();
        }
        private T GetGameState<T>() where T : IGameState
        {
            var type = typeof(T);
            return (T)_gameStates[type];
        }
        public void SetMenuState()
        {
            var state = GetGameState<MenuState>();
            SetState(state);
        }
        public void SetPlayState()
        {
            var state = GetGameState<PlayState>();
            SetState(state);
        }
        public void SetEndLvlState()
        {
            var state = GetGameState<EndLevelState>();
            SetState(state);
        }
        /************************************************************************/
        public IGameState GetState()
        {
            return _activeState;
        }
    }
}

