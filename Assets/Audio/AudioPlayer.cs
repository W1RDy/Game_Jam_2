using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour, IService
{
    public static AudioPlayer Instance;

    private AudioSource _audioSource;
    private AudioSource _loopSoundSource;

    private AudioService _audioService;

    private bool _isMusic = true;
    private bool _isSound = true;

    private bool _isInited = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
            _loopSoundSource = transform.GetChild(0).GetComponent<AudioSource>();
        }
        else Destroy(gameObject);

        DontDestroyOnLoad(Instance);
    }

    public void Init(List<AudioConfig> audioConfigs)
    {
        if (!_isInited)
        {
            _isInited = true;
            _audioService = new AudioService(audioConfigs);
        }
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
        if (_isMusic && !_audioSource.isPlaying) _audioSource.Play();
    }

    public void PlaySound(string index)
    {
        if (index == "Interaction" || index == "Walk") PlayLoopSound(index);
        else PlayOneShotSound(index);
    }

    public void PlayOneShotSound(string index)
    {
        var audioClip = _audioService.GetAudio(index);
        if (_isSound)
        {
            _audioSource.PlayOneShot(audioClip.Clip, audioClip.Volume);
        }
    }

    public void PlayLoopSound(string index)
    {
        var audioClip = _audioService.GetAudio(index);
        if (_loopSoundSource.clip == null || audioClip.Clip != _loopSoundSource.clip)
        {
            if (_loopSoundSource.isPlaying) _loopSoundSource.Stop();

            _loopSoundSource.volume = audioClip.Volume;
            _loopSoundSource.clip = audioClip.Clip;
        }
        if (_isSound && !_loopSoundSource.isPlaying) _loopSoundSource.Play();
    }

    public void StopAudio(string index)
    {
        var audioClip = _audioService.GetAudio(index);
        if (_audioSource.clip != null && _audioSource.clip == audioClip.Clip && _audioSource.isPlaying )
        {
            _audioSource.Pause();
        }

        if (_loopSoundSource.clip != null && _loopSoundSource.clip == audioClip.Clip && _loopSoundSource.isPlaying)
        {
            _loopSoundSource.Stop();
        }
    }
}