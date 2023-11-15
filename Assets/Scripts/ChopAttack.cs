using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ChopAttack : Attack
{
    [SerializeField] private LayerMask _enemyLayerMask;

    private CircleCollider2D _weaponCollider;

    protected override Collider2D[] GetHitTargets()
    {
        _weaponCollider.enabled = true;
        Collider2D[] results = Physics2D.OverlapCircleAll(transform.position, _weaponCollider.radius, _enemyLayerMask);
        _weaponCollider.enabled = false;
        return results;
    }

    private void Awake()
    {
        _weaponCollider = GetComponent<CircleCollider2D>();
        _weaponCollider.enabled = false;
    }
}
