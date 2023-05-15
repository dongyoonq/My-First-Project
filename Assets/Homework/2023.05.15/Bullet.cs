using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork
{
    public class Bullet : MonoBehaviour
    {
        public float BulletSpeed;

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * BulletSpeed);
        }
    }
}
