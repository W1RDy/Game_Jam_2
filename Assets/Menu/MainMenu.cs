using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _authors;
    private bool _isInMainMenu;

    public void Update() {
        if (!_isInMainMenu && Input.GetKeyDown(KeyCode.Escape)) {
            _authors.SetActive(false);
            _settings.SetActive(false);
            _mainMenu.SetActive(true);
            _isInMainMenu = true;
        }
    }
    
    public void NewGame() {
        //SceneManager.LoadScene(SceneManager.)
        print("Game start");
    }

    public void LoadGame() {
        //SceneManager.LoadScene(SceneManager.)
        print("Game load");
    }

    public void ExitGame() {
        Application.Quit();
    }
    public void ChangeMenu() {
        _isInMainMenu = false;
    }
}
