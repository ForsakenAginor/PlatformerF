using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
[RequireComponent(typeof(PatrollZoneEnemyState))]
[RequireComponent(typeof(EnemyHealth))]
[RequireComponent (typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private EnemyHealth _enemyHealth;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxCollider;

    public IEnemyState State { get; set; }

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        State = GetComponent<PatrollZoneEnemyState>();
    }

    private void OnEnable()
    {
        _enemyHealth.Died += OnDied;
    }

    private void OnDisable()
    {
        _enemyHealth.Died -= OnDied;
    }

    private void Update()
    {
        State.DoEnemyThings();
    }

    private void OnDied()
    {
        const string IsDiyingAnimatorParameter = "IsDiying";
        const string IsAttackingAnimatorParameter = "IsAttacking";

        _animator.SetBool(IsDiyingAnimatorParameter, true);
        _animator.SetBool(IsAttackingAnimatorParameter, false);
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _boxCollider.enabled = false;

        Destroy(this);
    }
}
