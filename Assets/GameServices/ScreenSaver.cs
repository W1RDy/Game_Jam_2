using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;

public class ScreenSaver : MonoBehaviour
{
    [SerializeField] private string _index;
    public string Index => _index;

    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private FadeTextAnimation _appearTextAnimation;
    [SerializeField] private FadeImageAnimation _appearImageAnimation;

    [SerializeField] private FadeImageAnimation _disappearImageAnimation;
    [SerializeField] private FadeTextAnimation _disappearTextAnimation;

    public event Action ScreenSaverClosed;
    public event Action ScreenSaverOpened;

    private void Awake()
    {
        if (_text != null) _appearTextAnimation.SetParameters(_text);
        _appearImageAnimation.SetParameters(_image);

        if (_text != null) _disappearTextAnimation.SetParameters(_text);
        _disappearImageAnimation.SetParameters(_image);
    }

    public void ActivateScreenSaver()
    {
        if (_text != null) _appearTextAnimation.Play();
        _appearImageAnimation.Play(OpenScreenSaverDelegate);
    }

    public void DeactivateScreenSaver()
    {
        if(_text != null) _disappearTextAnimation.Play();
        _disappearImageAnimation.Play(CloseScreenSaverDelegate);
    }

    private void CloseScreenSaverDelegate()
    {
        ScreenSaverClosed?.Invoke();
    }

    private void OpenScreenSaverDelegate()
    {
        ScreenSaverOpened?.Invoke();
    }
}
