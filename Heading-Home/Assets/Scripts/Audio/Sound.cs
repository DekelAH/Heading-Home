using UnityEngine.Audio;
using UnityEngine;
using System;

namespace Assets.Scripts.Audio
{
    [Serializable]
    public class Sound
    {
        #region Properties

        public string Name;

        public AudioClip Clip;

        public bool Loop;

        [Range(0f, 1f)]
        public float Volume;

        [Range(.1f, 3f)]
        public float Pitch;

        [HideInInspector]
        public AudioSource AudioSource;

        #endregion
    }
}
