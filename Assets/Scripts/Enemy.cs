using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
[RequireComponent(typeof(PatrollZoneEnemyState))]
public class Enemy : MonoBehaviour
{
    public IEnemyState State { get; set; }

    private void Awake()
    {
        State = GetComponent<PatrollZoneEnemyState>();
    }

    private void Update()
    {
        State.DoEnemyThings();
    }
}
