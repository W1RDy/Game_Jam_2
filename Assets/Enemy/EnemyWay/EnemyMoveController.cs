using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : ISubscribable
{
    private EnemyWay _way;

    private Trigger _viewTrigger;

    private Enemy _enemy;
    private Player _player;

    private Vector2 _currentDestination;
    private Action MoveAction;

    private Action ChangeActionToWayMovementDelegate;
    private Action ChangeActionToTargetMovementDelegate;

    public EnemyMoveController(EnemyWay way, Enemy enemy, Trigger viewTrigger)
    {
        _way = way;

        _viewTrigger = viewTrigger;

        _enemy = enemy;
        _player = ServiceLocator.Instance.Get<Player>();

        new SubscribeHandler(Subscribe, Unsubscribe);
        MoveAction = MoveOnWay;
    }

    public void Update()
    {
        MoveAction.Invoke();
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

    private void MoveToPlayer()
    {
        if (_player._isVisible)
        {
            _enemy.Move(_player.transform.position);
        }
        else ChangeActionToWayMovementDelegate.Invoke();
    }

    private void ChangeMoveAction(bool isMoveOnWay)
    {
        if (isMoveOnWay) _currentDestination = _way.GetClosestWayPointPosition(_enemy.transform.position);
        MoveAction = isMoveOnWay ? MoveOnWay : MoveToPlayer;
    }

    public void Subscribe()
    {
        ChangeActionToWayMovementDelegate = () => ChangeMoveAction(true);
        ChangeActionToTargetMovementDelegate = () => ChangeMoveAction(false);

        _viewTrigger.IsEnter += ChangeActionToTargetMovementDelegate;
        _viewTrigger.IsExit += ChangeActionToWayMovementDelegate;
    }

    public void Unsubscribe()
    {
        _viewTrigger.IsEnter -= ChangeActionToTargetMovementDelegate;
        _viewTrigger.IsExit -= ChangeActionToWayMovementDelegate;
    }
}
