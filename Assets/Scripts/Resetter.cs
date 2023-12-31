using UnityEngine;

public class Resetter : MonoBehaviour
{
    [SerializeField] private float _xPosition;
    [SerializeField] private float _yPosition;

    private Vector3 _starterPosition;
    private PlayerHealth _player;

    private void Awake()
    {
        _starterPosition = new Vector3(_xPosition, _yPosition, 0);
        _player = GetComponent<PlayerHealth>();
    }

    public void Reset()
    {
        transform.position = _starterPosition;
        _player.ResetHealth();
    }
}
