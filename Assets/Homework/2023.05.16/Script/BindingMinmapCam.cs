using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindingMinmapCam : MonoBehaviour
{
    private Vector3 previousPosition;
    float prevY;

    // Start is called before the first frame update
    void Start()
    {
        prevY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        previousPosition = transform.position;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(90f, 0f, 90f);
        Vector3 newPosition = new Vector3(previousPosition.x, prevY, previousPosition.z);
        transform.position = newPosition;
    }
}
