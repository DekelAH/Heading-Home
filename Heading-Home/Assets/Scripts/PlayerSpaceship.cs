using Assets.Scripts.Infastructure;
using Assets.Scripts.View.Movement_Btns;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{
    #region Events

    public event Action<bool> PlayerCrashed;
    public event Action<bool> PlayerWin;

    #endregion

    #region Editor

    [Header("Movement")]
    [SerializeField]
    private float _thrustSpeed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private Rigidbody _rigidBody;

    [SerializeField]
    private MovementManager _movementManager;

    [Header("Effects")]
    [SerializeField]
    private ParticleSystem _crashEffect;

    [SerializeField]
    private ParticleSystem _crashShockwaveEffect;

    [SerializeField]
    private ParticleSystem _rocketFlame01;

    [SerializeField]
    private ParticleSystem _rocketFlame02;

    [SerializeField]
    private ParticleSystem _rocketFlame03;

    [SerializeField]
    private ParticleSystem _rocketFlame04;

    [SerializeField]
    private ParticleSystem _leftRocketFlame;

    [SerializeField]
    private ParticleSystem _rightRocketFlame;

    [SerializeField]
    private ParticleSystem _speedEffect;

    #endregion

    #region Consts

    private const string CRASH_CLIP_NAME = "CrashAudio";
    private const string FINISH_CLIP_NAME = "FinishAudio";
    private const string THRUST_CLIP_NAME = "ThrustAudio";
    private const string OUT_OF_FUEL_CLIP_NAME = "OutOfFuelAudio";

    private const string FRIENDLY_TAG = "Friendly";
    private const string FINISH_TAG = "Finish";

    #endregion

    #region Fields

    private AudioManager _audioManager;

    private readonly List<Transform> _childrenTransform = new List<Transform>();
    private bool _isIdle = false;

    #endregion

    #region Methods

    private void Awake()
    {
        SetUpAudioManager();
    }

    private void Start()
    {
        RegisterEvents();
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case FINISH_TAG:
                StartFinishSequence();
                break;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (_isIdle)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case FRIENDLY_TAG:
                Debug.Log("Friendly!!!!");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartCrashSequence()
    {
        _isIdle = true;
        PlayerCrashed?.Invoke(true);
        CrashSequence();
    }

    private void StartFinishSequence()
    {
        _isIdle = true;
        PlayerWin?.Invoke(true);
        FinishSequence();
    }

    private void RegisterEvents()
    {
        var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
        playerModel.OutOfFuel += OnOutOfFuel;
    }

    private void SetUpAudioManager()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    public void CrashSequence()
    {
        StopOutOfFuelSound();
        StopThrustSound();

        if (_audioManager != null)
        {
            _audioManager.PlaySound(CRASH_CLIP_NAME);
        }

        PlayerExplosion();
        RemoveColliderOnCrash();
        _movementManager.DisableBtns();
        StopSideFlames();
        StopRocketFlames();
        TriggerCrashEffect();
    }

    public void FinishSequence()
    {
        if (_audioManager != null)
        {
            _audioManager.PlaySound(FINISH_CLIP_NAME);
        }
        StopSideFlames();
        StopRocketFlames();
        _movementManager.DisableBtns();
    }

    public void ProcessThrust()
    {
        _rigidBody.AddRelativeForce(_thrustSpeed * Time.deltaTime * Vector3.up);
    }

    public void LeftRotation()
    {
        ProcessRotation(_rotationSpeed);
    }

    public void RightRotation()
    {
        ProcessRotation(-_rotationSpeed);
    }

    public void TriggerLeftFlame()
    {
        if (!_leftRocketFlame.isPlaying)
        {
            _leftRocketFlame.Play();
        }
    }

    public void TriggerRocketFlames()
    {
        _rocketFlame01.Play();
        _rocketFlame02.Play();
        _rocketFlame03.Play();
        _rocketFlame04.Play();
    }
    public void TriggerRightFlame()
    {
        if (!_rightRocketFlame.isPlaying)
        {
            _rightRocketFlame.Play();
        }
    }

    public void StopRocketFlames()
    {
        _rocketFlame01.Stop();
        _rocketFlame02.Stop();
        _rocketFlame03.Stop();
        _rocketFlame04.Stop();
    }

    public void StopSideFlames()
    {
        _rightRocketFlame.Stop();
        _leftRocketFlame.Stop();
    }

    public void HideSpaceship()
    {
        gameObject.SetActive(false);
    }

    public void ShowSpaceship()
    {
        gameObject.SetActive(true);
    }

    private void RemoveColliderOnCrash()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }

    private void OnOutOfFuel(bool fuelStatus)
    {
        if (fuelStatus)
        {
            StopThrustSound();
            StartOutOfFuelSequence();
        }
        else
        {
            return;
        }
    }

    private void StartOutOfFuelSequence()
    {
        _movementManager.DisableBtns();
        CheckOutOfFuelSoundCondition();
    }

    public void CheckThrustSoundCondition()
    {
        if (_audioManager != null)
        {
            if (!_audioManager.GetAudioSource(THRUST_CLIP_NAME).isPlaying)
            {
                _audioManager.PlaySoundOneShot(THRUST_CLIP_NAME);
            }
        }
        else
        {
            return;
        }
    }

    public void StopThrustSound()
    {
        if (_audioManager != null)
        {
            _audioManager.StopSound(THRUST_CLIP_NAME);
        }
        else
        {
            return;
        }
    }

    private void StopOutOfFuelSound()
    {
        if (_audioManager != null)
        {
            _audioManager.StopSound(OUT_OF_FUEL_CLIP_NAME);
        }
        else
        {
            return;
        }
    }

    private void CheckOutOfFuelSoundCondition()
    {
        if (_audioManager != null)
        {
            if (!_audioManager.GetAudioSource(OUT_OF_FUEL_CLIP_NAME).isPlaying)
            {
                _audioManager.PlaySoundOneShot(OUT_OF_FUEL_CLIP_NAME);
            }
        }
        else
        {
            return;
        }
    }

    private void ProcessRotation(float rotationSpeed)
    {
        _rigidBody.freezeRotation = true;
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
        _rigidBody.freezeRotation = false;
    }

    private void PlayerExplosion()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _childrenTransform.Add(transform.GetChild(i));
        }

        foreach (var child in _childrenTransform)
        {
            child.gameObject.AddComponent<Rigidbody>();
            child.gameObject.AddComponent<MeshCollider>().convex = true;
        }
    }

    private void TriggerCrashEffect()
    {
        _crashEffect.Play();
        _crashShockwaveEffect.Play();
    }

    public void TriggerSpeedEffect()
    {
        _speedEffect.Play();
    }

    public void StopSpeedEffect()
    {
        _speedEffect.Stop();
    }

    #endregion
}
