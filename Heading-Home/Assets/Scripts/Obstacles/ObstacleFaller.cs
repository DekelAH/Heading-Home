using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class ObstacleFaller : MonoBehaviour
    {
        #region Methods

        public void FallingObstacle()
        {
            gameObject.AddComponent<Rigidbody>();
        }

        #endregion
    }
}
