using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteFlipper))]
public class CatchPlayerEnemyState : MonoBehaviour, IEnemyState
{
    private Enemy _enemyPatroller;
    private Transform _player;
    private IEnemyState _patrollingState;
    private SpriteFlipper _flipper;

    public void DoEnemyThings()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, Time.deltaTime);
        _flipper.FlipToTarget(_player);
    }

    private void Awake()
    {
        _enemyPatroller = GetComponent<Enemy>();
        _patrollingState = GetComponent<PatrollZoneEnemyState>();
        _flipper = GetComponent<SpriteFlipper>();
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
            _enemyPatroller.State = _patrollingState;
    }
}
