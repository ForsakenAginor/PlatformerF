using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public void OnAttack()
    {
        Collider2D[] targets = GetHitTargets();

        foreach (var target in targets)
        {
            if(target.TryGetComponent<IDamageTaker>(out IDamageTaker enemy))
            {
                enemy.TakeDamage();        
                Knockback(target.transform);
            }
        }
    }

    protected abstract Collider2D[] GetHitTargets();

    private void Knockback(Transform target)
    {
        if(transform.position.x < target.position.x)
        {
            target.Translate(1, 0, 0);
        }
        else if (transform.position.x > target.position.x)
        {
            target.Translate(-1, 0, 0);
        }
    }
}
