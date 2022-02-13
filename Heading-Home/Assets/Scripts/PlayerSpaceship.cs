using System;
using System.Collections;
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
    private AudioSource _audioSource;

    #endregion

    #region Methods

    private void Start()
    {

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

    private void ProcessRotation(float rotationSpeed)
    {
        _rigidBody.freezeRotation = true;
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
        _rigidBody.freezeRotation = false;
    }

    public void CheckSoundCondition()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    #endregion

    #region Properties

    public float ThrustSpeed => _thrustSpeed;
    public float RotationSpeed => _rotationSpeed;
    public int Fuel => _fuel;
    public AudioSource AudioSource => _audioSource;

    #endregion
}
