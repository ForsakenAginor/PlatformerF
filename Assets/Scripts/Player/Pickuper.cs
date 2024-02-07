using UnityEngine;

public class Pickuper : MonoBehaviour
{ 
    private PlayerHealth _player;

    private void Awake()
    {
        _player = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Medpack>(out _))
            _player.ResetHealth();

        if (collision.TryGetComponent<PickupedThing>(out PickupedThing thing))
            thing.Destroy();
    }
}
