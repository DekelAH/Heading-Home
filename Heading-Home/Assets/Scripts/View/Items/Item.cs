using Assets.Scripts.Model;
using UnityEngine;

namespace Assets.Scripts.View.Items
{
    public class Item : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private int _parameter;

        #endregion

        #region Methods

        public void DestroyItem()
        {
            Destroy(gameObject);
        }

        #endregion

        #region Properties

        public int Parameter => _parameter;

        #endregion

    }
}
