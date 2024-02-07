using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private CircleCollider2D _groundCheckCollider;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;
    private Vector3 _xMovement;
    private bool _isOnGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _xMovement = new Vector3(1 * _speed, 0, 0);
    }

    private void Update()
    {
        CheckingGround();

        if (Input.GetKeyDown(KeyCode.W) && _isOnGround == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_xMovement * Time.deltaTime);
            _animator.SetBool("IsRunning", true);

            if (_animator.transform.localScale.x < 0)
                FlipX();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("IsRunning", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_xMovement * Time.deltaTime * (-1));
            _animator.SetBool("IsRunning", true);

            if (_animator.transform.localScale.x > 0)
                FlipX();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool("IsRunning", false);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _animator.SetTrigger("Attack");
        }
    }

    private void FlipX()
    {
        Vector3 scaler = _animator.transform.localScale;
        scaler.x *= -1;
        _animator.transform.localScale = scaler;
    }

    private void CheckingGround()
    {
        if (_groundCheckCollider != null)
        {
            _isOnGround = Physics2D.OverlapCircle(_groundCheckCollider.transform.position, _groundCheckCollider.radius, _ground);
            _animator.SetBool("IsOnGround", _isOnGround);
        }
    }
}


