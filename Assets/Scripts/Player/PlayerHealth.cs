using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    [SerializeField] private UnityEvent _died;

    public override void TakeDamage()
    {
        CurrentHealth--;

        if(CurrentHealth <= 0)
            _died?.Invoke();
    }

    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
