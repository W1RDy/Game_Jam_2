using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour, IService
{
    public event Action OnLevelStarted;
    public event Action OnLevelCompleted;
    public event Action OnLevelFailed;

    private DataService _dataService;

    private void Start()
    {
        OnLevelStarted?.Invoke();
    }

    public void FailLevel()
    {
        OnLevelFailed?.Invoke();
    }

    public void CompleteLevel()
    {
        OnLevelCompleted?.Invoke();
        _dataService.SaveData(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
