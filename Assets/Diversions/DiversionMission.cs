using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class DiversionMission : MonoBehaviour
{
    [SerializeField] private List<DiversionTask> _missions;
    protected DiversionCounter _diversionCounter;

    private int _completedTasks;

    private void Awake()
    {
        _diversionCounter = ServiceLocator.Instance.Get<DiversionCounter>();
    }

    public void CompleteTask()
    {
        _completedTasks++;
        if (_completedTasks >= _missions.Count) _diversionCounter.AddDiversion();
    }
}

public abstract class DiversionTask : MonoBehaviour
{
    protected DiversionMission _mission;

    public void Init(DiversionMission mission)
    {
        _mission = mission;
    }

    private void Update()
    {
        CheckTaskCondition();
    }

    public virtual void CompleteTask()
    {
        _mission.CompleteTask();
    }

    protected virtual void CheckTaskCondition()
    {

    }
}

public class DiversionTaskOnInteracting : DiversionTask
{
    protected override void CheckTaskCondition()
    {
        base.CheckTaskCondition();
    }
}

public class DiversionTaskOnMoving : DiversionTask
{
    protected override void CheckTaskCondition()
    {
        base.CheckTaskCondition();
    }
}

public class DiversionCounter : MonoBehaviour, IService
{
    [SerializeField] private TextMeshProUGUI _diversionText;
    private int _diversionsCount = 0;
    private int _maxDiversionCount = 2;

    public void AddDiversion()
    {
        _diversionsCount++;
        SetDiversions(_diversionsCount);
    }

    private void SetDiversions(int diversionCount)
    {
        _diversionText.text = "Диверсии " + diversionCount + "/" + _maxDiversionCount;
    }
}