using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float MoveSpeed;
    Vector3 lookDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D))
        {
            float xx = Input.GetAxis("Vertical");
            float zz = Input.GetAxis("Horizontal"); 
            lookDirection = xx * Vector3.forward + zz * Vector3.right;

            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 0.1f);
            this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.R))
        {

        }
            


        if (Input.GetKeyDown(KeyCode.LeftShift))
            MoveSpeed += 7.7f;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            MoveSpeed -= 7.7f;
    }
}
