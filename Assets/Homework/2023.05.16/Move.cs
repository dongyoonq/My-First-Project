using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

namespace HomeWork_05_16
{
    public class Move : MonoBehaviour
    {
        private Vector3 moveDir;
        Rigidbody rb;

        public float MoveSpeed = 15f;
        public float jumpForce = 10f;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            PlayerMove();
            PlayerRotate();
        }

        private void PlayerMove()
        {
            transform.Translate(MoveSpeed * Time.deltaTime * moveDir.z * Vector3.forward, Space.Self);
        }

        private void PlayerRotate()
        {
            transform.Rotate(Vector3.up, 90f * Time.deltaTime * moveDir.x, Space.Self);
        }

        private void PlayerJump()
        {
            rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }

        private void OnMove(InputValue inputvalue)
        {
            moveDir.x = inputvalue.Get<Vector2>().x;
            moveDir.z = inputvalue.Get<Vector2>().y;
        }

        private void OnJump(InputValue inputvalue)
        {
            PlayerJump();
        }
    }
}