using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    public void FlipToTarget(Transform target)
    {
        if (target.position.x < transform.position.x && transform.localScale.x > 0)
            FlipX();

        if (target.position.x > transform.position.x && transform.localScale.x < 0)
            FlipX();
    }

    private void FlipX()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
