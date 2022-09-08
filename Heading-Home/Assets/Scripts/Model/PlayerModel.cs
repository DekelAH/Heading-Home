using System;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [CreateAssetMenu(menuName = "Data Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        public event Action<float> FuelAmountChange;
        public event Action<bool> OutOfFuel;

        #endregion

        #region Editor

        [SerializeField]
        private float _fuelAmount;

        #endregion

        #region Fields

        private string _saveModelName = "";

        #endregion

        #region Methods

        public void ResetFuel()
        {
            _fuelAmount = 100;
        }

        public void SetFuel(float fuel)
        {
            _fuelAmount = fuel;
        }

        public void AddFuel(float fuelToAdd)
        {
            _fuelAmount += fuelToAdd;
            FuelAmountChange?.Invoke(_fuelAmount);
        }

        public void WithdrawFuel(float fuelToWithdraw)
        {
            _fuelAmount = Mathf.Max(0, _fuelAmount - fuelToWithdraw);
            FuelAmountChange?.Invoke(_fuelAmount);
            CheckFuelStatus();
        }

        public void SetSaveModelName(string saveModelName)
        {
            _saveModelName = saveModelName;
        }

        private void CheckFuelStatus()
        {
            if (_fuelAmount <= 0)
            {
                OutOfFuel?.Invoke(true);
            }
            else
            {
                return;
            }
        }

        #endregion

        #region Properties

        public float Fuel => _fuelAmount;
        public string SaveModelName => _saveModelName;

        #endregion
    }
}
