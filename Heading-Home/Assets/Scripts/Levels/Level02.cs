using Assets.Scripts.View;

namespace Assets.Scripts.Levels
{
    public class Level02 : Level01
    {
        #region Fields

        private PortalHandler _startPortalInstance;

        #endregion

        #region Methods

        private void Start()
        {
            SetGameObjects();
            StartLevel();
        }

        protected override void SetGameObjects()
        {
            base.SetGameObjects();
            _startPortalInstance = _spawner.SpawnStartPortal(_spawner.StartPortalSpawnPoint.position, _levelModel.StartPortalPrefab);
        }

        private void StartLevel()
        {
            if (_playerSpaceshipInstance != null)
            {
                StartCoroutine(_startPortalInstance.LerpPortalGrowSize());
            }
            else
            {
                return;
            }
        }

        #endregion
    }
}

