using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    public float AttackPoint = 20f;

    // Start is called before the first frame update
    void Awake()
    {
        transform.localRotation = Quaternion.Euler(90f, 0, 0);
        transform.localPosition = new Vector3(0, 0, 0.32f);
        transform.name = "Weapon";
    }

    /*
    private void OnTriggerEnter(UnityEngine.Collider other)
    {

    }
    */
}
