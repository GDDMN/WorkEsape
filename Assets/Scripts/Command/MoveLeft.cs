using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class MoveLeft : Command
    {
        public override void execute(GameObject Player)
        {
            Player.GetComponent<Rigidbody>().velocity = new Vector3(-1.0f, 0.0f, 0.0f);
        }
    }
}
