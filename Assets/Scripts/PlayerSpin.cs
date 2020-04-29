using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpin : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    [SerializeField] private RotationAxes axes = RotationAxes.MouseX;
    [SerializeField] private float _sensitivityHorizontal = 7f;
    [SerializeField] private float _sensitivityVertical = 7f;
    [SerializeField] private float _minVertical = -45f;
    [SerializeField] private float _maxVertical = 45f;

    private float _rotationX = 0;

    private void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();

        if (rigidBody != null)
            rigidBody.freezeRotation = true;
    }

    private void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityHorizontal, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVertical;

            _rotationX = Mathf.Clamp(_rotationX, _minVertical, _maxVertical);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVertical;
            _rotationX = Mathf.Clamp(_rotationX, _minVertical, _maxVertical);
            float delta = Input.GetAxis("Mouse X") * _sensitivityHorizontal;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
