using Assets.Scripts.Infastructure;
using Assets.Scripts.Model;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class FuelItemView : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private ItemModel _itemModel;

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
                    OnFuelTrigger();
                    break;
                default:
                    break;
            }
        }

        private void OnFuelTrigger()
        {
            var playerModel = PlayerModelProvider.Instance.GetCurrentSaveType;
            playerModel.AddFuel(_itemModel.Parameter);
            HideItem();
        }

        private void HideItem()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}
