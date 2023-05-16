using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.TextCore.Text;

namespace HomeWork_05_16
{
    public class Move : MonoBehaviour
    {
        private Vector3 moveDir;
        Rigidbody rb;

        public float MoveSpeed = 15f;
        public float RotateSpeed = 2f;
        public float jumpForce = 12f;

        private bool isGround = true;

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
            if(isNormal())
                transform.Translate(MoveSpeed * Time.deltaTime * moveDir.z * Vector3.forward, Space.Self);
        }

        private void PlayerRotate()
        {
            if (isNormal())
                transform.Rotate(Vector3.up, 90f * RotateSpeed * Time.deltaTime * moveDir.x, Space.Self);
        }

        private void PlayerJump()
        {
            if(isGround && isNormal())
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        private void OnMove(InputValue inputvalue)
        {
            moveDir.x = inputvalue.Get<Vector2>().x;
            moveDir.z = inputvalue.Get<Vector2>().y;
        }   

        private void OnJump(InputValue inputvalue)
        {
            if (inputvalue.isPressed)
            {
                PlayerJump();
            }
        }

        private void OnRun(InputValue inputvalue)
        {
            if(inputvalue.isPressed)
            {
                MoveSpeed = 22f;
            }
            else
            {
                MoveSpeed = 15f;
            }
        }

        private void OnRestore(InputValue inputValue)
        {
            if (isFlipped() || !isNormal())
            {
                ToastMsg.Instance.hideMessage();
                //transform.rotation = Quaternion.identity;
                transform.rotation = Quaternion.Euler(transform.forward.x, 0f, transform.forward.z);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.collider);
            if (collision.gameObject.CompareTag("Ground"))
                isGround = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
                isGround = false;
        }

        private bool isFlipped()
        {
            Vector3 upDirection = transform.up;
            Vector3 worldUpDirection = Vector3.up;

            float dotProduct = Vector3.Dot(upDirection, worldUpDirection);
            return dotProduct < 0f;
        }

        private bool isNormal()
        {
            float slopeThreshold = 0.3f; // ���η� ������ ���� �Ӱ谪

            // �������� üũ
            if (Mathf.Abs(Vector3.Dot(transform.up, Vector3.up)) < slopeThreshold)
            {
                ToastMsg.Instance.showMessage("��ũ�� �������� ���°� �ƴմϴ� T Ű�� �̿��� ��ũ�� �����ϼ���");
                return false;
            }

            // ������ �������� üũ
            Vector3 upDirection = transform.up;
            Vector3 worldUpDirection = Vector3.up;
            float dotProduct = Vector3.Dot(upDirection, worldUpDirection);
            if (dotProduct < 0f)
            {
                ToastMsg.Instance.showMessage("��ũ�� �������� ���°� �ƴմϴ� T Ű�� �̿��� ��ũ�� �����ϼ���");
                return false;
            }

            return true;
        }

    }
}