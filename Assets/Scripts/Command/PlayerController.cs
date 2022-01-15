using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class PlayerController : MonoBehaviour
    {
        private GameObject Player;
        private InputHandle Input = new InputHandle();

        public void Awake()
        {

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
