using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class PlayerController : MonoBehaviour
    {
        public Joystick _fixedJoystick;
        public Animator animator;

        public GameObject CameraPlay;
        public GameObject CameraWin;
        
        private GameObject Player;
        private InputHandle input;

        public void Awake()
        {
            CameraPlay.SetActive(true);
            CameraWin.SetActive(false);
            input = new InputHandle(animator);
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
