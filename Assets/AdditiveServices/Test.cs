using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private GameStateController _gameStateController;

    private void Awake()
    {
        _gameStateController = ServiceLocator.Instance.Get<GameStateController>();
    }

    private void Start()
    {
        _gameStateController.CompleteLevel();
    }
}
