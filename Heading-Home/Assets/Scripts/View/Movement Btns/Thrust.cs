using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.View.Movement_Btns
{
    public class Thrust : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Editor

        [SerializeField]
        private PlayerSpaceship _playerSpaceship;

        [SerializeField]
        private PlayerModel _playerModel;

        [SerializeField]
        private int _fuelToWithdraw;

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
                _playerSpaceship.CheckThrustSoundCondition();
                _playerSpaceship.TriggerRocketFlames();
                
            }
            else
            {
                _playerSpaceship.AudioSource.Stop();
                _playerSpaceship.StopRocketFlames();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
            _playerModel.WithdrawFuel(_fuelToWithdraw);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
        }

        #endregion
    }
}
