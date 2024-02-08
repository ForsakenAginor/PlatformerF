using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class AbilityView : MonoBehaviour
    {
        [SerializeField] private Ability _ability;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Counter _timer;

        private void Update()
        {
            if (_ability.IsActive)
            {
                _text.text = ShowTimer();
            }            
        }

        private void OnEnable()
        {
            _ability.ReadyToUse += OnReadyToUse;
            _ability.Activated += OnActivated;
        }

        private void OnDisable()
        {
            _ability.ReadyToUse -= OnReadyToUse;
            _ability.Activated -= OnActivated;
        }

        private void OnActivated()
        {
            _timer.Restart();
        }

        private void OnReadyToUse()
        {
            _text.text = "Ready";
        }

        private string ShowTimer()
        {
            return $"{_timer.CurrentTime: 0.00}";
        }
    }
}
