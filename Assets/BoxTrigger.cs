using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class BoxTrigger : MonoBehaviour
    {
        GameSceneManager gsMan;

        private void Awake()
        {
            
        }
        private void OnCollisionEnter(Collision collision)
        {
            gsMan = FindObjectOfType<GameSceneManager>();
            gsMan.SetEndLvlState();
        }
    }
}

