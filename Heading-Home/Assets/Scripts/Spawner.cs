using Assets.Scripts.Factories;
using Assets.Scripts.View;
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
        private Transform _playerSpawnSpot;

        [SerializeField]
        private Transform _finishPortalSpawnPoint;

        [SerializeField]
        private Transform _startPortalSpawnPoint;

        [SerializeField]
        private FuelFactory _fuelFactory;

        [SerializeField]
        private ObstacleFallerFactory _obstacleFallerFactory;

        #endregion

        #region Methods

        public void StartSpawn()
        {
            SpawnObstacleFaller(_obstacleFallerSpots);
            SpawnFuel(_fuelSpawnSpots);
        }

        public PortalHandler SpawnFinishPortal(Vector3 spawnSpot, PortalHandler finishPortalPrefab)
        {
            var portal = Instantiate(finishPortalPrefab, spawnSpot, Quaternion.identity);
            return portal;
        }

        public PortalHandler SpawnStartPortal(Vector3 spawnSpot, PortalHandler startPortalPrefab)
        {
            var portal = Instantiate(startPortalPrefab, spawnSpot, Quaternion.identity);
            return portal;
        }

        public PlayerSpaceship SpawnSpaceship(Vector3 spawnSpot, PlayerSpaceship spaceshipPrefab)
        {
            var playerSpaceship = Instantiate(spaceshipPrefab, spawnSpot, Quaternion.identity);
            return playerSpaceship;
        }

        private void SpawnFuel(Transform[] fuelSpawnSpots)
        {
            if (_fuelFactory != null)
            {
                for (int i = 0; i < fuelSpawnSpots.Length; i++)
                {
                    _fuelFactory.CreateItem(fuelSpawnSpots[i].transform.position);
                }
            }
            else
            {
                return;
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

        #region Properties

        public Transform PlayerSpawnSpot => _playerSpawnSpot;
        public Transform FinishPortalSpawnPoint => _finishPortalSpawnPoint;
        public Transform StartPortalSpawnPoint => _startPortalSpawnPoint;

        #endregion
    }
}
