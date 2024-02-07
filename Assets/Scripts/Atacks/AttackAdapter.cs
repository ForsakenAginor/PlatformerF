using UnityEngine;

public class AttackAdapter : MonoBehaviour
{
    private Attack _weapon;

    private void Awake()
    {
        _weapon = GetComponentInChildren<Attack>();
    }

    public void OnAttack()
    {
        _weapon.OnAttack();
    }    
}
