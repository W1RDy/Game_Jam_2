using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _settings;

    private bool _isInPauseMenu = false;
    private bool _isInGame = true;
    private DataService _dataService;

    private void Awake()
    {
        _dataService = ServiceLocator.Instance.Get<DataService>();
    }

    public void Start() {
        print("start");
        _settings.SetActive(false);            
        _pauseMenu.SetActive(false);             
    } 

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!_isInPauseMenu && !_isInGame) {
                print("go3");
                _settings.SetActive(false);
                _pauseMenu.SetActive(true);
                _isInPauseMenu = true;
            }            
             else if (_isInPauseMenu) {
                print("go2");
                _settings.SetActive(false);
                _pauseMenu.SetActive(false);
                _isInPauseMenu = false;
                _isInGame = true;
                Time.timeScale = 1;
            }
            
            else if (_isInGame) {
                print("go");
                _settings.SetActive(false);            
                _pauseMenu.SetActive(true);            
                _isInPauseMenu = true;
                _isInGame = false;
                Time.timeScale = 0;
            }           
        }        
    }
    
    public void LoadMenu() {
        PauseOff();
        SceneLoaderService.Instance.LoadScene(0);
        print("Load menu");
    }

    public void PauseOff() {
        _pauseMenu.SetActive(false);
        _isInPauseMenu = false;
        _isInGame = true;
        Time.timeScale = 1;
    }

    public void SettingOn() {
        _settings.SetActive(true);
        _pauseMenu.SetActive(false);
        _isInPauseMenu = false;
        _isInGame = false;
    }

    public void PauseOn() {
        _pauseMenu.SetActive(true);
        _settings.SetActive(false);
        _isInPauseMenu = true;
        _isInGame = false;
    }
}
