using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class SaveGameManager : MonoBehaviour
    {
        ResourceManager _resManager;
        public ResourceInfo[] _allRes;

        private void Awake()
        {
            _resManager = FindObjectOfType<ResourceManager>();
            for(int i=0;i<_resManager.resources.Count;i++)
            {
                var res = _resManager.resources[(ResourceType)i];
                _allRes[i] = res;
            }
        }

        public void SaveGameProgress()
        {
            for(int i=0;i < _allRes.Length; i++)
            {
                PlayerPrefs.SetInt(_allRes[i].name, _allRes[i].current);
            }
        }

        public void LoadGameProgress()
        {
            foreach(var res in _resManager.resources.Values)
            {
                res.current = PlayerPrefs.GetInt(res.name);
            }
        }
    }
}

