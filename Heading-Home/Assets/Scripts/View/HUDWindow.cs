using Assets.Scripts.Infastructure;
using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HUDWindow : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Slider _fuelBar;

        #endregion

        #region Methods

        private void Start()
        {
            SetUpParams();
        }

        private void Update()
        {
            SubscribeToEvents();
        }

        private void SetUpParams()
        {
            var playerModel = SetPlayerModel();
            _fuelBar.value = playerModel.Fuel;
        }

        private void OnDestroy()
        {
            var playerModel = SetPlayerModel();
            playerModel.FuelAmountChange -= OnFuelChange;
        }

        private void SubscribeToEvents()
        {
            var playerModel = SetPlayerModel();
            playerModel.FuelAmountChange += OnFuelChange;
        }

        private void OnFuelChange(int fuel)
        {
            _fuelBar.value = fuel;
        }

        private PlayerModel SetPlayerModel()
        {
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
            return playerModel;
        }

        #endregion
    }
}
