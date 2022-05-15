using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneHandler
    {
        #region Methods

        private int GetActiveSceneIndex()
        {
            var getCurrentScene = SceneManager.GetActiveScene().buildIndex;
            return getCurrentScene;
        }

        public void ReloadLevel()
        {
            var currentSceneIndex = GetActiveSceneIndex();
            SceneManager.LoadScene(currentSceneIndex);
        }

        public void NextLevel()
        {
            var currentSceneIndex = GetActiveSceneIndex();
            var nextSceneIndex = ++currentSceneIndex;

            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }

            SceneManager.LoadScene(nextSceneIndex);
        }

        #endregion

        #region Properties

        public int GetActiveScene => GetActiveSceneIndex();


        #endregion
    }
}
