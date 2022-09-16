using System;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class HypercasualPlaymodeScreen : Singleton<HypercasualPlaymodeScreen>
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private List<UIResourceLabel> _labels = new List<UIResourceLabel>();
        
        public Joystick GetJoystick() => _joystick;

        public List<UIResourceLabel> GetLabels() => _labels;
    }
}

