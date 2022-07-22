using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineShaker : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private CinemachineVirtualCamera _cinemachineVirtualCamera;

    #endregion

    #region Fields

    private static CinemachineShaker _instance;
    private float _shakeTimer;
    private float _shakeTimerTotal;
    private float _startingStrength;

    #endregion

    #region Methods

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        ShakeOverTime();
    }

    private void ShakeOverTime()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;
            if (_shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(_startingStrength, 0f, 1 - (_shakeTimer / _shakeTimerTotal));
            }
        }
    }

    public void ShakeCamera(float strength, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = strength;
        _startingStrength = strength;
        _shakeTimerTotal = time;
        _shakeTimer = time;
    }

    #endregion

    #region Properties

    public static CinemachineShaker Instance => _instance;

    #endregion
}
