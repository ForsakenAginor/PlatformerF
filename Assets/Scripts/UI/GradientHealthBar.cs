using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GradientHealthBar : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;

    private Image _image;
    private Slider _slider;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _slider = GetComponentInParent<Slider>();
    }

    public void ChangeColor()
    {
        _image.color = _gradient.Evaluate(_slider.value / _slider.maxValue);
    }
}
