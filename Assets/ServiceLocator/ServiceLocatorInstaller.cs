using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocatorInstaller : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        Bind();
    }

    private void Bind()
    {
        BindPlayer();
        BindService1();
    }

    private void BindPlayer()
    {
        ServiceLocator.Instance.Register(_player);
    }

    private void BindService1()
    {

    }
}
