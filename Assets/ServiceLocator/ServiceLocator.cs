using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    public static ServiceLocator Instance { get; private set; }

    private Dictionary<Type, IService> _services;

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
    }

    public T Get<T>() where T : IService
    {
        var type = typeof(T);
        if (!_services.ContainsKey(type)) throw new System.ArgumentException("Service doesn't exist!");
        return (T)_services[type];
    }
}
