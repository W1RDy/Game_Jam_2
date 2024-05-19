using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemForCollect : MonoBehaviour, IItem
{
    [SerializeField] private ItemType _itemType;

    public ItemType ItemType => _itemType;

    private Inventory _inventory;
    private Player _player;

    private bool _isInInventory;
    public bool IsInteracted {private get; set; }

    public event Action ItemIsPicked;
    public event Action ItemIsThrowed;

    private void Awake()
    {
        _inventory = ServiceLocator.Instance.Get<Inventory>();
        _player = ServiceLocator.Instance.Get<Player>();
    }

    public void Interact()
    {
        if (IsInteracted) return;

        if (_isInInventory) ThrowOutItem();
        else GetItem();
    }

    private void GetItem()
    {
        _inventory.AddItem(this);

        _isInInventory = true;
        gameObject.SetActive(false);

        AudioPlayer.Instance.PlaySound("PickingUp");

        ItemIsPicked?.Invoke();
    }

    private void ThrowOutItem()
    {
        _inventory.RemoveItem(this);

        _isInInventory = false;
        transform.position = _player.transform.position;
        gameObject.SetActive(true);

        AudioPlayer.Instance.PlaySound("PickingUp");

        ItemIsThrowed?.Invoke();
    }
}
