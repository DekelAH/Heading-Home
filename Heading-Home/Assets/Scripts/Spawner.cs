using Assets.Scripts.Factories;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Transform[] _spawnSpots;

        [SerializeField]
        private FuelFactory _fuelFactory;

        #endregion

        #region Methods

        private void Start()
        {
            SpawnItem(_spawnSpots);
        }

        private void SpawnItem(Transform[] spawnSpots)
        {
            for (int i = 0; i < spawnSpots.Length; i++)
            {
                _fuelFactory.CreateItem(spawnSpots[i].transform.position);
            }
        }

        #endregion
    }
}
