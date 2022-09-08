using Assets.Scripts.Items;
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
        private PortalHandler _finishPortalPrefab;

        [SerializeField]
        private PortalHandler _startPortalPrefab;

        #endregion

        #region Properties

        public PlayerSpaceship PlaySpaceshipPrefab => _playSpaceshipPrefab;
        public PortalHandler FinishPortalPrefab => _finishPortalPrefab;
        public PortalHandler StartPortalPrefab => _startPortalPrefab;

        #endregion
    }
}
