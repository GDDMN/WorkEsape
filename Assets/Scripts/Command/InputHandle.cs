using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class InputHandle : MonoBehaviour
    {
        Joystick _fixedJoystic;
        Animator _animator;
        public InputHandle(Animator animator)
        {
            _animator = animator;
        }
        public Command handleInput()
        {
            _fixedJoystic = FindObjectOfType<Joystick>();
            var vPlayerMove = new Vector2(_fixedJoystic.Horizontal, _fixedJoystic.Vertical);
            if (vPlayerMove != Vector2.zero)
                _animator.SetBool("Walk", true);
            else
                _animator.SetBool("Walk", false);

            return new Move(vPlayerMove);
        }
    }
}

