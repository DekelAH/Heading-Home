using Assets.Scripts.Obstacles;
using System;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class ObstacleFallerFactory : ObstacleFactoryBase
    {
        #region Events

        public event Action<GameObject> ObstacleFallerCreated;

        #endregion

        #region Methods

        public override GameObject CreateObstacle(Vector3 spawnSpot)
        {
            var obstacleFallerInstance = Instantiate(_obstaclePrefabRef, spawnSpot, Quaternion.identity) as GameObject;
            obstacleFallerInstance.AddComponent<ObstacleFaller>();
            ObstacleFallerCreated?.Invoke(obstacleFallerInstance);
            return obstacleFallerInstance;
        }

        #endregion
    }
}
