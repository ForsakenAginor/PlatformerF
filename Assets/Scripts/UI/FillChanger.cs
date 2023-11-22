using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void FillHealthBar(Player player)
    {
        _slider.maxValue = player.MaxHealth;
        _slider.value = player.Health;
    }
}
