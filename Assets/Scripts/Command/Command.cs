using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public abstract class Command
    {
        public abstract void execute(GameObject Player);
    }
}

