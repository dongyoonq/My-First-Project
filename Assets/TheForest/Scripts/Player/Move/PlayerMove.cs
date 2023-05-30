using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpForce;

    private CharacterController controller;
    private Vector3 moveDir;
    private Animator animator;

    private float ySpeed = 0f;
    private float lastSpeed;
    private bool OnRunKey;
    private bool isGround;

    private void Awake()
    {
        lastSpeed = moveSpeed;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position + Vector3.up * 1f, 0.5f, Vector3.down, out hit, 0.58f, LayerMask.GetMask("Ground")))
            isGround = true;
        else
            isGround = false;
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        moveDir = new Vector3(input.x, 0, input.y);
    }

    private void Move()
    {
        controller.Move(transform.forward * moveDir.z * lastSpeed * Time.deltaTime);
        controller.Move(transform.right * moveDir.x * lastSpeed * Time.deltaTime);

        float percent = ((OnRunKey) ? 1 : 0.5f) * moveDir.magnitude;
        animator.SetFloat("Blend", percent, 0.1f, Time.deltaTime);
    }

    private void OnJump(InputValue value)
    {
        if (isGround)
            ySpeed = jumpForce;

        if (value.isPressed)
            animator.SetBool("OnPlayerJump", true);
        else
            animator.SetBool("OnPlayerJump", false);
    }

    private void Jump()
    {
        if (isGround && ySpeed < 0f)
            ySpeed = 0f;
        else
            ySpeed += Physics.gravity.y * Time.deltaTime;

        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void OnRun(InputValue value)
    {
        if (value.isPressed)
        {
            lastSpeed = runSpeed;
            OnRunKey = true;
        }
        else
        {
            lastSpeed = moveSpeed;
            OnRunKey = false;
        }
    }
}
