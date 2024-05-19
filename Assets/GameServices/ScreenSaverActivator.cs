using UnityEngine;
using System;
using System.Collections.Generic;

public class ScreenSaverActivator : MonoBehaviour, ISubscribable
{
    [SerializeField] private List<ScreenSaver> _screenSavers;

    public bool IsScreenSaverActivate { get; private set; }

    private void Awake()
    {
        new SubscribeHandler(Subscribe, Unsubscribe);
    }

    public void ActivateScreenSaver(string index)
    {
        var screenSaver = GetScreenSaver(index);
        screenSaver.ActivateScreenSaver();
    }

    public void DeactivateScreenSaver(string index)
    {
        var screenSaver = GetScreenSaver(index);
        screenSaver.DeactivateScreenSaver();
    }

    private ScreenSaver GetScreenSaver(string index)
    {
        foreach (var screenSaver in _screenSavers)
        {
            if (screenSaver.Index == index) return screenSaver;
        }
        return null;
    }

    private void OpenedScreenSaverDelegate()
    {
        IsScreenSaverActivate = true;
    }

    private void ClosedScreenSaverDelegate()
    {
        IsScreenSaverActivate = false;
    }

    public void Subscribe()
    {
        foreach (var screenSaver in _screenSavers)
        {
            screenSaver.ScreenSaverOpened += OpenedScreenSaverDelegate;
            screenSaver.ScreenSaverClosed += ClosedScreenSaverDelegate;
        }
    }

    public void Unsubscribe()
    {
        foreach (var screenSaver in _screenSavers)
        {
            screenSaver.ScreenSaverOpened -= OpenedScreenSaverDelegate;
            screenSaver.ScreenSaverClosed -= ClosedScreenSaverDelegate;
        }
    }
}
