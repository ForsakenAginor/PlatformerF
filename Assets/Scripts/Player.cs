using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDamageTaker
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent _died;
    [SerializeField] private UnityEvent _takeDamage;
    [SerializeField] private UnityEvent _takeHeal;

    private int _health;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    public void TakeDamage()
    {
        _health--;
        _takeDamage?.Invoke();

        if(_health <= 0)
            _died?.Invoke();
    }

    public void ResetHealth()
    {
        _health = _maxHealth;
        _takeHeal?.Invoke();
    }

    private void Awake()
    {
        _health = _maxHealth;
    }
}
