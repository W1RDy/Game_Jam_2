using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;

public class ScreenSaverActivator : MonoBehaviour
{
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
        _appearTextAnimation.SetParameters(_text);
        _appearImageAnimation.SetParameters(_image);

        _disappearTextAnimation.SetParameters(_text);
        _disappearImageAnimation.SetParameters(_image);
    }

    public void ActivateScreenSaver()
    {
        _appearTextAnimation.Play();
        _appearImageAnimation.Play(OpenScreenSaverDelegate);
    }

    public void DeactivateScreenSaver()
    {
        _disappearTextAnimation.Play();
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
