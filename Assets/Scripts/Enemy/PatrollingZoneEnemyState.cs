using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteFlipper))]
public class PatrollZoneEnemyState : MonoBehaviour, IEnemyState
{
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private int _currentTargetIndex;
    private SpriteFlipper _flipper;

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

    private void Awake()
    {
        _flipper = GetComponent<SpriteFlipper>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }
}

