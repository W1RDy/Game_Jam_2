using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour, IService
{
    public static AudioPlayer Instance;

    private AudioSource _audioSource;
    private AudioService _audioService;

    private bool _isMusic = true;
    private bool _isSound = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }
        else Destroy(gameObject);

        DontDestroyOnLoad(Instance);
    }

    public void Init(List<AudioConfig> audioConfigs)
    {
        _audioService = new AudioService(audioConfigs);
    }

    public void PlayMusic(string index)
    {
        var audioClip = _audioService.GetAudio(index);
        if (_audioSource.clip == null || audioClip.Clip != _audioSource.clip)
        {
            if (_audioSource.isPlaying) _audioSource.Stop();

            _audioSource.volume = audioClip.Volume;
            _audioSource.clip = audioClip.Clip;
        }
        if (_isMusic) _audioSource.Play();
    }

    public void PlaySound(string index)
    {
        var audioClip = _audioService.GetAudio(index);
        if (_isSound)
        {
            _audioSource.PlayOneShot(audioClip.Clip, audioClip.Volume);
        }
    }

    public void StopAudio()
    {
        if (_audioSource.clip != null || _audioSource.isPlaying)
        {
            _audioSource.Pause();
        }
    }
}