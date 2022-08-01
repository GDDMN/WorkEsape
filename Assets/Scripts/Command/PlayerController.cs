﻿using UnityEngine;

namespace PurpleDrank
{
    public class PlayerController : MonoBehaviour
    {
        public Joystick _fixedJoystick;
        public Animator animator;

        public GameObject CameraPlay;
        public GameObject CameraWin;

        public GameObject human;
        public GameObject thing;
        public ParticleSystem explosion;

        private GameObject Player;
        public InputHandle input;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            CameraPlay.SetActive(true);
            CameraWin.SetActive(false);
            input = new InputHandle(animator, human, thing, explosion);
            _fixedJoystick = Instantiate(_fixedJoystick, _fixedJoystick.transform.position, Quaternion.identity);
            _fixedJoystick.transform.SetParent(FindObjectOfType<Canvas>().transform);
            _fixedJoystick.gameObject.SetActive(false);
            Player = this.gameObject;
        }

        public void PlayerControllerUpdate()
        {
            Command command = input.handleInput();
            if (command != null)
            {
                command.execute(Player);
            }
        }

        public void Win()
        {
            CameraPlay.SetActive(false);
            CameraWin.SetActive(true);
        }
    }

}
