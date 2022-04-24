using UnityEngine;

namespace Assets.Scripts.Faller.Obstacles
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
