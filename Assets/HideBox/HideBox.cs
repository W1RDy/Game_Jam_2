using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HideBox : MonoBehaviour, IInteractable
{

    private Player _player;
    public void Awake() {
        _player = ServiceLocator.Instance.Get<Player>();
    }
    public void Interact() {
        
        _player.ChangeVisible();
    }
}
