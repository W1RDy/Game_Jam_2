using System;
using UnityEngine;

public class DiversionTaskOnMoving : DiversionTask, ISubscribable
{
    [SerializeField] private TaskTrigger _trigger;

    public override void Init(DiversionMission mission)
    {
        base.Init(mission);
        new SubscribeHandler(Subscribe, Unsubscribe);
    }

    public void Subscribe()
    {
        _trigger.ItemDelivered += CompleteTask;
    }

    public void Unsubscribe()
    {
        _trigger.ItemDelivered -= CompleteTask;
    }
}