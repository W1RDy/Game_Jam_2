using System;
using UnityEngine;

public abstract class LevelItem : MonoBehaviour, IItem, ISubscribable
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private float _offsetPosY;

    [SerializeField] private int _interactTime = 5;

    public ItemType ItemType => _itemType;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _sprite;

    private Vector2 _progressBarPos;

    private ProgressBarController _progressBarController;

    public event Action OnCompletedInteraction;

    private bool _isInteracted;

    private void Awake()
    {
        var progressBar = ServiceLocator.Instance.Get<ProgressBar>();
        _progressBarController = new ProgressBarController(progressBar);

        _progressBarPos = new Vector2(transform.position.x, _spriteRenderer.bounds.max.y + _offsetPosY);
        new SubscribeHandler(Subscribe, Unsubscribe);
    }

    public void Interact()
    {
        if (_isInteracted) return;
        _progressBarController.ActivateProgressBar(_interactTime, _progressBarPos);
        AudioPlayer.Instance.PlaySound("Interaction");
    }

    private void CompleteInteract()
    {
        Debug.Log("InteractCompleted");
        OnCompletedInteraction?.Invoke();
        ChangeItem();
    }

    public void InterruptInteract()
    {
        _progressBarController.Interrupt();
        AudioPlayer.Instance.StopAudio("Interaction");
    }

    public void Subscribe()
    {
        _progressBarController.OnCompleteProgressBar += CompleteInteract;
    }

    public void Unsubscribe()
    {
        _progressBarController.OnCompleteProgressBar -= CompleteInteract;
    }

    public void ChangeItem()
    {
        _isInteracted = true;
        if (_sprite != null) _spriteRenderer.sprite = _sprite;
    }
}
