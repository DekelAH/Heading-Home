using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
    public class PausedWindow : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private GameObject _pausedWindow;

        [SerializeField]
        private Button _pausedBtn;

        [SerializeField]
        private Button _MenuBtn;

        [SerializeField]
        private Button _restartBtn;

        #endregion

        #region Methods

        public void OnPausedBtnClicked()
        {
            _pausedWindow.SetActive(true);
            Time.timeScale = 0f;
        }

        public void OnMenuBtnClicked()
        {
            var sceneHandler = new SceneHandler();
            sceneHandler.LoadSpecificLevel(0);
            Time.timeScale = 1f;
        }

        public void OnRestartBtnClicked()
        {
            var sceneHandler = new SceneHandler();
            sceneHandler.ReloadLevel();
            Time.timeScale = 1f;
        }

        public void OnResumeBtnClicked()
        {
            _pausedWindow.SetActive(false);
            Time.timeScale = 1f;
        }

        #endregion
    }
}
