using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class MoveUp : Command
    {
        public override void execute(GameObject Player)
        {
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 1.0f);
        }
    }
}

