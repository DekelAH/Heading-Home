using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Levels
{
    public class MenuLevel : MonoBehaviour
    {
        #region Editor

        #endregion

        #region Methods

        public void OnClickIntroBtn()
        {
            var sceneManager = new SceneHandler();
            sceneManager.NextLevel();
        }

        #endregion
    }
}
