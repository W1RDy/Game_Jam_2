using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscribeHandler : ISubscribable
{
    private Action _subscribeAction;
    private Action _unsubscribeAction;

    private SubscribeService _subscribeService;

    public SubscribeHandler(Action subscribeAction, Action unsubscribeAction)
    {
        _subscribeAction = subscribeAction;
        _unsubscribeAction = unsubscribeAction;

        _subscribeService = ServiceLocator.Instance.Get<SubscribeService>();
        Subscribe();
    }

    public void Subscribe()
    {
        _subscribeService.AddSubscribable(this);
        _subscribeAction.Invoke();
    }

    public void Unsubscribe()
    {
        _subscribeService.RemoveSubscribable(this);
        _unsubscribeAction.Invoke();
    }
}
