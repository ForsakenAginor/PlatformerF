using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ThrustAttack : Attack
{
    [SerializeField] private LayerMask _enemyLayerMask;

    private BoxCollider2D _weaponCollider;

    protected override Collider2D[] GetHitTargets()
    {
        _weaponCollider.enabled = true;
        Collider2D[] results = Physics2D.OverlapBoxAll(transform.position, _weaponCollider.size, transform.eulerAngles.z, _enemyLayerMask);
        _weaponCollider.enabled = false;
        return results;
    }

    private void Awake()
    {
        _weaponCollider = GetComponent<BoxCollider2D>();
        _weaponCollider.enabled = false;
    }
}
