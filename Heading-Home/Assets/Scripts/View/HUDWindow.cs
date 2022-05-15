using Assets.Scripts.Infastructure;
using Assets.Scripts.Model;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HUDWindow : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Slider _fuelBar;

        [SerializeField]
        private float _fuelBarSpeed;

        [SerializeField]
        private TextMeshProUGUI _currentLevel;

        #endregion

        #region Fields

        private float _timeScale;
        private float _targetFuel;
        private bool _isLerpingFuel = false;

        #endregion


        #region Methods

        private void Start()
        {
            SetUpParams();
            SetCurrentLevel();
            SubscribeToEvents();
        }

        private void OnDestroy()
        {
            var playerModel = SetPlayerModel();
            playerModel.FuelAmountChange -= OnFuelChange;
        }

        private void SetCurrentLevel()
        {
            var sceneHandler = new SceneHandler();
            _currentLevel.text = (sceneHandler.GetActiveScene + 1).ToString();
        }

        private void SetUpParams()
        {
            var playerModel = SetPlayerModel();
            _fuelBar.value = playerModel.Fuel;
        }

        private void SubscribeToEvents()
        {
            var playerModel = SetPlayerModel();
            playerModel.FuelAmountChange += OnFuelChange;
        }

        private void OnFuelChange(float fuel)
        {
            _targetFuel = fuel;
            
            _timeScale = 0f;

            if (!_isLerpingFuel)
            {
               StartCoroutine(LerpFuel());
            }
        }

        private IEnumerator LerpFuel()
        {
            var startFuel = _fuelBar.value;

            _isLerpingFuel = true;

            while (_timeScale < 1)
            {
                _timeScale += Time.deltaTime * _fuelBarSpeed;
                _fuelBar.value = Mathf.Lerp(startFuel, _targetFuel, _timeScale);

                yield return null;
            }

            _isLerpingFuel = false;
        }

        private PlayerModel SetPlayerModel()
        {
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
            return playerModel;
        }

        #endregion
    }
}
