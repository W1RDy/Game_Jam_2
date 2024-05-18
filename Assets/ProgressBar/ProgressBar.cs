using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour, IService
{
    [SerializeField] private Image _progressImage;
    private float _progressValue;

    public void SetProgressBarValue(float value, float maxValue)
    {
        _progressValue = value;
        _progressImage.fillAmount = _progressValue / maxValue;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}