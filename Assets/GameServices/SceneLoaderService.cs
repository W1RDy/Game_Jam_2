using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderService : MonoBehaviour
{
    public static SceneLoaderService Instance { get; private set; }

    [SerializeField] private ScreenSaverActivator _screenSaverActivator;
    private bool _isScreenSaverOpened;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _screenSaverActivator.ScreenSaverOpened += OpenedScreenSaverDelegate;
            _screenSaverActivator.ScreenSaverClosed += ClosedScreenSaverDelegate;
        }
        else Destroy(gameObject);

        DontDestroyOnLoad(Instance);
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(AsyncLoading(sceneIndex));
    }

    public void ReloadScene()
    {
        var buildIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene(buildIndex);
    }

    public void LoadNextScene()
    {
        var buildIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene(buildIndex + 1);
    }

    private void OpenedScreenSaverDelegate()
    {
        _isScreenSaverOpened = true;
    }

    private void ClosedScreenSaverDelegate()
    {
        _isScreenSaverOpened = false;
    }

    private IEnumerator AsyncLoading(int sceneIndex)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        asyncOperation.allowSceneActivation = false;

        while (asyncOperation.progress < 0.9f)
        {
            yield return null;
        }
        _screenSaverActivator.ActivateScreenSaver();
        yield return new WaitUntil(() => _isScreenSaverOpened == true);
        yield return new WaitForSeconds(2f);
        asyncOperation.allowSceneActivation = true;
        _screenSaverActivator.DeactivateScreenSaver();
    }

    private void OnDestroy()
    {
        _screenSaverActivator.ScreenSaverOpened -= OpenedScreenSaverDelegate;
        _screenSaverActivator.ScreenSaverClosed -= ClosedScreenSaverDelegate;
    }
}
