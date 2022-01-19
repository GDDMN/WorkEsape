using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class Move : Command
    {
        Vector2 _direction;
        Rigidbody _rigidbody;
        float _moveSpeed = 3.0f;
        public Move(Vector2 direction)
        {
            
            _direction = direction;
        }
        public override void execute(GameObject Player)
        {
            _rigidbody = Player.GetComponent<Rigidbody>();
            Player.GetComponent<Rigidbody>().velocity = new Vector3(_direction.x * _moveSpeed, 0.0f, _direction.y * _moveSpeed);
            if (_direction != Vector2.zero)
            {
                Player.transform.rotation = Quaternion.LookRotation(Player.GetComponent<Rigidbody>().velocity);
            }
        }
    }
}

