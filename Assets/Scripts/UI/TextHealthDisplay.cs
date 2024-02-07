using UnityEngine;
using UnityEngine.UI;

public class TextHealthDisplay : HealthDisplay
{
    [SerializeField] private Text _text;

    protected override void OnHealthChange(int value)
    {
        _text.text = value + " / " + Health.MaxHealth;
    }
}
