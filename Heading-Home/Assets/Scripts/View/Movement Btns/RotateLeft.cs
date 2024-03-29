﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.View.Movement_Btns
{
    public class RotateLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Fields

        private PlayerSpaceship _playerSpaceship;

        private bool _isPressed = false;

        #endregion

        #region Methods

        private void Update()
        {
            CheckLeftBtnPressed();
        }

        private void CheckLeftBtnPressed()
        {
            if (_isPressed)
            {
                _playerSpaceship.LeftRotation();
                _playerSpaceship.TriggerLeftFlame();
            }
            else
            {
                _playerSpaceship.StopSideFlames();
            }
        }

        public void SetUpPlayerSpaceship(PlayerSpaceship playerSpaceshipInstance)
        {
            _playerSpaceship = playerSpaceshipInstance;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
        }

        #endregion
    }
}
