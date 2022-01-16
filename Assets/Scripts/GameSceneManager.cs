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
        private GameObject _actualScene;

        public GameObject[] gamePrefab;
        public int Lvl = 0;
        public bool test;
        
        private void Awake()
        {
            InitGameScene();            
            InitStates();
            if (test) SetPlayState();
            else SetMenuState();
        }

        private void Update()
        {
            _activeState.OnUpdate();
        }

        public void InitGameScene()
        {
            if(gamePrefab.Length != 0)
            {
                if (_actualScene != null)
                    Destroy(_actualScene);

                if (Lvl >= gamePrefab.Length)
                {
                    Lvl = 0;
                }
                _actualScene = Instantiate(gamePrefab[Lvl], transform.position, Quaternion.identity);
                Transform sceneObject = FindObjectOfType<Scene>().transform;
                _actualScene.transform.SetParent(sceneObject);
                _actualScene.transform.position = sceneObject.position;
                Lvl++;
            }
        }

        public void RestartLvl()
        {
            if (_actualScene != null)
                Destroy(_actualScene);
            Lvl--;
            _actualScene = Instantiate(gamePrefab[Lvl], transform.position, Quaternion.identity);
            Transform sceneObject = FindObjectOfType<Scene>().transform;
            _actualScene.transform.SetParent(sceneObject);
            _actualScene.transform.position = sceneObject.position;
            Lvl++;
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

