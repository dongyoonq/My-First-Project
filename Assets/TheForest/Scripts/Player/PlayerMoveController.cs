using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    private Transform character;
    [SerializeField]
    private Transform followCam;

    private float Speed;
    public float NormalSpeed = 4.3f;
    public float RunSpeed = 6.8f;
    public float jumpForce = 100f;

    Animator animator;
    Rigidbody rb;

    public float minCameraDistance = 0.4f; // 최소 카메라 거리
    public float maxCameraDistance = 3.7f; // 최대 카메라 거리

    private bool OnRunKey;
    private bool isGround = true;

    void Start()
    {
        // 시작시 초기화 
        Speed = NormalSpeed;
        animator = character.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        LookAround();
        Move();
        Jump();
    }

    private void LateUpdate()
    {
        SetCameraPosition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Ground"))
            isGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGround = false;
    }

    /// <summary>
    /// 플레이어의 움직임, 설정
    /// </summary>
    private void Move()
    {
        // 수평, 수직이동을 감지하고 값을 받음
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = (moveInput.magnitude != 0) ? true : false;

        // 달리기 버튼 Left Shift
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Speed = RunSpeed;
            OnRunKey = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = NormalSpeed;
            OnRunKey = false;
        }

        // 플레이어 움직임이 감지 되었을때
        if (isMove)
        {
            Vector3 lookForward = new Vector3(followCam.forward.x, 0f, followCam.forward.z).normalized;
            Vector3 lookRight = new Vector3(followCam.right.x, 0f, followCam.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            character.forward = moveDir;
            transform.position += moveDir * Speed * Time.deltaTime;

            float percent = ((OnRunKey) ? 1 : 0.5f) * moveDir.magnitude;
            animator.SetFloat("Blend", percent, 0.1f, Time.deltaTime);
        }
        else
            animator.SetFloat("Blend", 0, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") != 0 && isGround)
        {
            animator.SetBool("OnPlayerJump", true);

            rb.AddForce(Vector3.up.normalized * jumpForce, ForceMode.Impulse);
        }
        else
        {
            animator.SetBool("OnPlayerJump", false);
        }
    }


    private void SetCameraPosition()
    {
        // Ray를 카메라에서 플레이어 방향으로 쏘고 충돌 정보 검사
        Vector3 directionToCamera = (followCam.transform.position - Camera.main.transform.position).normalized;
        Debug.DrawLine(Camera.main.transform.position, followCam.transform.position, Color.red);

        //Ray ray = new Line(Camera.main.transform.position, followCam.position);

        int playerLayer = LayerMask.NameToLayer("Player");  // 플레이어의 레이어
        int layerMask = ~(1 << playerLayer);                // 플레이어 레이어를 제외한 모든 레이어

        RaycastHit hit;
        if (Physics.Linecast(followCam.transform.position, Camera.main.transform.position, out hit, layerMask))
        {
            // 장애물과 충돌한 경우, mainCamera와 followCam 사이의 거리를 최소거리로 설정
            Camera.main.transform.position = hit.point - directionToCamera * minCameraDistance;
        }
        else
        {
            // 장애물이 없는 경우, mainCamera와 followCam 사이의 거리를 최대거리로 설정
            Camera.main.transform.position = followCam.position - directionToCamera * maxCameraDistance;
        }
    }

    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector3 camAngle = followCam.rotation.eulerAngles;

        float newAngleX = camAngle.x - mouseDelta.y;
        float newAngleY = camAngle.y + mouseDelta.x;

        newAngleX = GetCameraMaxAngleX(newAngleX);

        Quaternion rotation = Quaternion.Euler(newAngleX, newAngleY, camAngle.z);

        followCam.rotation = rotation;
    }

    private float GetCameraMaxAngleX(float camAngleX)
    {
        if (camAngleX < 180f)
            camAngleX = Mathf.Clamp(camAngleX, -1f, 35f);
        else
            camAngleX = Mathf.Clamp(camAngleX, 325f, 361f);

        return camAngleX;
    }
}
