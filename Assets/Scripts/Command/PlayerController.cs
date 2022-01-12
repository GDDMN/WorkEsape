using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class PlayerController : MonoBehaviour
    {
        private GameObject Player;
        private InputHandle Input = new InputHandle();
        private void Awake()
        {
            Player = this.gameObject;
        }

        private void Update()
        {
            Command command = Input.handleInput();
            if (command != null)
            {
                command.execute(Player);
            }
        }
    }

}
