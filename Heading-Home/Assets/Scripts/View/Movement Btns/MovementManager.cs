using UnityEngine;

namespace Assets.Scripts.View.Movement_Btns
{
    public class MovementManager : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private RotateLeft _rotateLeft;

        [SerializeField]
        private RotateRight _rotateRight;

        [SerializeField]
        private Thrust _thrust;

        #endregion

        #region Methods

        public void DisableBtns()
        {
            _thrust.enabled = false;
            _rotateLeft.enabled = false;
            _rotateRight.enabled = false;
        }

        #endregion
    }
}
