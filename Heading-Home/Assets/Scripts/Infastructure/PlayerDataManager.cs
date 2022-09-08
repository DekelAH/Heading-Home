using Assets.Scripts.StorageSystem;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class PlayerDataManager
    {
        #region Fields

        private static PlayerDataManager _instance;
        private readonly PlayerPrefsStorageSystem _playerPrefsStorage = new PlayerPrefsStorageSystem();
        private readonly LocalFileStorageSystem _localFileStorage = new LocalFileStorageSystem();

        #endregion

        #region Methods

        private void SaveToPlayerPrefs()
        {
            _playerPrefsStorage.Save();
        }

        private void LoadPlayerPrefs()
        {
            _playerPrefsStorage.Load();
        }

        private void SaveToLocalFile()
        {
            _localFileStorage.Save();
        }

        private void LoadLocalFile()
        {
            _localFileStorage.Load();
        }

        public void CheckLoadModelName()
        {
            var playerModel = PlayerModelProvider.Instance.GetCurrentSaveType;

            if (playerModel.SaveModelName == "PlayerPrefs")
            {
                LoadPlayerPrefs();
            }
            else
            {
                LoadLocalFile();
            }
        }

        public void CheckSaveModelName()
        {
            var playerModel = PlayerModelProvider.Instance.GetCurrentSaveType;

            if (playerModel.SaveModelName == "PlayerPrefs")
            {
                SaveToPlayerPrefs();
            }
            else
            {
                SaveToLocalFile();
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateInstance()
        {
            _instance = new PlayerDataManager();
            Debug.Log("Player Data Manager Created");
        }

        #endregion

        #region Properties

        public static PlayerDataManager Instance => _instance;

        #endregion
    }
}
