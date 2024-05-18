using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    private NavMeshAgent _agent;

    [SerializeField] private EnemyWay _way;
    [SerializeField] private Trigger _viewTrigger;
    private Transform _viewTriggerParent;

    private EnemyMoveController _controller;

    private void Awake()
    {
        _controller = new EnemyMoveController(_way, this, _viewTrigger);
        _viewTriggerParent = _viewTrigger.transform.parent;

        _agent = GetComponent<NavMeshAgent>();

        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        _agent.speed = _speed;
    }

    private void Update()
    {
        _controller.Update();
    }

    public void Move(Vector2 destination)
    {
        RotateTo(destination);
        _agent.SetDestination(destination);
    }

    private void RotateTo(Vector2 destination)
    {
        if (destination != Vector2.zero)
        {
            Vector2 directionToTarget = (destination - new Vector2(_viewTriggerParent.position.x, _viewTriggerParent.position.y)).normalized;

            var rotationAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg + 180;

            _viewTriggerParent.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));
        }
    }
}
