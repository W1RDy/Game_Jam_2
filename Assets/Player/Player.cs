using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Player : MonoBehaviour, IService
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject _view;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;
    public bool _isVisible = true;

    private Inventory _inventory;
    private ItemInteractor _interactor;
    
    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _inventory = ServiceLocator.Instance.Get<Inventory>();
        _interactor = new ItemInteractor();
    }

    private void Update() {
        _animator.SetFloat("Horizontal", _moveVelocity.x);
        _animator.SetFloat("Vertical", _moveVelocity.y);
        _animator.SetFloat("Speed", _moveVelocity.sqrMagnitude);

        if (_isVisible) {
            Move();            
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            var interactable = FinderObjects.FindInteractableObjectByCircle(1, _rb.transform.position);
            if (interactable != null) {
                interactable.Interact();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _interactor.InteractWithItem(_inventory, _rb.transform.position);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            _interactor.StopInteractWithItem();
        }
    }

    private void FixedUpdate() {        
        _rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);
    }

    public void ChangeVisible() {
        _isVisible = !_isVisible;
        _view.SetActive(_isVisible);

        if (_isVisible) AudioPlayer.Instance.PlaySound("Close");
        else AudioPlayer.Instance.PlaySound("Open");
    }

    private void Move() {
        var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveVelocity = moveInput.normalized * speed;

        if (moveInput != Vector2.zero) AudioPlayer.Instance.PlaySound("Walk");
        else AudioPlayer.Instance.StopAudio("Walk");
    }
    
}
