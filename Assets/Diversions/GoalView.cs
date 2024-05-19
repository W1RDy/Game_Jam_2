using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GoalView : MonoBehaviour, ISubscribable
{
    private SpriteRenderer _spriteRenderer;
    private ItemForCollect _itemForCollect;

    public void Init(ItemForCollect itemForCollect)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _itemForCollect = itemForCollect;
        new SubscribeHandler(Subscribe, Unsubscribe);
    }

    private void ActivateGoal()
    {
        _spriteRenderer.enabled = true;
    }

    private void DeactivateGoal()
    {
        _spriteRenderer.enabled = false;
    }

    public void Subscribe()
    {
        _itemForCollect.ItemIsPicked += ActivateGoal;
        _itemForCollect.ItemIsThrowed += DeactivateGoal;
    }

    public void Unsubscribe()
    {
        _itemForCollect.ItemIsPicked -= ActivateGoal;
        _itemForCollect.ItemIsThrowed -= DeactivateGoal;
    }
}