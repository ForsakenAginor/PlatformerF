using UnityEngine;

public class PatrollPoint : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PatrollZoneEnemyState>(out PatrollZoneEnemyState enemy))
            enemy.SetNextPoint();
    }    
}
