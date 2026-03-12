using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameSettings _settings;
    [SerializeField] private float _minY, _maxY;
    private float _rotationX,_rotationY;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        _rotationX += Input.GetAxis("Mouse X") * _settings._mouseSens;
        _rotationY -= Input.GetAxis("Mouse Y") * _settings._mouseSens;
        _rotationY = Mathf.Clamp(_rotationY, _minY, _maxY);

        Quaternion rotation = Quaternion.Euler(_rotationY, _rotationX, 0);

        Vector3 position = _player.position - rotation * Vector3.forward *0;

        transform.position = position;
        transform.rotation = rotation;
        _player.rotation = rotation;
    }
}
