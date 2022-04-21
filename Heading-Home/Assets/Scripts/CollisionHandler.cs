using Assets.Scripts;
using Assets.Scripts.Infastructure;
using Assets.Scripts.Items;
using Assets.Scripts.Model;
using Assets.Scripts.View.Movement_Btns;
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

    [SerializeField]
    private MovementManager _movementManager;

    [SerializeField]
    private ItemModel _fuelModel;

    [SerializeField]
    private ItemView _fuel;

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
        _playerSpaceship.AudioSource.Stop();
        _playerSpaceship.PlayerExplosion();
        _playerSpaceship.CheckCrashSoundCondition();
        _playerSpaceship.StopSideFlames();
        _playerSpaceship.StopRocketFlames();
        _playerSpaceship.TriggerCrashEffect();
        _movementManager.DisableBtns();
        StartCoroutine(ReloadLevel(_delayAfterCrash));
    }

    private IEnumerator ReloadLevel(float delay)
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
        _playerSpaceship.AudioSource.Stop();
        _playerSpaceship.CheckSuccessSoundCondition();
        _playerSpaceship.StopSideFlames();
        _playerSpaceship.StopRocketFlames();
        StartCoroutine(NextLevel(_delayAfterFinish));
    }

    private IEnumerator NextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);

        var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
        playerModel.ResetFuel();
        var sceneHandler = new SceneHandler();
        sceneHandler.NextLevel();
    }

    #endregion
}
