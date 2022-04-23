using Assets.Scripts;
using Assets.Scripts.Infastructure;
using System.Collections;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private float _delayAfterCrash;

    [SerializeField]
    private float _delayAfterFinish;

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
        _playerSpaceship.CrashSequence();
        StartCoroutine(OnReloadLevel(_delayAfterCrash));
    }

    private IEnumerator OnReloadLevel(float delay)
    {
        yield return new WaitForSeconds(delay);

        var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
        playerModel.ResetFuel();
        var sceneHandler = new SceneHandler();
        sceneHandler.ReloadLevel();
    }

    private void StartFinishSequence()
    {
        _isIdle = true;
        _playerSpaceship.FinishSequence();
        StartCoroutine(OnNextLevel(_delayAfterFinish));
    }

    private IEnumerator OnNextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);

        var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
        playerModel.ResetFuel();
        var sceneHandler = new SceneHandler();
        sceneHandler.NextLevel();
    }

    #endregion
}
