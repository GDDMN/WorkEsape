using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class Move : Command
    {
        Vector2 _direction;
        public Move(Vector2 direction)
        {
            _direction = direction;
        }
        public override void execute(GameObject Player)
        {
            Player.GetComponent<Rigidbody>().velocity = new Vector3(_direction.x, 0.0f, _direction.y) ;
        }
    }
}

