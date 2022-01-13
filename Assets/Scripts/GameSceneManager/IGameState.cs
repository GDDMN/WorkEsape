using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public interface IGameState
    {

        void Entry();
        void OnUpdate();
        void Exit();
    }
}

