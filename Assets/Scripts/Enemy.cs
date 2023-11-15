using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
[RequireComponent(typeof(PatrollZoneEnemyState))]
public class Enemy : MonoBehaviour, IDamageTaker
{
    [SerializeField] private int _health;

    private Animator _animator;

    public IEnemyState State { get; set; }

    public void TakeDamage()
    {
        _health--;

        if (_health <= 0)
        {
            _animator.SetTrigger("IsDead");
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            rigidbody.bodyType = RigidbodyType2D.Static;
            collider.enabled = false;
            Destroy(this);
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        State = GetComponent<PatrollZoneEnemyState>();
    }

    private void Update()
    {
        State.DoEnemyThings();
    }
}
