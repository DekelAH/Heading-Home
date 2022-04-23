using UnityEngine;

namespace Assets.Scripts.Factories
{
    public abstract class ItemFactoryBase : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Object _itemPrefabRef;

        #endregion

        #region Methods

        public virtual GameObject CreateItem(Vector3 spawnSpot)
        {
            var itemInstance = Instantiate(_itemPrefabRef, spawnSpot, Quaternion.identity) as GameObject;
            return itemInstance;
        }

        #endregion
    }
}
