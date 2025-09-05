using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 1f;
    [SerializeField] private bool isWalking = true;


    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        float moveDistance = moveSpeed * Time.deltaTime;

        Transform cameraTransform = Camera.main.transform;
        Vector3 inputDir = new Vector3(inputVector.x, 0f, inputVector.y);
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDir = (cameraForward * inputDir.z + cameraRight * inputDir.x).normalized;

        transform.position += moveDir * moveDistance;

        isWalking = moveDir != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }

}
