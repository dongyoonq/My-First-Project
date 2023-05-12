using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    private Transform character;
    [SerializeField]
    private Transform followCam;

    public float Speed = 5f;

    Animator animator;

    public float minCameraDistance = 1.5f; // 최소 카메라 거리
    public float maxCameraDistance = 3.7f; // 최대 카메라 거리
    public bool OnRunKey;

    // Start is called before the first frame update
    void Start()
    {
        animator = character.GetComponent<Animator>();
        Debug.Log(followCam);
        Camera.main.GetComponent<Transform>().localPosition = new Vector3(0, 1.1f, -maxCameraDistance);
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        Move();
    }

    private void LateUpdate()
    {
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = (moveInput.magnitude != 0) ? true : false;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 8f;
            OnRunKey = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = 5f;
            OnRunKey = false;
        }

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

    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector3 camAngle = followCam.rotation.eulerAngles;

        float newAngleX = camAngle.x - mouseDelta.y;
        float newAngleY = camAngle.y + mouseDelta.x;

        Debug.Log(newAngleY);

        newAngleX = GetCameraMaxAngleX(newAngleX);
        newAngleY = GetCameraMaxAngleY(newAngleY);

        Quaternion rotation = Quaternion.Euler(newAngleX, newAngleY, camAngle.z);
        Vector3 cameraDirection = rotation * Vector3.forward;
        Vector3 cameraPosition = character.position - cameraDirection * maxCameraDistance;

        /*
        RaycastHit hit;
        if (Physics.Raycast(character.position, cameraDirection, out hit, maxCameraDistance))
        {
            cameraPosition = character.position - cameraDirection * hit.distance;
        }*/

        followCam.rotation = rotation;

        Debug.Log(cameraDirection);
        Debug.Log(cameraPosition);
        Debug.Log(character.position);  
    }

    private float GetCameraMaxAngleX(float camAngleX)
    {
        if (camAngleX < 180f)
            camAngleX = Mathf.Clamp(camAngleX, -1f, 35f);
        else
            camAngleX = Mathf.Clamp(camAngleX, 325f, 361f);

        return camAngleX;
    }

    private float GetCameraMaxAngleY(float camAngleY)
    {
        /*
        if (!OnLookAround)
        {
            if (camAngleY < 180f)
                camAngleY = Mathf.Clamp(camAngleY, -1f, 80f);
            else
                camAngleY = Mathf.Clamp(camAngleY, 280f, 361f);
        }*/

        return camAngleY;
    }
}
