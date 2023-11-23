using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteFlipper))]
public class CatchPlayerEnemyState : MonoBehaviour, IEnemyState
{
    private Animator _animator;
    private Enemy _enemyPatroller;
    private Transform _player;
    private IEnemyState _patrollingState;
    private SpriteFlipper _flipper;
    private float _attackRange;
    private float _distance;
    private bool _isAttacking;

    private void Awake()
    {
        _attackRange = GetComponentInChildren<Attack>().GetComponent<CircleCollider2D>().radius;
        _enemyPatroller = GetComponent<Enemy>();
        _patrollingState = GetComponent<PatrollZoneEnemyState>();
        _flipper = GetComponent<SpriteFlipper>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Pickuper>(out Pickuper player))
        {
            _player = player.transform;
            _enemyPatroller.State = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Pickuper>(out _))
        {
            _enemyPatroller.State = _patrollingState;
            _animator.SetBool("IsAttacking", false);
        }
    }

    public void DoEnemyThings()
    {
        _distance = (_player.position - transform.position).magnitude;
        _isAttacking = _distance < _attackRange;

        if (_isAttacking == false)
            transform.position = Vector3.MoveTowards(transform.position, _player.position, Time.deltaTime);

        _animator.SetBool("IsAttacking", _isAttacking);
        _flipper.FlipToTarget(_player);
    }
}
