using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    [SerializeField] private Animator _animator;
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

        _animator.SetFloat("Horizontal", _agent.desiredVelocity.x);
        _animator.SetFloat("Vertical", _agent.desiredVelocity.y);
        _animator.SetFloat("Speed", _agent.desiredVelocity.sqrMagnitude);
    }

    public void Move(Vector2 destination)
    {
        _agent.SetDestination(destination);
        RotateTo(_agent.desiredVelocity.normalized);
    }

    private void RotateTo(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            var rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;

            _viewTriggerParent.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));
        }
    }
}
