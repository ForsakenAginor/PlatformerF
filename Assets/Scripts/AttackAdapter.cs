using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAdapter : MonoBehaviour
{
    private Attack _weapon;

    public void OnAttack()
    {
        _weapon.OnAttack();
    }    

    private void Awake()
    {
        _weapon = GetComponentInChildren<Attack>();
    }
}
