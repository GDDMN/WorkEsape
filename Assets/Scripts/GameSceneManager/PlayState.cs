using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class PlayState : IGameState
    {
        private Joystick _fixedJoystick;
        private PlayerController _playerController;
        private List<EnemyController> _enemys = new List<EnemyController>();
        private MeshBuilder _ground;

        private UIResourceLabel[] _allLabels;

        public PlayState()
        {
            
        }
        public void Entry()
        {
            _ground = GameObject.FindObjectOfType<MeshBuilder>();
            _ground.Initialize();

            foreach (var enemy in _enemys)
                enemy.Initiailize();

            _allLabels = GameObject.FindObjectsOfType<UIResourceLabel>();

            foreach (var lable in _allLabels)
                lable.UpdateUI();

            foreach (var enemy in GameObject.FindObjectsOfType<EnemyController>())
            {
                enemy.Initiailize();
                _enemys.Add(enemy);
            }


            _playerController = GameObject.FindObjectOfType<PlayerController>();
            _fixedJoystick = _playerController.GetJoystick;
            _fixedJoystick.gameObject.SetActive(true);
            Debug.Log("PlayState");
            
        }
        public void OnUpdate()
        {
                
            if (_playerController!= null)
                _playerController.PlayerControllerUpdate();
        }
        public void Exit()
        {
            foreach (var enemy in _enemys)
                GameObject.Destroy(enemy);

            _enemys.Clear();
            _fixedJoystick.gameObject.SetActive(false);
            GameObject.Destroy(_fixedJoystick.gameObject);
        }
    }
}
