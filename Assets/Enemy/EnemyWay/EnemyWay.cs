using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWay : MonoBehaviour
{
    [SerializeField] private List<EnemyWayPoint> _wayPoints = new List<EnemyWayPoint>();

    private EnemyWayPoint _currentWayPoint;

    private void Awake()
    {
        InitializeWay();
    }

    private void InitializeWay()
    {
        _wayPoints[_wayPoints.Count - 1].NextPoint = _wayPoints[0];
        for (int i = 1; i < _wayPoints.Count; i++)
        {
            _wayPoints[i - 1].NextPoint = _wayPoints[i];
        }
        _currentWayPoint = _wayPoints[0];
    }

    private void DebugAllVectors()
    {
        Debug.Log(_currentWayPoint.transform);
        for (int i = 0; i < 14; i++)
        {
            Debug.Log(GetNextPointDestination());
        }
    }

    public Vector2 GetClosestWayPointPosition(Vector2 position)
    {
        var minDistance = float.MaxValue;
        EnemyWayPoint closestPoint = null;

        foreach (EnemyWayPoint point in _wayPoints)
        {
            var pointPos = new Vector2(point.transform.position.x, point.transform.position.y);
            if (Vector2.Distance(position, pointPos) <= minDistance)
            {
                minDistance = Vector2.Distance(position, pointPos);
                closestPoint = point;
            }
        }

        return closestPoint.transform.position;
    }

    public Vector2 GetNextPointDestination()
    {
        SetNextWayPoint();
        return _currentWayPoint.transform.position;
    }

    private void SetNextWayPoint()
    {
        _currentWayPoint = _currentWayPoint.NextPoint;
    }
}
