using Assets.Scripts.Infastructure;
using Assets.Scripts.Items;
using Assets.Scripts.Model;
using Assets.Scripts.View;
using Assets.Scripts.View.Movement_Btns;
using Cinemachine;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Levels
{
    public class LevelBase : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        protected LevelModel _levelModel;

        [SerializeField]
        private MovementManager _movementManager;

        [SerializeField]
        private CinemachineVirtualCamera _followCam;

        [SerializeField]
        protected Spawner _spawner;

        [SerializeField]
        private SpecialItemView _specialItem;

        [SerializeField]
        private float _delayAfterCrash;

        [SerializeField]
        private float _delayAfterFinish;

        #endregion

        #region Fields

        protected PlayerSpaceship _playerSpaceshipInstance;
        private PortalHandler _finishPortalInstance;

        private bool _isPlayerCrashed = false;
        private bool _isPlayerWin = false;

        #endregion

        #region Methods

        private void Start()
        {
            SetGameObjects();
        }

        private void Update()
        {
            SpawnFinishPortalOnTrigger();
        }

        private void OnDestroy()
        {
            _playerSpaceshipInstance.PlayerCrashed -= OnPlayerCrash;
            _playerSpaceshipInstance.PlayerWin -= OnPlayerWin;
        }

        private void SpawnFinishPortalOnTrigger()
        {
            if (_specialItem.FinishTrigger == true)
            {
                _finishPortalInstance = _spawner.SpawnFinishPortal(_spawner.FinishPortalSpawnPoint.position, _levelModel.FinishPortalPrefab);
                StartCoroutine(_finishPortalInstance.LerpPortalGrowSize());
                _specialItem.SetTriggerFinishPortal(false);
            }
        }

        protected virtual void SetGameObjects()
        {
            SetUpGameModels();
            RegisterEvents();
            _movementManager.SetUpPlayerSpaceshipButtons(_playerSpaceshipInstance);
            SetFollowCam();
            ActivateSpawner();
        }

        private void SetUpGameModels()
        {
            _playerSpaceshipInstance = _spawner.SpawnSpaceship(_spawner.PlayerSpawnSpot.position, _levelModel.PlaySpaceshipPrefab);
        }

        private void SetFollowCam()
        {
            if (_followCam != null)
            {
                _followCam.Follow = _playerSpaceshipInstance.transform;
            }
        }

        private void ActivateSpawner()
        {
            _spawner.StartSpawn();
        }

        private void RegisterEvents()
        {
            _playerSpaceshipInstance.PlayerCrashed += OnPlayerCrash;
            _playerSpaceshipInstance.PlayerWin += OnPlayerWin;
        }

        private void OnPlayerCrash(bool isPlayerCrash)
        {
            _isPlayerCrashed = isPlayerCrash;
            if (_isPlayerCrashed)
            {
                ActivateReloadLevel(_delayAfterCrash);
            }
        }

        private void OnPlayerWin(bool isPlayerWin)
        {
            _isPlayerWin = isPlayerWin;
            if (_isPlayerWin)
            {
                ActivateNextLevel(_delayAfterFinish);
                StartCoroutine(_finishPortalInstance.LerpPortalShrinkSize());
                _playerSpaceshipInstance.HideSpaceship();
            }
        }

        private void ActivateReloadLevel(float delayAfterCrash)
        {
            StartCoroutine(OnReloadLevel(delayAfterCrash));
        }

        private IEnumerator OnReloadLevel(float delay)
        {
            yield return new WaitForSeconds(delay);
            var playerModel = PlayerModelProvider.Instance.GetCurrentSaveType;
            playerModel.ResetFuel();

            var sceneHandler = new SceneHandler();
            sceneHandler.ReloadLevel();
        }

        private void ActivateNextLevel(float delayAfterFinish)
        {
            StartCoroutine(OnNextLevel(delayAfterFinish));
        }

        private IEnumerator OnNextLevel(float delay)
        {
            yield return new WaitForSeconds(delay);
            var playerModel = PlayerModelProvider.Instance.GetCurrentSaveType;
            playerModel.ResetFuel();

            var sceneHandler = new SceneHandler();
            sceneHandler.NextLevel();
        }

        #endregion
    }
}
