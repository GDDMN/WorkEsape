using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class PlayerController : MonoBehaviour
    {
        private GameObject Player;
        private InputHandle Input = new InputHandle();


        public FixedJoystick _fixedJoystick;

        public void Awake()
        {
            Vector3 joyPos = _fixedJoystick.transform.position;
            _fixedJoystick = Instantiate(_fixedJoystick, joyPos, Quaternion.identity);
            _fixedJoystick.transform.SetParent(FindObjectOfType<Canvas>().transform);
            Player = this.gameObject;
        }
        public void PlayerControllerUpdate()
        {
            Command command = Input.handleInput();
            if (command != null)
            {
                command.execute(Player);
            }
        }
    }

}
