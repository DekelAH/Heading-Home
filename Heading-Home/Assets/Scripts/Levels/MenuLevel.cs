using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Levels
{
    public class MenuLevel : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Button[] _levelBtns;

        #endregion

        #region Fields

        private int _levelsUnlocked;

        #endregion

        #region Methods

        private void Start()
        {
            LockGameLevels();
            UnlockLevels();
        }

        private void LockGameLevels()
        {
            for (int i = 0; i < _levelBtns.Length; i++)
            {
                _levelBtns[i].interactable = false;
            }
        }

        private void UnlockLevels()
        {
            _levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

            for (int i = 0; i < _levelsUnlocked; i++)
            {
                _levelBtns[i].interactable = true;
            }
        }

        public void OnClickLoadLevelBtn(int levelIndex)
        {
            var sceneHandler = new SceneHandler();
            sceneHandler.LoadMenuBtnLevel(levelIndex);
        }

        #endregion
    }
}
