using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IService
{
    private IItem _currentItem;

    public void AddItem(IItem item)
    {
        _currentItem = item;
        Debug.Log("ItemCollected");
    }

    public void RemoveItem(IItem item)
    {
        _currentItem = null;
    }

    public bool HasItem(ItemType type)
    {
        return _currentItem != null && _currentItem.ItemType == type;
    }

    public bool TryGetItem(out IItem item)
    {
        item = null;
        if (_currentItem != null)
        {
            item = _currentItem;
            return true;
        }
        return false;
    }
}
