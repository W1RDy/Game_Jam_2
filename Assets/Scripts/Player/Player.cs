using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IService
{
    [SerializeField] private float speed;

    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;

    public void HelloWorld()
    {
        Debug.Log("HelloWorld");
    }

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }
    

    private void FixedUpdate() {
        var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveVelocity = moveInput.normalized * speed;
        _rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);
    }
}
