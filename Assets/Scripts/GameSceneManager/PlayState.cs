using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class PlayState : IGameState
    {
        private Joystick fixedJoystick;
        private PlayerController _playerController;
        private List<EnemyController> _enemys;
        private FieldOfView fieldOfViews;
        private MashBuilder _ground;

        UIResourceLabel[] _allLabels;

        public PlayState()
        {
            
        }

        public void Entry()
        {
            InitializeGameEntitys();
            InitializeSystemEntitys();
        }

        private void InitializeGameEntitys()
        {
            _ground = GameObject.FindObjectOfType<MashBuilder>();
            _ground.Initialize();

            _playerController = GameObject.FindObjectOfType<PlayerController>();
            _playerController.Initialize();

            _enemys = new List<EnemyController>();
            foreach (var enemy in GameObject.FindObjectsOfType<EnemyController>())
            {
                enemy.Initiailize();
                _enemys.Add(enemy);
            }

            fixedJoystick = _playerController._fixedJoystick;
            fixedJoystick.gameObject.SetActive(true);
        }

        private void InitializeSystemEntitys()
        {
            _allLabels = GameObject.FindObjectsOfType<UIResourceLabel>();

            foreach (var lable in _allLabels)
                lable.UpdateUI();

            Debug.Log("PlayState");
        }

        public void OnUpdate()
        {
            foreach (var enemy in _enemys)
                enemy.OnUpdate();
    
            if (_playerController!= null)
                _playerController.PlayerControllerUpdate();
        }

        public void Exit()
        {
            foreach (var enemy in _enemys)
                GameObject.Destroy(enemy);

            _enemys.Clear();
            fixedJoystick.gameObject.SetActive(false);
            GameObject.Destroy(fixedJoystick.gameObject);
        }
    }
}
