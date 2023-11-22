using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected Health Health => _health;

    protected abstract void HealthChangeHandler(int value);

    private void Awake()
    {
        HealthChangeHandler(_health.MaxHealth);
    }

    private void Start()
    {
        _health.OnVariableChange += HealthChangeHandler;
    }

    private void OnDestroy()
    {
        _health.OnVariableChange -= HealthChangeHandler;
    }
}
