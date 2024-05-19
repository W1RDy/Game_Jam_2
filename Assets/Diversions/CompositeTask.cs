using System.Collections.Generic;
using UnityEngine;

public class CompositeTask : DiversionTask
{
    [SerializeField] private List<DiversionTask> _task;
    private int _completedTasks;

    public override void Init(DiversionMission mission)
    {
        base.Init(mission);
        foreach (var task in _task)
        {
            task.Init(mission);
        }
    }

    public override void CompleteTask()
    {
        _completedTasks++;
        if (_completedTasks >= _task.Count)
        {
            base.CompleteTask();
        }
    }
}
