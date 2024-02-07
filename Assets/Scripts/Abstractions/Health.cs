using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour, IDamageTaker
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event UnityAction<int> HealthChange;

    public int MaxHealth => _maxHealth;
    protected int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            if (_currentHealth == value)
                return;

            _currentHealth = value;

            if (HealthChange != null)
                HealthChange(_currentHealth);
        }
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public abstract void TakeDamage();
}
