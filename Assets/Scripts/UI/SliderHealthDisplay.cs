using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealthDisplay : HealthDisplay
{
    [SerializeField] private Slider _slider;

    protected override void OnHealthChange(int value)
    {
        _slider.maxValue = Health.MaxHealth;
        _slider.value = value;
    }
}
