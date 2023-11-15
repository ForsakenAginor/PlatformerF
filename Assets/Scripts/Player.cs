using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDamageTaker
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent _died;

    private int _health;

    public void TakeDamage()
    {
        _health--;

        if(_health <= 0)
            _died?.Invoke();
    }

    public void ResetHealth()
    {
        _health = _maxHealth;
    }

    private void Awake()
    {
        _health = _maxHealth;
    }
}
