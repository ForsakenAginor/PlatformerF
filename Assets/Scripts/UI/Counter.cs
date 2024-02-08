using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _currentTime;

    public float CurrentTime => _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;   
    }

    public void Restart()
    {
        _currentTime = 0;
    }
}
