using UnityEngine;

public class ItemInteractor
{
    private LevelItem _levelItem;

    public void InteractWithItem(Inventory inventory, Vector2 position)
    {
        if (_levelItem == null)
        {
            IItem item;
            if (inventory.TryGetItem(out item))
            {
                item.Interact();
            }
            else
            {
                item = FinderObjects.FindItemByCircle(1, position);

                if (item != null) item.Interact();
                if (item as LevelItem != null) _levelItem = item as LevelItem;
            }
        }
    }

    public void StopInteractWithItem()
    {
        if (_levelItem != null) _levelItem.InterruptInteract();
        _levelItem = null;
    }
}