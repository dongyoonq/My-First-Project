using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BallMove : MonoBehaviour
{
    Rigidbody playerRigidBody;
    public float moveSpeed = 10f;
    public float jumpSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
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

            playerRigidBody.AddForce(lookDirection * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetAxis("Jump") != 0)
        {
            float yy = Input.GetAxis("Jump");
            Vector3 jump = Vector3.up * yy;
            playerRigidBody.AddForce(jump * jumpSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
