using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private float _speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        _targetPosition = new Vector3(_playerTransform.transform.position.x, _playerTransform.transform.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _speed * Time.fixedDeltaTime);
    }
}
