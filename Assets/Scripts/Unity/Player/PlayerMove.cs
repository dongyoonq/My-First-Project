using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator;
    Camera camera;
    CharacterController controller;

    public float Speed = 5f;
    public float runSpeed = 8f;
    public float finalSpeed;
    public float smoothness = 10f;

    public bool toggleCameraRotation;
    public bool OnRunKey;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        camera = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            toggleCameraRotation = true;    // 둘러보기 활성화
        }
        else
        {
            toggleCameraRotation = false;   // 둘러보기 비활성화
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            OnRunKey = true;
        }
        else
        {
            OnRunKey = false;
        }

        InputMovement();
    }

    private void LateUpdate()
    {
        if(!toggleCameraRotation)
        {
            Vector3 playerRotate = Vector3.Scale(camera.transform.forward, new Vector3(1, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smoothness);
        }
    }

    private void InputMovement()
    {
        finalSpeed = (OnRunKey) ? runSpeed : Speed;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        Vector3 moveDirection = forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal");

        controller.Move(moveDirection.normalized * finalSpeed * Time.deltaTime);

        float percent = ((OnRunKey) ? 1 : 0.5f) * moveDirection.magnitude;
        animator.SetFloat("Blend", percent, 0.1f, Time.deltaTime);
    }
}
