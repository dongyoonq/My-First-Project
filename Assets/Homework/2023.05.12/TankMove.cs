using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = (moveInput.magnitude != 0) ? true : false;

        if (isMove)
        {
            float xx = Input.GetAxis("Vertical");
            float zz = Input.GetAxis("Horizontal");
            Vector3 lookDirection = xx * Vector3.forward + zz * Vector3.right;

            transform.rotation = Quaternion.LookRotation(lookDirection);
            transform.Translate(lookDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
