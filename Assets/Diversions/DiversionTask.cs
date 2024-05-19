using UnityEngine;

public abstract class DiversionTask : MonoBehaviour
{
    protected DiversionMission _mission;

    public virtual void Init(DiversionMission mission)
    {
        _mission = mission;
    }

    public virtual void CompleteTask()
    {
        Debug.Log("Complete");
        if (transform.parent.GetComponent<CompositeTask>() is CompositeTask compositeTask) compositeTask.CompleteTask();
        else _mission.CompleteTask();
    }
}
