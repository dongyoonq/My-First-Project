using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPSController : MonoBehaviour
{
    [SerializeField] private Transform rootCamera;
    [SerializeField] float mouseSensitivity;
    [SerializeField] float lookDistance;

    private Vector2 mouseDelta;
    private Vector3 lookPoint;
    private float xRotate;
    private float yRotate;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        Rotate();
    }

    private void LateUpdate()
    {
        Look();
    }

    private void OnLook(InputValue value)
    {
        mouseDelta = value.Get<Vector2>();
    }

    private void Look()
    {
        yRotate += mouseDelta.x * mouseSensitivity * Time.deltaTime;
        xRotate += -mouseDelta.y * mouseSensitivity * Time.deltaTime;

        xRotate = Mathf.Clamp(xRotate, -30f, 50f);

        rootCamera.rotation = Quaternion.Euler(xRotate, yRotate, 0f);
    }

    private void Rotate()
    {
        lookPoint = Camera.main.transform.position + Camera.main.transform.forward * lookDistance;
        lookPoint.y = transform.position.y;
        transform.LookAt(lookPoint);
    }
}
