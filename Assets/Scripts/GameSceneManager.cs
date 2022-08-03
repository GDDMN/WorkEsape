using System.Collections.Generic;
using UnityEngine;
using System;

namespace PurpleDrank
{
    public class GameSceneManager : Singleton<GameSceneManager>
    {
        private Dictionary<Type, IGameState> _gameStates;
        private IGameState _activeState;
        private GameObject _actualScene;

        [SerializeField] private GameObject[] _gamePrefab;
        [SerializeField] private int _lvl = 0;
        [SerializeField] private bool _test;
        
        private void Awake()
        {
            InitGameScene();            
            InitStates();
            if (_test) 
                SetPlayState();
            else 
                SetMenuState();
        }

        private void Update()
        {
            _activeState.OnUpdate();
        }

        public void InitGameScene()
        {
            if(_gamePrefab.Length != 0)
            {
                if (_actualScene != null)
                    Destroy(_actualScene);

                if (_lvl >= _gamePrefab.Length)
                {
                    _lvl = 0;
                }
                _actualScene = Instantiate(_gamePrefab[_lvl], transform.position, Quaternion.identity);
                Transform sceneObject = FindObjectOfType<Scene>().transform;
                _actualScene.transform.SetParent(sceneObject);
                _actualScene.transform.position = sceneObject.position;
                _lvl++;

            }
        }

        public void RestartLvl()
        {
            if (_actualScene != null)
                Destroy(_actualScene);

            _lvl--;
            _actualScene = Instantiate(_gamePrefab[_lvl], transform.position, Quaternion.identity);
            Transform sceneObject = FindObjectOfType<Scene>().transform;
            _actualScene.transform.SetParent(sceneObject);
            _actualScene.transform.position = sceneObject.position;
            _lvl++;
        }

        /************************************************************************/
        public void InitStates()
        {
            _gameStates = new Dictionary<Type, IGameState>();
            _gameStates[typeof(MenuState)] = new MenuState();
            _gameStates[typeof(PlayState)] = new PlayState();
            _gameStates[typeof(EndLevelState)] = new EndLevelState();
            _gameStates[typeof(LoseState)] = new LoseState();

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

        public void SetLoseState()
        {
            var state = GetGameState<LoseState>();
            SetState(state);
        }
        /************************************************************************/
        public IGameState GetState()
        {
            return _activeState;
        }
    }
}

