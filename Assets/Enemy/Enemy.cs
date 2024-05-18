using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private EnemyWay _way;
    [SerializeField] private Trigger _viewTrigger;
    private Transform _viewTriggerParent;

    private EnemyMoveController _controller;

    private void Awake()
    {
        _controller = new EnemyMoveController(_way, this, _viewTrigger);
        _viewTriggerParent = _viewTrigger.transform.parent;
    }

    private void Update()
    {
        _controller.Update();
    }

    public void Move(Vector2 destination)
    {
        RotateTo(destination);
        transform.position = Vector2.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
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
