using System;

public class EnemyHealth : Health
{
    public event Action Died;

    public override void TakeDamage()
    {
        CurrentHealth--;

        if (CurrentHealth <= 0)
            Died?.Invoke();         
    }

    public bool TryTakeDamage()
    {
        if(CurrentHealth <= 0)
        {
            return false;
        }
        else
        {
            TakeDamage();
            return true;
        }
    }
}
