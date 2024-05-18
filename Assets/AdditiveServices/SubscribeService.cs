using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscribeService : MonoBehaviour, IService
{
    public List<ISubscribable> _subscribables = new List<ISubscribable>();

    public void AddSubscribable(ISubscribable subscribable)
    {
        _subscribables.Add(subscribable);
    }

    public void RemoveSubscribable(ISubscribable subscribable)
    {
        _subscribables.Remove(subscribable);
    }

    public void UnsubscribeAll()
    {
        var subscribablesCopy = new List<ISubscribable>(_subscribables);
        foreach (var subscribable in subscribablesCopy)
        {
            subscribable.Unsubscribe();
        }
    }

    public void OnDestroy()
    {
        UnsubscribeAll();
    }
}
