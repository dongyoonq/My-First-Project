using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HomeWork_05_15
{
    public class Bullet : MonoBehaviour
    {
        public float BulletSpeed;

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * BulletSpeed);
            Destroy(gameObject, 5f);
        }
    }
}
