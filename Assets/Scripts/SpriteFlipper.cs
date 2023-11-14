using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipToTarget(Transform target)
    {
        if (target.position.x < transform.position.x && _spriteRenderer.flipX == false)
            _spriteRenderer.flipX = true;

        if (target.position.x > transform.position.x && _spriteRenderer.flipX == true)
            _spriteRenderer.flipX = false;
    }
}
