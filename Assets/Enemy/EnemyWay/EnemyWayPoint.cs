using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayPoint : MonoBehaviour
{
    private EnemyWayPoint _nextPoint;
    public EnemyWayPoint NextPoint
    {
        get => _nextPoint;
        set => _nextPoint = value;
    }
}
