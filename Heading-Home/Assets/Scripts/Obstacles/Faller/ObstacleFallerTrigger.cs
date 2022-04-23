using Assets.Scripts.Factories;
using System;
using UnityEngine;

namespace Assets.Scripts.Obstacles.Faller
{
    public class ObstacleFallerTrigger : MonoBehaviour
    {
        #region Consts

        private const string PLAYER_TAG = "Player";

        #endregion

        #region Editor

        [SerializeField]
        private ObstacleFallerFactory _obstacleFallerFactory;

        #endregion

        #region Fields

        private GameObject _obstacleFallerCreated;

        #endregion

        #region Methods

        private void Start()
        {
            _obstacleFallerFactory.ObstacleFallerCreated += OnObstacleFallerCreated;
        }

        private void OnDestroy()
        {
            _obstacleFallerFactory.ObstacleFallerCreated -= OnObstacleFallerCreated;
        }

        private void OnObstacleFallerCreated(GameObject obstacleFallerCreated)
        {
            _obstacleFallerCreated = obstacleFallerCreated;
        }

        public void OnTriggerEnter(Collider other)
        {
            switch (other.gameObject.tag)
            {
                case PLAYER_TAG:
                    var triggerFaller = _obstacleFallerCreated.GetComponent<ObstacleFaller>();
                    triggerFaller.FallingObstacle();
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
