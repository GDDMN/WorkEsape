using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class LoseGame : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            GameSceneManager.Instance.SetLoseState();  
        }
    }
}

