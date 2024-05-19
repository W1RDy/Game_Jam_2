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

    private DataService _dataService;

    private void Awake()
    {
        _dataService = ServiceLocator.Instance.Get<DataService>();
    }

    public void Start() {
        _authors.SetActive(false);
        _settings.SetActive(false);
        _mainMenu.SetActive(true);
    } 

    public void Update() {
        if (!_isInMainMenu && Input.GetKeyDown(KeyCode.Escape)) {
            _authors.SetActive(false);
            _settings.SetActive(false);
            _mainMenu.SetActive(true);
            _isInMainMenu = true;
        }
    }
    
    public void NewGame() {
        _dataService.ResetData();
        SceneLoaderService.Instance.LoadScene(1);
        print("Game start");
    }

    public void LoadGame() {
        var levelIndex = _dataService.LevelIndex;
        SceneLoaderService.Instance.LoadScene(levelIndex);
        print("Game load");
    }

    public void ExitGame() {
        Application.Quit();
    }
    public void ChangeMenu() {
        _isInMainMenu = false;
    }
}
