using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

namespace HomeWork_05_16
{
    public class Fire : MonoBehaviour
    {
        public GameObject Bullet;
        public Transform FirePos;

        private AudioSource audioSource;

        [SerializeField]
        private float repeatTime;

        [SerializeField]
        private AudioClip fireClip;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
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
                audioSource.PlayOneShot(fireClip);
                Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
                yield return new WaitForSeconds(repeatTime);
            }
        }

        private void OnFire(InputValue inputValue)
        {
            audioSource.PlayOneShot(fireClip);
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