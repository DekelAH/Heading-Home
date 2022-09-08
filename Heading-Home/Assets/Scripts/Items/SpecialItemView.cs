using Assets.Scripts.Infastructure;
using Assets.Scripts.Model;
using UnityEngine;

namespace Assets.Scripts.Items
{
    class SpecialItemView : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private ItemModel _itemModel;

        #endregion

        #region Fields

        private bool _triggerFinishPortal = false;

        #endregion

        #region Consts

        private const string PLAYER_TAG = "Player";

        #endregion

        #region Methods

        private void OnTriggerEnter(Collider other)
        {
            switch (other.gameObject.tag)
            {
                case PLAYER_TAG:
                    HideItem();
                    _triggerFinishPortal = true;
                    break;
                default:
                    break;
            }
        }

        private void HideItem()
        {
            gameObject.SetActive(false);
        }

        public void SetTriggerFinishPortal(bool isTrigger)
        {
            _triggerFinishPortal = isTrigger;
        }

        #endregion

        #region Properties

        public bool FinishTrigger => _triggerFinishPortal;

        #endregion
    }
}
