using Assets.Scripts.Infastructure;
using UnityEngine;

namespace Assets.Scripts.StorageSystem
{
    public class PlayerPrefsStorageSystem : StorageSystem
    {
        #region Methods
        protected override void LoadInternal()
        {

            var playerModel = PlayerModelProvider.Instance.GetCurrentSaveType;
            Debug.Log("Loaded from PlayerPrefs!");
        }

        protected override void SaveInternal()
        {
            var playerModel = PlayerModelProvider.Instance.GetCurrentSaveType;
            PlayerPrefs.Save();
            Debug.Log("Saved to PlayerPrefs!");
        }

        #endregion
    }
}
