using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private float _thrustSpeed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private int _fuel;

    [SerializeField]
    private Rigidbody _rigidBody;

    [SerializeField]
    private AudioClip _thrustAudio;

    [SerializeField]
    private AudioClip _crashAudio;

    [SerializeField]
    private AudioClip _successAudio;

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private ParticleSystem _successEffect;

    [SerializeField]
    private ParticleSystem _crashEffect;

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

    #endregion

    #region Fields

    private readonly List<Transform> _childrenTransform = new List<Transform>();

    #endregion

    #region Methods

    private void ProcessRotation(float rotationSpeed)
    {
        _rigidBody.freezeRotation = true;
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
        _rigidBody.freezeRotation = false;
    }

    public void PlayerExplosion()
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

    public void CheckThrustSoundCondition()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_thrustAudio);
        }
    }

    public void CheckCrashSoundCondition()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_crashAudio);
        }
    }

    public void CheckSuccessSoundCondition()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_successAudio);
        }
    }

    public void TriggerRocketFlames()
    {
        _rocketFlame01.Play();
        _rocketFlame02.Play();
        _rocketFlame03.Play();
        _rocketFlame04.Play();
    }

    public void StopRocketFlames()
    {
        _rocketFlame01.Stop();
        _rocketFlame02.Stop();
        _rocketFlame03.Stop();
        _rocketFlame04.Stop();
    }

    public void TriggerRightFlame()
    {
        if (!_rightRocketFlame.isPlaying)
        {
            _rightRocketFlame.Play();
        }
    }

    public void StopSideFlames()
    {
        _rightRocketFlame.Stop();
        _leftRocketFlame.Stop();
    }

    public void TriggerLeftFlame()
    {
        if (!_leftRocketFlame.isPlaying)
        {
            _leftRocketFlame.Play();
        }
    }

    public void TriggerSuccessEffect()
    {
        _successEffect.Play();
    }

    public void TriggerCrashEffect()
    {
        _crashEffect.Play();
    }

    #endregion

    #region Properties

    public float ThrustSpeed => _thrustSpeed;
    public float RotationSpeed => _rotationSpeed;
    public int Fuel => _fuel;
    public AudioSource AudioSource => _audioSource;

    #endregion
}
