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

    #endregion

    #region Methods

    private void Start()
    {
        
    }

    public void ProcessThrust()
    {
        _rigidBody.AddRelativeForce(Vector3.up * _thrustSpeed * Time.deltaTime);
    }

    public void ProcessLeftRotation()
    {
        _rigidBody.AddRelativeForce(Vector3.left * _rotationSpeed * Time.deltaTime);
    }   

    public void ProcessRightRotation()
    {
        _rigidBody.AddRelativeForce(Vector3.right * _rotationSpeed * Time.deltaTime);
    }

    #endregion

    #region Properties

    public float ThrustSpeed => _thrustSpeed;
    public float RotationSpeed => _rotationSpeed;
    public int Fuel => _fuel;

    #endregion
}
