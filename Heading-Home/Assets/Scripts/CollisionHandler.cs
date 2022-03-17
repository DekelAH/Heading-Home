using Assets.Scripts;
using Assets.Scripts.Model;
using Assets.Scripts.View.Items;
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
    private RotateLeft _rotateLeft;

    [SerializeField]
    private RotateRight _rotateRight;

    [SerializeField]
    private Thrust _thrust;

    [SerializeField]
    private PlayerModel _playerModel;

    [SerializeField]
    private Item _fuel;

    #endregion

    #region Consts

    private const string FRIENDLY_TAG = "Friendly";
    private const string FINISH_TAG = "Finish";
    private const string FUEL_TAG = "Fuel";

    #endregion

    #region Fields

    private readonly SceneHandler _sceneHandler = new SceneHandler();
    private bool _isIdle = false;

    #endregion

    #region Methods

    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case FUEL_TAG:
                FuelCollision();
                break;
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

    private void FuelCollision()
    {
        _playerModel.AddFuel(_fuel.Parameter);
        _fuel.DestroyItem();
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
        DisableBtns();
        StartCoroutine(ReloadLevelCoroutine());
    }

    private IEnumerator ReloadLevelCoroutine()
    {

        yield return new WaitForSeconds(_delayAfterCrash);

        _sceneHandler.ReloadLevel();
    }

    private void StartFinishSequence()
    {
        _isIdle = true;
        _playerSpaceship.AudioSource.Stop();
        _playerSpaceship.CheckSuccessSoundCondition();
        _playerSpaceship.StopSideFlames();
        _playerSpaceship.StopRocketFlames();
        StartCoroutine(NextLevelCoroutine());
    }

    private IEnumerator NextLevelCoroutine()
    {
        yield return new WaitForSeconds(_delayAfterFinish);

        _sceneHandler.NextLevel();
    }

    public void DisableBtns()
    {
        _thrust.enabled = false;
        _rotateLeft.enabled = false;
        _rotateRight.enabled = false;
    }

    #endregion
}
