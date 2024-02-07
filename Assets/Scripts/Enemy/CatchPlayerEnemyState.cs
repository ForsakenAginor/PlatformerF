using UnityEngine;

public class CatchPlayerEnemyState : MonoBehaviour, IEnemyState
{
    [SerializeField] private SpriteFlipper _flipper;
    [SerializeField] private Animator _animator;

    private Enemy _enemyPatroller;
    private Transform _player;
    private IEnemyState _patrollingState;
    private float _attackRange;
    private float _distance;
    private bool _isAttacking;

    private void Awake()
    {
        _attackRange = GetComponentInChildren<Attack>().GetComponent<CircleCollider2D>().radius;
        _enemyPatroller = GetComponent<Enemy>();
        _patrollingState = GetComponent<PatrollZoneEnemyState>();
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
        const string IsAttackingAnimatorParameter = "IsAttacking";

        if (collision.TryGetComponent<Pickuper>(out _))
        {
            _enemyPatroller.State = _patrollingState;
            _animator.SetBool(IsAttackingAnimatorParameter, false);
        }
    }

    public void DoEnemyThings()
    {
        const string IsDiyingAnimatorParameter = "IsDiying";
        const string IsAttackingAnimatorParameter = "IsAttacking";

        _distance = (_player.position - transform.position).magnitude;
        _isAttacking = _distance < _attackRange;

        if (_isAttacking == false && _animator.GetBool(IsDiyingAnimatorParameter) == false)
            transform.position = Vector3.MoveTowards(transform.position, _player.position, Time.deltaTime);

        if (_animator.GetBool(IsDiyingAnimatorParameter) == false)
            _animator.SetBool(IsAttackingAnimatorParameter, _isAttacking);

        _flipper.FlipToTarget(_player);
    }
}
