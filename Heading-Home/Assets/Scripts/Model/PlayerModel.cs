using System;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [CreateAssetMenu(menuName = "Data Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        public event Action<int> FuelChange;

        #endregion

        #region Editor

        [SerializeField]
        private int _fuel;

        #endregion

        #region Methods

        public void AddFuel(int fuelToAdd)
        {
            _fuel += fuelToAdd;
            FuelChange?.Invoke(_fuel);
        }

        public void WithdrawFuel(int fuelToWithdraw)
        {
            if (fuelToWithdraw <= _fuel)
            {
                _fuel = Mathf.Max(0, _fuel - fuelToWithdraw);
                FuelChange?.Invoke(_fuel);
            }
        }

        #endregion

        #region Properties

        public int Fuel => _fuel;

        #endregion
    }
}
