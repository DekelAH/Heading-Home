﻿using Assets.Scripts.Infastructure;
using Assets.Scripts.View;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Levels
{
    public class Level : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private CollisionHandler _collisionHandler;

        [SerializeField]
        private PlayerSpaceship _playerSpaceship;

        [SerializeField]
        private PortalHandler _finishPortal;

        [SerializeField]
        private PortalHandler _startPortal;

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
            StartLevel();
        }

        private void OnDestroy()
        {
            _collisionHandler.PlayerCrashed -= OnPlayerCrash;
            _collisionHandler.PlayerWin -= OnPlayerWin;
        }

        private void ActivateSpawner()
        {
            _spawner.StartSpawn();
        }

        private void RegisterEvents()
        {
            _collisionHandler.PlayerCrashed += OnPlayerCrash;
            _collisionHandler.PlayerWin += OnPlayerWin;
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
                StartCoroutine(_finishPortal.LerpPortalShrinkSize());
                _playerSpaceship.HideSpaceship();
            }
        }

        private void StartLevel()
        {
            if (_startPortal != null)
            {
                _playerSpaceship.HideSpaceship();
                StartCoroutine(_startPortal.LerpPortalGrowSize());
                _playerSpaceship.ShowSpaceship();
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