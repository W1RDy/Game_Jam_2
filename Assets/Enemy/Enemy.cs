using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private EnemyWay _way;

    private EnemyMoveController _controller;

    private void Awake()
    {
        _controller = new EnemyMoveController(_way, this);
    }

    private void Update()
    {
        _controller.Update();
    }

    public void Move(Vector2 destination)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
    }
}
