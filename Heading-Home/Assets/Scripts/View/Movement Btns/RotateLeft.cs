using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.View.Movement_Btns
{
    public class RotateLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
            _playerSpaceship.ProcessLeftRotation();
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
