
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using UnityEditor;

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
    public class ResourceInfo
    {
        public Sprite icon;
        public int current;
        public string name;
    }

    public class SerializableDictionary<TK, TV> : Dictionary<TK, TV>, ISerializationCallbackReceiver
    {
        [SerializeField] public List<TK> _keys = new List<TK>();
        [SerializeField] public List<TV> _value = new List<TV>();

        public void OnAfterDeserialize()
        {
            this.Clear();
            for (int i = 0; i != Math.Min(_keys.Count, _value.Count); i++)
            {
                this[this._keys[i]] = this._value[i];
            }
        }

        public void OnBeforeSerialize()
        {
            this._keys.Clear();
            this._value.Clear();
            foreach (var kvp in this)
            {
                this._keys.Add(kvp.Key);
                this._value.Add(kvp.Value);
            }
        }
    }

    [Serializable]
    public class ResourceItem : SerializableDictionary<ResourceType, ResourceInfo>
    {

    }
}

