using Assets.Scripts.Factories;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class ObstacleBlower : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private float _projectileSpeed = 200;

        [SerializeField]
        private BlowerProjectileFactory _blowerProjectileFactory;

        [SerializeField]
        private Transform _blowerTransform;

        #endregion

        #region Methods

        private void Start()
        {
           StartCoroutine(FireProjectile());
        }

        private IEnumerator FireProjectile()
        {
            while (true)
            {
                var spawnTime = Random.Range(2, 6);
                var projectile = _blowerProjectileFactory.CreateProjectile(_blowerTransform.position);
                projectile.GetComponent<Rigidbody>().velocity = _projectileSpeed * Time.deltaTime * Vector3.up;

                yield return new WaitForSeconds(spawnTime);
            }
        }

        #endregion
    }
}
