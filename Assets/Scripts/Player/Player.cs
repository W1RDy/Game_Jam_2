using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IService
{
    [SerializeField] private float speed;

    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;
    private bool _isVisible = true;

    public void HelloWorld()
    {
        Debug.Log("HelloWorld");
    }

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveVelocity = moveInput.normalized * speed;
    }

    private void FixedUpdate() {        
        _rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);
    }
}
