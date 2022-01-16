using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PurpleDrank
{
    public class UIResourceLabel : MonoBehaviour
    {
        ResourceManager _resManager;

        [HideInInspector]
        public Text resourceCount;
        [HideInInspector]
        public Image resourceImage;

        public ResourceType resourceType;

        private void Awake()
        {
            
        }

        public void UpdateUI()
        {
            _resManager = FindObjectOfType<ResourceManager>();
            foreach (var res in _resManager.resources)
            {
                if (res.Key == resourceType)
                {
                    resourceCount.text = res.Value.current.ToString();
                    resourceImage.sprite = res.Value.icon;

                    break;
                }
            }
        }
    }
}

