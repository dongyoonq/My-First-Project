using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HomeWork_05_15
{
    public class Fire : MonoBehaviour
    {
        public GameObject Bullet;
        public Transform FirePos;

        [SerializeField]
        private float repeatTime;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private Coroutine bulletRoutine;

        IEnumerator BulletMakeRoutine()
        {
            while (true)
            {
                Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
                yield return new WaitForSeconds(repeatTime);
            }
        }

        private void OnFire(InputValue inputValue)
        {
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
        }

        private void OnRepeatFire(InputValue inputValue)
        {
            if (inputValue.isPressed)
            {
                bulletRoutine = StartCoroutine(BulletMakeRoutine());
            }
            else
            {
                StopCoroutine(bulletRoutine);
            }
        }
    }
}