using Assets.Scripts;
using Assets.Scripts.Infastructure;
using Assets.Scripts.View;
using System;
using System.Collections;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    #region Events

    public event Action<bool> PlayerCrashed;
    public event Action<bool> PlayerWin;

    #endregion

    #region Editor

    [SerializeField]
    private PlayerSpaceship _playerSpaceship;

    #endregion

    #region Consts

    private const string FRIENDLY_TAG = "Friendly";
    private const string FINISH_TAG = "Finish";

    #endregion

    #region Fields

    private bool _isIdle = false;

    #endregion

    #region Methods

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
        PlayerCrashed.Invoke(true);
        _playerSpaceship.CrashSequence();
    }

    private void StartFinishSequence()
    {
        _isIdle = true;
        PlayerWin?.Invoke(true);
        _playerSpaceship.FinishSequence();
        _playerSpaceship.HideSpaceship();
    }

    #endregion
}
