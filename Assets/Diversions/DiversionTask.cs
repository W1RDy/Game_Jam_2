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
        _mission.CompleteTask();
    }
}
