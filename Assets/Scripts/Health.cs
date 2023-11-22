using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

            if (OnVariableChange != null)
                OnVariableChange(_currentHealth);
        }
    }

    public delegate void OnVariableChangeDelegate(int value);

    public event OnVariableChangeDelegate OnVariableChange;


    public abstract void TakeDamage();

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
}
