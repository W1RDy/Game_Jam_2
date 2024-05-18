using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocatorInstaller : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SubscribeService _subscribeService;

    [SerializeField] private ProgressBar _progressBar;

    [SerializeField] private AudioService _audioService;
    [SerializeField] private AudioData _audioData;

    private void Awake()
    {
        Bind();
    }

    private void Bind()
    {
        BindInventory();
        BindPlayer();
        BindProgressBar();
        BindAudio();
        BindSubscribeService();
    }

    private void BindPlayer()
    {
        ServiceLocator.Instance.Register(_player);
    }

    private void BindProgressBar()
    {
        ServiceLocator.Instance.Register(_progressBar);
    }

    private void BindInventory()
    {
        var inventory = new Inventory();
        ServiceLocator.Instance.Register(inventory);
    }

    private void BindSubscribeService()
    {
        ServiceLocator.Instance.Register(_subscribeService);
    }

    private void BindAudio()
    {
        AudioPlayer.Instance.Init(_audioData.AudioConfigs);
    }
}
