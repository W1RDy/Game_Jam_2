using TMPro;
using UnityEngine;

public class DiversionCounter : MonoBehaviour, IService
{
    [SerializeField] private TextMeshProUGUI _diversionText;

    private int _diversionsCount = 0;
    private int _maxDiversionCount = 2;

    private GameStateController _gameStateController;

    private void Awake()
    {
        _gameStateController = ServiceLocator.Instance.Get<GameStateController>();
        SetDiversions(0);
    }

    public void AddDiversion()
    {
        _diversionsCount++;
        SetDiversions(_diversionsCount);
        if (_diversionsCount >= _maxDiversionCount) _gameStateController.CompleteLevel();
    }

    private void SetDiversions(int diversionCount)
    {
        _diversionText.text = "Диверсии " + diversionCount + "/" + _maxDiversionCount;
    }
}