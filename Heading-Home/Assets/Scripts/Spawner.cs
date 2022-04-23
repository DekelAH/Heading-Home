using Assets.Scripts.Factories;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Transform[] _fuelSpawnSpots;

        [SerializeField]
        private Transform[] _obstacleFallerSpots;

        [SerializeField]
        private FuelFactory _fuelFactory;

        [SerializeField]
        private ObstacleFallerFactory _obstacleFallerFactory;

        #endregion

        #region Methods

        private void Start()
        {
            SpawnFuel(_fuelSpawnSpots);
            SpawnObstacleFaller(_obstacleFallerSpots);
        }

        private void SpawnFuel(Transform[] fuelSpawnSpots)
        {
            for (int i = 0; i < fuelSpawnSpots.Length; i++)
            {
                _fuelFactory.CreateItem(fuelSpawnSpots[i].transform.position);
            }
        }

        private void SpawnObstacleFaller(Transform[] obstacleFallerSpots)
        {
            if (_obstacleFallerFactory != null)
            {
                for (int i = 0; i < obstacleFallerSpots.Length; i++)
                {
                    _obstacleFallerFactory.CreateObstacle(obstacleFallerSpots[i].transform.position);
                }
            }
            else
            {
                return;
            }
        }

        #endregion
    }
}
