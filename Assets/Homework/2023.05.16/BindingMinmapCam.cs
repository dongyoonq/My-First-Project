using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindingMinmapCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(90f, 0f, 90f);
    }
}
