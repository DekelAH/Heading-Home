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

        [SerializeField]
        private PlayerModel _playerModel;

        #endregion

        #region Methods

        private void Update()
        {
            UpdateView();
        }

        private void OnDestroy()
        {
            _playerModel.FuelChange -= OnUpdateFuelBar;
        }

        private void UpdateView()
        {
            _playerModel.FuelChange += OnUpdateFuelBar;
        }

        private void OnUpdateFuelBar(int fuel)
        {
            _fuelBar.value = fuel;
        }

        #endregion
    }
}
