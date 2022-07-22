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
        private float _sizeChangeDuration;

        [SerializeField]
        private ParticleSystem _finishEffect;

        [SerializeField]
        private ParticleSystem _finishShockwave;

        #endregion

        #region Fields

        private GameObject _portal;

        #endregion

        #region Methods

        private void Awake()
        {
            _portal = SetPortalInstance(_portalPrefabInstance);
        }

        private GameObject SetPortalInstance(Object portalPrefabInstance)
        {
            var portal = portalPrefabInstance as GameObject;
            return portal;
        }

        public IEnumerator LerpPortalShrinkSize()
        {
            var targetSize = Vector3.zero;
            var startSize = _portal.transform.localScale;
            var timeScale = 0f;

            while (timeScale < 1)
            {
                timeScale += Time.deltaTime * _sizeChangeDuration;
                _portal.transform.localScale = Vector3.Lerp(startSize, targetSize, timeScale);

                yield return null;
            }

            if (_portal.transform.localScale == targetSize)
            {
                _finishEffect.Play();
                _finishShockwave.Play();
            }
        }

        public IEnumerator LerpPortalGrowSize()
        {
            var targetSize = new Vector3(1.5f, 1.5f, 1.5f);
            var startSize = Vector3.zero;
            var timeScale = 0f;

            while (timeScale < 1)
            {
                timeScale += Time.deltaTime * _sizeChangeDuration;
                _portal.transform.localScale = Vector3.Lerp(startSize, targetSize, timeScale);

                yield return null;
            }
        }

        #endregion
    }
}
