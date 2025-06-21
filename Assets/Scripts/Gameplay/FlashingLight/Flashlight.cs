using System;
using Configs.Gameplay;
using CustomEditorAttributes;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay.FlashingLight
{
    public class Flashlight : MonoBehaviour
    {
        private const float UPDATE_RATE = 0.25f;
        
        [PimpingHeader("References", HeaderColor.Navy)]
        [SerializeField] private FlashlightControl _flashlightControl;
        [SerializeField] private Transform _light;
        [SerializeField] private Light _lightSource;
        [SerializeField] private FlashlightConfig _config;

        private float _currentBatteryCharge;
        private bool _currentState;
        private float _maxIntensity;
        
        public event Action Discharged;

        private void Awake()
        {
            _currentBatteryCharge = _config.MaxBatteryCharge;
            _maxIntensity = _lightSource.intensity;
            
            _flashlightControl.ChangedState += OnChangedState;
        }

        private void OnDestroy()
        {
            _flashlightControl.ChangedState -= OnChangedState;
        }

        private void OnChangedState(bool state)
        {
            Toggle(state);
        }

        private void Toggle(bool state)
        {
            _currentState = state;
            _light.gameObject.SetActive(_currentState);

            if (state)
                UseCharge();
            else
                ReplenishCharge();
        }

        private async void ReplenishCharge()
        {
            try
            {
                await UniTask.WaitForSeconds(_config.DelayForReplenish,cancellationToken: gameObject.GetCancellationTokenOnDestroy());
            
                while (!_currentState)
                {
                    IncreaseCharge();
                    await UniTask.WaitForSeconds(UPDATE_RATE,cancellationToken: gameObject.GetCancellationTokenOnDestroy());
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void IncreaseCharge()
        {
            _currentBatteryCharge = Mathf.Clamp(_currentBatteryCharge + _config.IncreaseValue, 0f, _config.MaxBatteryCharge);
        }

        private async void UseCharge()
        {
            try
            {
                while (_currentState)
                {
                    _lightSource.intensity = Mathf.Lerp(0f, _maxIntensity, _currentBatteryCharge / _config.MaxBatteryCharge * Time.deltaTime);
                    DecreaseCharge();
                    await UniTask.WaitForSeconds(UPDATE_RATE,cancellationToken: gameObject.GetCancellationTokenOnDestroy());
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void DecreaseCharge()
        {
            if (_currentBatteryCharge <= 0)
            {
                Discharged?.Invoke();
                _currentState = false;
            }

            _currentBatteryCharge = Math.Clamp(_currentBatteryCharge - _config.DecreaseValue, 0f, _config.MaxBatteryCharge);
        }
    }
}