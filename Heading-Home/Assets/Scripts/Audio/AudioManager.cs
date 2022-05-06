using Assets.Scripts.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private Sound[] _sounds;

    #endregion

    #region Consts

    private const string GAME_MUSIC = "GameAudio";

    #endregion

    #region Fields

    private static AudioManager _instance;

    #endregion

    #region Methods

    private void Awake()
    {
        CheckAudioManagerInstanceStatus();
        SetUpSounds();
    }

    private void Start()
    {
        PlaySound(GAME_MUSIC);
    }

    private void CheckAudioManagerInstanceStatus()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void SetUpSounds()
    {
        foreach (Sound sound in _sounds)
        {
            sound.AudioSource = gameObject.AddComponent<AudioSource>();

            sound.AudioSource.clip = sound.Clip;
            sound.AudioSource.volume = sound.Volume;
            sound.AudioSource.pitch = sound.Pitch;
            sound.AudioSource.loop = sound.Loop;
        }
    }

    public void PlaySound(string name)
    {
        var sound = Array.Find(_sounds, sound => sound.Name == name);

        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }

        sound.AudioSource.Play();
    }

    public void PlaySoundOneShot(string name)
    {
        var sound = Array.Find(_sounds, sound => sound.Name == name);

        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }

        sound.AudioSource.PlayOneShot(sound.Clip);
    }

    public void StopSound(string name)
    {
        var sound = Array.Find(_sounds, sound => sound.Name == name);

        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }

        sound.AudioSource.Stop();
    }

    public AudioSource GetAudioSource(string name)
    {
        var sound = Array.Find(_sounds, sound => sound.Name == name);

        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
        }

        return sound.AudioSource;
    }

    #endregion
}
