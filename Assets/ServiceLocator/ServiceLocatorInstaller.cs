using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocatorInstaller : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SubscribeService _subscribeService;

    private void Awake()
    {
        Bind();
    }

    private void Bind()
    {
        BindInventory();
        BindPlayer();
        BindService1();
        BindSubscribeService();
    }

    private void BindPlayer()
    {
        ServiceLocator.Instance.Register(_player);
    }

    private void BindService1()
    {

    }

    private void BindInventory()
    {
        var inventory = new Inventory();
        ServiceLocator.Instance.Register(inventory);
    }

    private void BindSubscribeService()
    {
        ServiceLocator.Instance.Register(_subscribeService);
    }
}
