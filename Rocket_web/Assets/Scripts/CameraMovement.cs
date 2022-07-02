using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private Vector3 _newCameraPosition;

    private void Update()
    {
        _newCameraPosition = new Vector3(_target.position.x + _offset.x, (_target.position.y + _offset.y) / 2, _offset.z);
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _newCameraPosition, _speed * Time.deltaTime);
    }
}
