using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageTaker
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

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

    public delegate void HealthChangeDelegate(int value);

    public event HealthChangeDelegate HealthChange;

    public abstract void TakeDamage();

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
}
