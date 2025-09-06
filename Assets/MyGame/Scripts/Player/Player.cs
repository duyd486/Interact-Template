using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    //[SerializeField] private float rotateSpeed = 1f;


    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float lookRange = 80f;
    private float verticalRotation = 0f;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        HandleMovement();
        HandleCamera();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        float moveDistance = moveSpeed * Time.deltaTime;

        Vector3 inputDir = new Vector3(inputVector.x, 0f, inputVector.y);
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDir = (cameraForward * inputDir.z + cameraRight * inputDir.x).normalized;


        // Di chuyển
        transform.position += moveDir * moveDistance;

        //transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    private void HandleCamera()
    {
        Debug.Log(GameInput.Instance.GetLookVectorNormalized());
        Vector2 lookInput = GameInput.Instance.GetLookVectorNormalized();

        // Xoay body theo chiều ngang
        transform.Rotate(0, lookInput.x * mouseSensitivity, 0);

        // Xoay cam theo chiều dọc
        verticalRotation -= lookInput.y;
        verticalRotation = Mathf.Clamp(verticalRotation, -lookRange, lookRange);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation * mouseSensitivity, cameraTransform.localEulerAngles.y, 0);
    }

}
