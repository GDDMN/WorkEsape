using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class PlayState : MonoBehaviour, IGameState
    {
        private Joystick fixedJoystick;
        private PlayerController _playerController;
        private List<EnemyController> _enemys = new List<EnemyController>();
        private FieldOfView fieldOfViews;
        private GameSceneManager _gameSceneManager;
        private MashBuilder _ground;

        UIResourceLabel[] _allLabels;

        public PlayState()
        {
            
        }
        public void Entry()
        {

            _ground = FindObjectOfType<MashBuilder>();
            _ground.Initialize();

            _allLabels = FindObjectsOfType<UIResourceLabel>();

            foreach (var lable in _allLabels)
                lable.UpdateUI();

            foreach (var enemy in FindObjectsOfType<EnemyController>())
            {
                enemy.Initiailize();
                _enemys.Add(enemy);
            }

            fieldOfViews = FindObjectOfType<FieldOfView>();
            _playerController = FindObjectOfType<PlayerController>();
            _gameSceneManager = FindObjectOfType<GameSceneManager>();
            fixedJoystick = _playerController._fixedJoystick;
            fixedJoystick.gameObject.SetActive(true);
            Debug.Log("PlayState");
            
        }
        public void OnUpdate()
        {
            foreach (var enemy in _enemys)
                enemy.OnUpdate();

            if (fieldOfViews != null)
            {
                fieldOfViews.DrawFieldOfView();
                fieldOfViews.FindVisiableTargets();
            }
                
            if (_playerController!= null)
                _playerController.PlayerControllerUpdate();
        }
        public void Exit()
        {
            fixedJoystick.gameObject.SetActive(false);
            Destroy(fixedJoystick.gameObject);
        }
    }
}
