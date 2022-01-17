using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace PurpleDrank
{
    public class MusicManager : MonoBehaviour
    {
        public AudioMixerGroup Mixer;
        private bool on = true;

        public void MusicOff()
        {
            if(on)
                Mixer.audioMixer.SetFloat("MusicVolume", -80);
            else
                Mixer.audioMixer.SetFloat("MusicVolume", 0);
            on = !on;
        }


    }
}

