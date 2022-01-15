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
            gsMan = FindObjectOfType<GameSceneManager>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            gsMan.SetEndLvlState();
        }
    }
}

