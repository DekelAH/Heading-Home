using Assets.Scripts.Model;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class PlayerModelProvider
    {
        #region Consts

        private const string SAVE_SELECTOR_RESOURCE_NAME = "Save Type Selector";

        #endregion

        #region Fields

        private static PlayerModelProvider _instance;
        private static SaveTypeSelector _saveTypeSelector;

        #endregion

        #region Constructor

        private PlayerModelProvider(string saveTypeSelectorResourceName)
        {
            _saveTypeSelector = Resources.Load<SaveTypeSelector>(saveTypeSelectorResourceName);
        }

        #endregion

        #region Properties

        public static PlayerModelProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerModelProvider(SAVE_SELECTOR_RESOURCE_NAME);
                }

                return _instance;
            }
        }

        public PlayerModel GetCurrentSaveType => _saveTypeSelector.GetSaveType();
        #endregion
    }
}
