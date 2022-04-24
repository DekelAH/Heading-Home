using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    public class BlowerObstacleProjectile : MonoBehaviour
    {
        
       #region Methods

        private void OnCollisionEnter(Collision collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("Friendly!");
                    break;
                case "Enemy":
                    gameObject.SetActive(false);
                    break;
                case "Player":
                    gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
