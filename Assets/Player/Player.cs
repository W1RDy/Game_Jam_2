using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IService
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject _view;

    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;
    public bool _isVisible = true;
    

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (_isVisible) {
            Move();            
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            var interactable = FinderObjects.FindInteractableObjectByCircle(1, _rb.transform.position);
            if (interactable != null) {
                interactable.Interact();
            }
        }
    }

    private void FixedUpdate() {        
        _rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);
    }

    public void ChangeVisible() {
        _isVisible = !_isVisible;
        _view.SetActive(_isVisible);
    }

    private void Move() {
        var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveVelocity = moveInput.normalized * speed;
    }
    
}
