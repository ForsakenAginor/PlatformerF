using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TextHealthDisplay : HealthDisplay
{
    [SerializeField] private Text _text;

    protected override void HealthChangeHandler(int value)
    {
        _text.text = value + " / " + Health.MaxHealth;
    }
}
