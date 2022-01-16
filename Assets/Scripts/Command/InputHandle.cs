using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class InputHandle : MonoBehaviour
    {
        FixedJoystick _fixedJoystic;

        public Command handleInput()
        {
            _fixedJoystic = FindObjectOfType<FixedJoystick>();
            var vPlayerMove = _fixedJoystic.Direction;
            //Debug.Log(vPlayerMove);
            if (vPlayerMove != Vector2.zero) return new Move(vPlayerMove);
            //if (Input.GetKey(KeyCode.W)) return new MoveUp();
            //if (Input.GetKey(KeyCode.S)) return new MoveDown();
            //if (Input.GetKey(KeyCode.A)) return new MoveLeft();
            //if (Input.GetKey(KeyCode.D)) return new MoveRight();
            return new NullCommand();
        }
    }
}

