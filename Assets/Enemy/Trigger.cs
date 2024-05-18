using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Trigger : MonoBehaviour
{
    public event Action IsEnter;
    public event Action IsExit;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsEnter?.Invoke();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsExit?.Invoke();
        }
    }
}
