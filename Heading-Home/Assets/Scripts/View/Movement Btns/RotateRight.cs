using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.View.Movement_Btns
{
    public class RotateRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Fields

        private PlayerSpaceship _playerSpaceship;

        private bool _isPressed = false;

        #endregion

        #region Methods

        private void Update()
        {
            CheckRightBtnPressed();
        }

        private void CheckRightBtnPressed()
        {
            if (_isPressed)
            {
                _playerSpaceship.RightRotation();
                _playerSpaceship.TriggerRightFlame();
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
