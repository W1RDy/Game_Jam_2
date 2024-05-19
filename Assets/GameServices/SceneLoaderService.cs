using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderService : MonoBehaviour
{
    public static SceneLoaderService Instance { get; private set; }

    [SerializeField] private ScreenSaverActivator _screenSaverActivator;

    private float _timeWaiting = 10f;

    private bool _isLoaded;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);

        DontDestroyOnLoad(Instance);
    }

    public void LoadScene(int sceneIndex)
    {
        if (!_isLoaded)
        {
            _isLoaded = true;
            StartCoroutine(AsyncLoading(sceneIndex));
        }
    }

    public void ReloadScene()
    {
        var buildIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene(buildIndex);
    }

    public void LoadNextScene()
    {
        var buildIndex = SceneManager.GetActiveScene().buildIndex;
        if (buildIndex == 3) FinishGame();
        else LoadScene(buildIndex + 1);
    }

    public void FinishGame()
    {
        if (!_isLoaded)
        {
            _isLoaded = true;
            StartCoroutine(FinishLoading());
        }
    }

    private IEnumerator AsyncLoading(int sceneIndex)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        asyncOperation.allowSceneActivation = false;

        while (asyncOperation.progress < 0.9f)
        {
            yield return null;
        }

        if (sceneIndex == SceneManager.GetActiveScene().buildIndex)
        {
            _screenSaverActivator.ActivateScreenSaver("Lose");

            yield return new WaitUntil(() => _screenSaverActivator.IsScreenSaverActivate == true);
            yield return new WaitForSeconds(2f);

            asyncOperation.allowSceneActivation = true;
            _isLoaded = false;
            _screenSaverActivator.DeactivateScreenSaver("Lose");
        }
        else
        {
            var screenSaverIndex = GetScreenSaver(sceneIndex);
            if (screenSaverIndex == "Level1")
            {
                for (int i = 0; i < 2; i++)
                {
                    var screenIndex = "";
                    if (i == 0) screenIndex = "Preface";
                    else if (i == 1) screenIndex = "Management";
                    _screenSaverActivator.ActivateScreenSaver(screenIndex);

                    //yield return new WaitUntil(() => _screenSaverActivator.IsScreenSaverActivate == true);
                    yield return new WaitForSeconds(_timeWaiting);
                    _screenSaverActivator.DeactivateScreenSaver(screenIndex);
                }
            }
            _screenSaverActivator.ActivateScreenSaver(screenSaverIndex);
            //yield return new WaitUntil(() => _screenSaverActivator.IsScreenSaverActivate == true);
            yield return new WaitForSeconds(_timeWaiting);

            asyncOperation.allowSceneActivation = true;
            _isLoaded = false;
            _screenSaverActivator.DeactivateScreenSaver(screenSaverIndex);
        }
    }

    private IEnumerator FinishLoading()
    {
        var asyncOperation = SceneManager.LoadSceneAsync(0);
        asyncOperation.allowSceneActivation = false;

        while (asyncOperation.progress < 0.9f)
        {
            yield return null;
        }

        _screenSaverActivator.ActivateScreenSaver("Afterword");
        //yield return new WaitUntil(() => _screenSaverActivator.IsScreenSaverActivate == true);
        yield return new WaitForSeconds(_timeWaiting);

        _screenSaverActivator.DeactivateScreenSaver("Afterwood");

        _screenSaverActivator.ActivateScreenSaver("Menu");
        //yield return new WaitUntil(() => _screenSaverActivator.IsScreenSaverActivate == true);
        yield return new WaitForSeconds(_timeWaiting);

        asyncOperation.allowSceneActivation = true;
        _isLoaded = false;
        _screenSaverActivator.DeactivateScreenSaver("Menu");
    }

    private string GetScreenSaver(int sceneIndex)
    {
        if (sceneIndex == 0) return "Menu";
        else if (sceneIndex == 1) return "Level1";
        else if (sceneIndex == 2) return "Level2";
        else if (sceneIndex == 3) return "Level3";
        else return "";
    }
}
