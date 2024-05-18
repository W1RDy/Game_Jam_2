using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : IService
{
    private Dictionary<string, AudioConfig> _audioDictionary = new Dictionary<string, AudioConfig>();

    public AudioService(List<AudioConfig> audioConfigs)
    {
        InitializeDictionary(audioConfigs);
    }

    public void InitializeDictionary(List<AudioConfig> audioConfigs)
    {
        foreach (var audio in audioConfigs)
        {
            _audioDictionary.Add(audio.Index, audio);
        }
    }

    public AudioConfig GetAudio(string key)
    {
        return _audioDictionary[key];
    }
}