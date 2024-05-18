public interface IItem
{
    public ItemType ItemType { get; }

    public void Interact();
}