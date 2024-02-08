using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerHealth))]
public class Ability : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private int _power;
    [SerializeField] private float _duration;

    private PlayerHealth _health;
    private bool _isActive;

    public event UnityAction Activated;
    public event UnityAction ReadyToUse;

    public float Duration => _duration;
    public bool IsActive
    {
        get
        {
            return _isActive;
        }

        private set
        {
            if (value == true)
            {
                _isActive = value;
                Activated?.Invoke();
            }
            else
            {
                _isActive = value;
                ReadyToUse?.Invoke();
            }
        }
    }

    private void Awake()
    {
        _health = GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        IsActive = false;
    }

    private void Update()
    {
        if (_isActive == false && Input.GetKeyDown(KeyCode.Q) && TryFindTarget(out EnemyHealth enemy))
        {
            IsActive = true;
            StartCoroutine(StealLife(enemy));
        }
    }

    private bool TryFindTarget(out EnemyHealth enemy)
    {
        Transform[] enemies = Physics2D.OverlapCircleAll(transform.position, _radius).Select(o => o.GetComponent<Transform>()).OrderBy(o => Vector2.Distance(transform.position, o.position)).Where(o => o.TryGetComponent<Enemy>(out _)).ToArray();

        if (enemies != null && enemies.Length > 0)
        {
            enemy = enemies.First().GetComponent<EnemyHealth>();
            return true;
        }
        else
        {
            enemy = null;
            return false;
        }
    }

    private IEnumerator StealLife(EnemyHealth enemy)
    {
        float tickTime = _duration / _power;
        WaitForSeconds wait = new WaitForSeconds(tickTime);

        for (float timeFromStart = 0; timeFromStart < _duration && IsNotEqual(timeFromStart, _duration); timeFromStart += tickTime)
        {
            yield return wait;

            if (enemy.TryTakeDamage())
            {
                _health.RestoreHealth();
            }
            else
            {
                IsActive = false;
                yield break;
            }
        }

        IsActive = false;
    }

    private bool IsNotEqual(float firstValue, float secondValue)
    {
        float difference = Mathf.Abs(firstValue - secondValue);
        float presicion = 0.01f;

        return difference > presicion;
    }
}
