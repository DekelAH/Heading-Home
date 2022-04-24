using UnityEngine;

namespace Assets.Scripts.Factories
{
    public abstract class ProjectileFactoryBase : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        protected Object _blowerProjetilePrefabRef;

        #endregion

        #region Methods

        public virtual GameObject CreateProjectile(Vector3 spawnSpot)
        {
            var projectileInstance = Instantiate(_blowerProjetilePrefabRef, spawnSpot,Quaternion.identity) as GameObject;
            return projectileInstance;
        }

        #endregion
    }
}
