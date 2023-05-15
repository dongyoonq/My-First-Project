using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

namespace HomeWork
{
    public class Move : MonoBehaviour
    {
        public float MoveSpeed;

        Vector3 lookDirection;
        Vector3 lastLookDirection;

        // Start is called before the first frame update
        void Start()
        {
            lastLookDirection = transform.forward; // 초기 값으로 현재의 전방 방향을 사용
        }

        // Update is called once per frame
        void Update()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            transform.rotation = Quaternion.LookRotation(lookDirection != Vector3.zero ? lookDirection : lastLookDirection);
            transform.Translate(lookDirection * MoveSpeed * Time.deltaTime, Space.World);
        }

        private void OnMove(InputValue inputvalue)
        {
            Vector2 input = inputvalue.Get<Vector2>();
            lookDirection = input.y * Vector3.forward + input.x * Vector3.right;

            if (lookDirection != Vector3.zero)
            {
                lastLookDirection = lookDirection; // 입력이 있는 경우에만 lastLookDirection 값을 갱신
            }
        }
    }
}