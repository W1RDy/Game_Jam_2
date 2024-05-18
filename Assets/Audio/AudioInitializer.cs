using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInitializer : MonoBehaviour
{
    [SerializeField] private string _audioIndex;

    private void Start()
    {
        AudioPlayer.Instance.PlayMusic(_audioIndex);
    }
}
