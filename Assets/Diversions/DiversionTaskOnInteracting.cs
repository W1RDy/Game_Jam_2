using UnityEngine;

public class DiversionTaskOnInteracting : DiversionTask, ISubscribable
{
    [SerializeField] private LevelItem _levelItem;

    public override void Init(DiversionMission mission)
    {
        base.Init(mission);
        new SubscribeHandler(Subscribe, Unsubscribe);
    }

    public void Subscribe()
    {
        _levelItem.OnCompletedInteraction += CompleteTask;
    }

    public void Unsubscribe()
    {
        _levelItem.OnCompletedInteraction -= CompleteTask;
    }
}
