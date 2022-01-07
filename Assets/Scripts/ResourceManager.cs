using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace PurpleDrank
{
    public enum ResourceType
    {
        GOLD,
        DIAMOND,
        STAR,
        KEY_GOLD,
        KEY_SILVER,
        RUBY
    }

    [System.Serializable]
    public struct ResourceInfo
    {
        public ResourceType type;
        public Sprite icon;
        public int current;
        public string name;
    }

    public class ResourceManager : MonoBehaviour
    {
        public ResourceInfo[] resources = new ResourceInfo[Enum.GetValues(typeof(ResourceType)).Length];     
    }

}

