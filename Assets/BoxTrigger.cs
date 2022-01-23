using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class BoxTrigger : MonoBehaviour
    {
        GameSceneManager gsMan;
        SaveGameManager _svManag;
        ResourceManager _rsManag;

        private void Awake()
        {
            _svManag = FindObjectOfType<SaveGameManager>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _svManag._allRes[(int)ResourceType.GOLD].current += 10;
            gsMan = FindObjectOfType<GameSceneManager>();
            gsMan.SetEndLvlState();
        }
    }
}

