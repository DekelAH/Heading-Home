using Assets.Scripts.Infastructure;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.View.Movement_Btns
{
    public class Thrust : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Editor

        [SerializeField]
        private int _fuelToWithdraw;

        #endregion

        #region Fields

        private PlayerSpaceship _playerSpaceship;

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
                _playerSpaceship.StopThrustSound();
                _playerSpaceship.StopRocketFlames();
            }
        }

        public void SetUpPlayerSpaceship(PlayerSpaceship playerSpaceshipInsatance)
        {
            _playerSpaceship = playerSpaceshipInsatance;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;

            var playerModel = PlayerModelProvider.Instance.GetCurrentSaveType;
            playerModel.WithdrawFuel(_fuelToWithdraw);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
        }

        #endregion
    }
}
