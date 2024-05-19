using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiversionMission : MonoBehaviour
{
    [SerializeField] private List<DiversionTask> _tasks;
    protected DiversionCounter _diversionCounter;

    private int _completedTasks;

    private void Awake()
    {
        _diversionCounter = ServiceLocator.Instance.Get<DiversionCounter>();

        foreach (var task in _tasks)
        {
            task.Init(this);
        }
    }

    public void CompleteTask()
    {
        _completedTasks++;
        if (_completedTasks >= _tasks.Count) _diversionCounter.AddDiversion();
    }
}
