using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour, ISubscribable
{
    public static ServiceLocator Instance { get; private set; }

    private Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(Instance);
    }

    public void Register<T>(T service) where T : IService
    {
        var type = service.GetType();
        if (!_services.ContainsKey(type)) _services.Add(type, service);
        else throw new System.ArgumentException("Service already exists!");

        if (service as SubscribeService != null) new SubscribeHandler(Subscribe, Unsubscribe);
    }

    public T Get<T>() where T : IService
    {
        var type = typeof(T);
        if (!_services.ContainsKey(type)) throw new System.ArgumentException("Service doesn't exist!");
        return (T)_services[type];
    }

    public void UnregisterServices()
    {
        _services.Clear();
    }

    public void Subscribe()
    {

    }

    public void Unsubscribe()
    {
        UnregisterServices();
    }
}
