using System;
using UnityEngine;

public class TaskTrigger : Trigger
{
    [SerializeField] private ItemForCollect _itemForCollect;
    [SerializeField] private GoalView _goalView;

    public event Action ItemDelivered;

    private void Awake()
    {
        _goalView.Init(_itemForCollect);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ItemForCollect")
        {
            if (collision.gameObject.GetComponent<ItemForCollect>() == _itemForCollect)
            {
                ItemDelivered?.Invoke();
                _itemForCollect.ChangeItem();
            }
        }
    }
}
