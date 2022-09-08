using Assets.Scripts.Items;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [CreateAssetMenu(menuName = "Data Models/Item Model", fileName = "Item Model")]
    public class ItemModel : ScriptableObject
    {
        #region Editor

        [SerializeField]
        private Object _itemPrefabRef;

        [SerializeField]
        private int _parameter;

        #endregion

        #region Properties

        public int Parameter => _parameter;

        #endregion
    }
}
