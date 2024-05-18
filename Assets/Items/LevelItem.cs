using UnityEngine;

public abstract class LevelItem : MonoBehaviour, IItem
{
    [SerializeField] private ItemType _itemType;

    public ItemType ItemType => _itemType;

    public void Interact()
    {
        Debug.Log("Interact with level item");
    }
}
