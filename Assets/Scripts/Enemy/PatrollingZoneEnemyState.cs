using UnityEngine;

public class PatrollZoneEnemyState : MonoBehaviour, IEnemyState
{
    [SerializeField] private Transform _path;
    [SerializeField] private SpriteFlipper _flipper;

    private Transform[] _points;
    private int _currentTargetIndex;

    private void Awake()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)        
            _points[i] = _path.GetChild(i);

        foreach (Transform point in _points)
            point.SetParent(null, true);
        
    }

    public void DoEnemyThings()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_currentTargetIndex].position, Time.deltaTime);
        _flipper.FlipToTarget(_points[_currentTargetIndex]);
    }

    public void SetNextPoint()
    {
        _currentTargetIndex++;

        if (_currentTargetIndex == _points.Length)
            _currentTargetIndex = 0;
    }
}

