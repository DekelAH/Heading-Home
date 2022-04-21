using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public abstract class ObstacleBase : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        protected Transform _selfTransform;

        [SerializeField]
        protected Vector3 _movementVector;

        [SerializeField]
        [Range(0, 1)]
        protected float _movementFactor;

        [SerializeField]
        protected float _inTime = 2f;

        #endregion

        #region Fields

        protected Vector3 _startingPosition;

        #endregion

        #region Methods

        private void Start()
        {
            _startingPosition = _selfTransform.position;
            StartCoroutine(MoveObstacle(_selfTransform, _movementVector, _movementFactor, _inTime, _startingPosition));
        }

        protected virtual IEnumerator MoveObstacle(Transform selfTransform, Vector3 movementVector, float movementFactor, float inTime, Vector3 startingPosition)
        {
            while (true)
            {
                var numTimes = Time.time / inTime;
                var tau = Mathf.PI * 2;
                var sinWave = Mathf.Sin(numTimes * tau);

                movementFactor = (sinWave + 1f) / 2f;
                var offset = _movementVector * movementFactor;
                selfTransform.position = startingPosition + offset;

                yield return null;
            }
        }

        #endregion
    }
}
