using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnityInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 dir = inputValue.Get<Vector2>();
    }

    private void OnJump(InputValue inputValue)
    {
        bool isPress = inputValue.Get<bool>();
    }
}
