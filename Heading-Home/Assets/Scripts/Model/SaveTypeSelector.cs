using UnityEngine;

namespace Assets.Scripts.Model
{
    [CreateAssetMenu(menuName = "Models/Save Type Selector", fileName = "Save Type Selector")]
    public class SaveTypeSelector : ScriptableObject
    {
        #region Editor

        [SerializeField]
        private SaveType _saveType;

        [SerializeField]
        private PlayerModel _playerModel;

        #endregion

        #region Methods

        public PlayerModel GetSaveType()
        {
            switch (_saveType)
            {
                case SaveType.LocalFile:
                    _playerModel.SetSaveModelName("LocalFile");
                    return _playerModel;
                case SaveType.PlayerPrefs:
                    _playerModel.SetSaveModelName("PlayerPrefs");
                    return _playerModel;
                default:
                    return null;
            }
        }

        #endregion
    }
}
