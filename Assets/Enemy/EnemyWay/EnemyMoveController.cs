using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController
{
    private EnemyWay _way;
    private Enemy _enemy;

    private Vector2 _currentDestination;

    public EnemyMoveController(EnemyWay way, Enemy enemy)
    {
        _way = way;
        _enemy = enemy;
    }

    public void Update()
    {
        MoveOnWay();
    }

    private bool IsEnemyOnDestination()
    {
        return _currentDestination == new Vector2(_enemy.transform.position.x, _enemy.transform.position.y);
    }

    private void MoveOnWay()
    {
        if (IsEnemyOnDestination())
        {
            _currentDestination = _way.GetNextPointDestination();
        }
        _enemy.Move(_currentDestination);
    }
}
