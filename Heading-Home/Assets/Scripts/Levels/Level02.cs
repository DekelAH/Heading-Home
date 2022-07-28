using Assets.Scripts.Infastructure;
using Assets.Scripts.Model;
using Assets.Scripts.View;
using Assets.Scripts.View.Movement_Btns;
using Cinemachine;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Levels
{
    public class Level02 : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private LevelModel _levelModel;

        [SerializeField]
        private MovementManager _movementManager;

        [SerializeField]
        private CinemachineVirtualCamera _followCam;

        [SerializeField]
        private Spawner _spawner;

        [SerializeField]
        private float _delayAfterCrash;

        [SerializeField]
        private float _delayAfterFinish;

        #endregion

        #region Fields

        private PlayerSpaceship _playerSpaceshipInstance;
        private PortalHandler _finishPortalInstance;
        private PortalHandler _startPortalInstance;

        private bool _isPlayerCrashed = false;
        private bool _isPlayerWin = false;

        #endregion

        #region Methods

        private void Start()
        {
            SetUpGameModels();
            _movementManager.SetUpPlayerSpaceshipButtons(_playerSpaceshipInstance);
            RegisterEvents();
            StartLevel();
            SetFollowCam();
            ActivateSpawner();
        }

        private void OnDestroy()
        {
            _playerSpaceshipInstance.PlayerCrashed -= OnPlayerCrash;
            _playerSpaceshipInstance.PlayerWin -= OnPlayerWin;
        }

        private void SetUpGameModels()
        {
            _playerSpaceshipInstance = _spawner.SpawnSpaceship(_spawner.PlayerSpawnSpot.position, _levelModel.PlaySpaceshipPrefab);
            _startPortalInstance = _spawner.SpawnStartPortal(_spawner.StartPortalSpawnPoint.position, _levelModel.StartPortalPrefab);
            _finishPortalInstance = _spawner.SpawnFinishPortal(_spawner.FinishPortalSpawnPoint.position, _levelModel.FinishPortalPrefab);
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

        private void StartLevel()
        {
            if (_playerSpaceshipInstance != null)
            {
                StartCoroutine(_startPortalInstance.LerpPortalGrowSize());
            }
            else
            {
                return;
            }
        }

        private void ActivateReloadLevel(float delayAfterCrash)
        {
            StartCoroutine(OnReloadLevel(delayAfterCrash));
        }

        private IEnumerator OnReloadLevel(float delay)
        {
            yield return new WaitForSeconds(delay);
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
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
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
            playerModel.ResetFuel();

            var sceneHandler = new SceneHandler();
            sceneHandler.NextLevel();
        }

        #endregion
    }
}

