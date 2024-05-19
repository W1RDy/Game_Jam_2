using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class FadeImageAnimation : CustomAnimation
{
    [SerializeField] private float _endFade;
    [SerializeField] private float _startFade;

    [SerializeField] private float _fadeDuration;

    private Image _image;

    public void SetParameters(Image image)
    {
        _image = image;
    }

    public override void Play()
    {
        base.Play();

        _sequence = DOTween.Sequence();
        _sequence
            .Append(_image.DOFade(_endFade, _fadeDuration))
            .AppendCallback(Finish);
    }

    public override void Release()
    {
        base.Release();
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _endFade);
    }
}