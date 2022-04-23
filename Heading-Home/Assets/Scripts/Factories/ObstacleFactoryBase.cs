using UnityEngine;

namespace Assets.Scripts.Factories
{
    public abstract class ObstacleFactoryBase : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        protected Object _obstaclePrefabRef;

        #endregion

        #region Methods

        public virtual GameObject CreateObstacle(Vector3 spawnSpot)
        {
            var obstacleInstance = Instantiate(_obstaclePrefabRef, spawnSpot, Quaternion.identity) as GameObject;
            return obstacleInstance;
        }

        #endregion
    }
}
