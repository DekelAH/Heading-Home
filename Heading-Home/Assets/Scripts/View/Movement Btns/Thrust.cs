using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.View.Movement_Btns
{
    public class Thrust : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
            CheckThrustBtnPressed();
        }

        private void CheckThrustBtnPressed()
        {
            if (_isPressed)
            {
                _playerSpaceship.ProcessThrust();
                _playerSpaceship.CheckSoundCondition();
            }
            else
            {
                _playerSpaceship.AudioSource.Stop();
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
