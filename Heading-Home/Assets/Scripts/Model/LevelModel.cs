using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [CreateAssetMenu(menuName = "Data Models/Level Model", fileName = "Level Model")]
    public class LevelModel : ScriptableObject
    {
        #region Editor

        [SerializeField]
        private PlayerSpaceship _playSpaceshipPrefab;

        [SerializeField]
        private PortalHandler _finishPortal;

        [SerializeField]
        private PortalHandler _startPortal;

        #endregion

        #region Properties

        public PlayerSpaceship PlaySpaceshipPrefab => _playSpaceshipPrefab;
        public PortalHandler FinishPortal => _finishPortal;
        public PortalHandler StartPortal => _startPortal;

        #endregion
    }
}
