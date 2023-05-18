using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HomeWork_05_18
{
    public class CameraMoveController : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera playerCM;

        private bool isMoved = false;

        // Start is called before the first frame update
        void Start()
        {
            playerCM.Priority = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnMoveCam(InputValue inputValue)
        {
            MoveCamera();
        }

        private void MoveCamera()
        {
            if (!isMoved)
            {
                playerCM.Priority = 3;
                isMoved = true;
            }
            else
            {
                playerCM.Priority = 0;
                isMoved = false;
            }
        }
    }
}