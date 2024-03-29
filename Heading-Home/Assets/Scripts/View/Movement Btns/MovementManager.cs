﻿using UnityEngine;

namespace Assets.Scripts.View.Movement_Btns
{
    public class MovementManager : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private RotateLeft _rotateLeft;

        [SerializeField]
        private RotateRight _rotateRight;

        [SerializeField]
        private Thrust _thrust;

        #endregion

        #region Methods

        public void SetUpPlayerSpaceshipButtons(PlayerSpaceship playerSpaceshipInstance)
        {
            _thrust.SetUpPlayerSpaceship(playerSpaceshipInstance);
            _rotateLeft.SetUpPlayerSpaceship(playerSpaceshipInstance);
            _rotateRight.SetUpPlayerSpaceship(playerSpaceshipInstance);
        }

        public void DisableBtns()
        {
            if (_thrust != null && _rotateLeft != null && _rotateRight != null)
            {
                _thrust.enabled = false;
                _rotateLeft.enabled = false;
                _rotateRight.enabled = false;
            }
            else
            {
                return;
            }

        }

        #endregion
    }
}
