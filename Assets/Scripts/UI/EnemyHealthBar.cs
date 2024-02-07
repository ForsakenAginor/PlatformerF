using UnityEngine;

namespace Assets.Scripts.UI
{
    public class EnemyHealthBar : SmoothSliderHealthDisplay
    {
        private void OnEnable()
        {
            if (Health is EnemyHealth enemyHealth)
                enemyHealth.Died += OnDied;                
        }

        private void OnDisable()
        {
            if (Health is EnemyHealth enemyHealth)
                enemyHealth.Died -= OnDied;
        }

        private void OnDied()
        {
            var canvasGroup = GetComponentInParent<CanvasGroup>();

            if (canvasGroup != null)
                canvasGroup.alpha = 0;
        }
    }
}
