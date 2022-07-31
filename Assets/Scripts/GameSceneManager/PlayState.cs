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

            _ground = GameObject.FindObjectOfType<MashBuilder>();
            _ground.Initialize();

            _allLabels = GameObject.FindObjectsOfType<UIResourceLabel>();

            foreach (var lable in _allLabels)
                lable.UpdateUI();

            _enemys = new List<EnemyController>();
            foreach (var enemy in GameObject.FindObjectsOfType<EnemyController>())
            {
                enemy.Initiailize();
                _enemys.Add(enemy);
            }

            fieldOfViews = GameObject.FindObjectOfType<FieldOfView>();
            _playerController = GameObject.FindObjectOfType<PlayerController>();
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
            _enemys.Clear();

            fixedJoystick.gameObject.SetActive(false);
            GameObject.Destroy(fixedJoystick.gameObject);
        }
    }
}
