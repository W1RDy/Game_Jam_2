using System;
using UnityEngine;
using DG.Tweening;

public class ProgressBarController 
{
    private ProgressBar _progressBar;
    public event Action OnCompleteProgressBar;

    private Sequence _sequence;

    public ProgressBarController(ProgressBar progressBar)
    {
        _progressBar = progressBar;
    }

    public void ActivateProgressBar(float time, Vector2 position)
    {
        _progressBar.transform.position = position;
        _progressBar.Activate();
        ProgressProcess(time);
    }

    private void HideProgressBar()
    {
        _progressBar.StopAllCoroutines();
        _progressBar.Deactivate();
    }

    public void Interrupt()
    {
        HideProgressBar();
        _sequence.Kill();
    }

    private void ProgressProcess(float time)
    {
        _sequence = DOTween.Sequence();

        _sequence
            .Append(DOTween.To(() => 0f, x => { _progressBar.SetProgressBarValue(x, time); }, time, time).SetEase(Ease.Linear))
            .OnComplete(() =>
            {
                OnCompleteProgressBar?.Invoke();
                HideProgressBar();
            });
    }
}
