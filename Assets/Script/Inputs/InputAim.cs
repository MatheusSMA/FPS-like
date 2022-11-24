using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAim : MonoBehaviour
{
    Vector3 rotation;
    [SerializeField] private int sense;
    private float _xRotation = 0f;

    [SerializeField] private GameObject _playerBody;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        // Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Aim();
    }

    private void Aim()
    {
        float inputX = Input.GetAxis("Mouse Y") * Time.deltaTime * sense;
        float inputY = Input.GetAxis("Mouse X") * Time.deltaTime * sense;

        _xRotation -= inputX;
        _xRotation = Mathf.Clamp(_xRotation, -60, 60);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBody.transform.Rotate(Vector3.up * inputY);
    }

}


