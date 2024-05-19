using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        SceneLoaderService.Instance.LoadScene(1);
    }
}
