using Assets.Scripts.Infastructure;
using Assets.Scripts.Model;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Levels
{
    public class Level01 : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private LevelModel _levelModel;

        [SerializeField]
        private Spawner _spawner;

        [SerializeField]
        private float _delayAfterCrash;

        [SerializeField]
        private float _delayAfterFinish;

        #endregion

        #region Fields

        private bool _isPlayerCrashed = false;
        private bool _isPlayerWin = false;

        #endregion

        #region Methods

        private void Start()
        {
            RegisterEvents();
            ActivateSpawner();
        }

        private void OnDestroy()
        {
            _levelModel.PlaySpaceshipPrefab.PlayerCrashed -= OnPlayerCrash;
            _levelModel.PlaySpaceshipPrefab.PlayerWin -= OnPlayerWin;
        }

        private void ActivateSpawner()
        {
            _spawner.StartSpawn();
        }

        private void RegisterEvents()
        {
            _levelModel.PlaySpaceshipPrefab.PlayerCrashed += OnPlayerCrash;
            _levelModel.PlaySpaceshipPrefab.PlayerWin += OnPlayerWin;
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
                StartCoroutine(_levelModel.FinishPortal.LerpPortalShrinkSize());
                _levelModel.PlaySpaceshipPrefab.HideSpaceship();
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
