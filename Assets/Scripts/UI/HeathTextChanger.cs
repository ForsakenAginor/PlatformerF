using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathTextChanger : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void SetText(Player player)
    {
        _text.text = player.Health + " / " + player.MaxHealth;
    }
}
