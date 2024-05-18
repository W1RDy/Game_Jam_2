using UnityEngine;

public abstract class LevelItem : MonoBehaviour, IItem, ISubscribable
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private float _offsetPosY;

    [SerializeField] private int _interactTime = 5;

    public ItemType ItemType => _itemType;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector2 _progressBarPos;

    private ProgressBarController _progressBarController;

    private void Awake()
    {
        var progressBar = ServiceLocator.Instance.Get<ProgressBar>();
        _progressBarController = new ProgressBarController(progressBar);

        _progressBarPos = new Vector2(transform.position.x, _spriteRenderer.bounds.max.y + _offsetPosY);
        new SubscribeHandler(Subscribe, Unsubscribe);
    }

    public void Interact()
    {
        _progressBarController.ActivateProgressBar(_interactTime, _progressBarPos);
    }

    private void CompleteInteract()
    {
        Debug.Log("InteractCompleted");
    }

    public void InterruptInteract()
    {
        _progressBarController.Interrupt();
    }

    public void Subscribe()
    {
        _progressBarController.OnCompleteProgressBar += CompleteInteract;
    }

    public void Unsubscribe()
    {
        _progressBarController.OnCompleteProgressBar -= CompleteInteract;
    }
}
