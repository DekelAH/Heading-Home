using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.View.Movement_Btns
{
    public class RotateRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Editor

        [SerializeField]
        private PlayerSpaceship _playerSpaceship;

        #endregion

        #region Fields

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
            }
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
