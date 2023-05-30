using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    public GameObject Dust;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * BulletSpeed);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.name != "Bullet(Clone)")
        {
            Debug.Log(other.name);
            Instantiate(Dust, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
