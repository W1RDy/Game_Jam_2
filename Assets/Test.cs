using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = ServiceLocator.Instance.Get<Player>();
        _player.HelloWorld();
    }
}
