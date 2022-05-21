using System.Collections;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class PortalHandler : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Object _portalPrefabInstance;

        [SerializeField]
        private float _portalSizeChangeDuration;

        #endregion

        #region Fields

        private GameObject _portal;

        private float _timeScale;
        private Vector3 _targetSize;

        #endregion

        #region Methods

        private void Start()
        {
            _portal = SetPortalInstance(_portalPrefabInstance);
        }

        private GameObject SetPortalInstance(Object portalPrefabInstance)
        {
            var portal = portalPrefabInstance as GameObject;
            return portal;
        }

        public IEnumerator LerpPortalSize()
        {
            _targetSize = new Vector3(0, 0, 0);
            var startSize = _portal.transform.localScale;

            while (_timeScale < 1)
            {
                _timeScale += Time.deltaTime * _portalSizeChangeDuration;
                _portal.transform.localScale = Vector3.Lerp(startSize, _targetSize, _timeScale);

                yield return null;
            }
        }

        #endregion
    }
}
