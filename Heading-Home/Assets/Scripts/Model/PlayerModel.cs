using System;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [CreateAssetMenu(menuName = "Data Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        public event Action<int> FuelAmountChange;
        public event Action<bool> OutOfFuel;

        #endregion

        #region Editor

        [SerializeField]
        private int _fuelAmount;

        #endregion

        #region Methods

        public void ResetFuel()
        {
            _fuelAmount = 100;
        }

        public void AddFuel(int fuelToAdd)
        {
            _fuelAmount += fuelToAdd;
            FuelAmountChange?.Invoke(_fuelAmount);
        }

        public void WithdrawFuel(int fuelToWithdraw)
        {
            _fuelAmount = Mathf.Max(0, _fuelAmount - fuelToWithdraw);
            FuelAmountChange?.Invoke(_fuelAmount);
            CheckFuelStatus();
        }

        private void CheckFuelStatus()
        {
            if (_fuelAmount <= 0)
            {
                OutOfFuel?.Invoke(false);
            }
            else
            {
                return;
            }
        }

        #endregion

        #region Properties

        public int Fuel => _fuelAmount;

        #endregion
    }
}
