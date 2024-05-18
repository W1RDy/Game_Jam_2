using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new AudioData", menuName = "Data/ new Audio Data")]
public class AudioData : ScriptableObject
{
    [SerializeField] private List<AudioConfig> _audioConfigs;

    public List<AudioConfig> AudioConfigs => _audioConfigs;
}

[Serializable]
public class AudioConfig
{
    [SerializeField] private string _index;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private float _volume;

    public string Index => _index;
    public AudioClip Clip => _clip;
    public float Volume => _volume;
}
