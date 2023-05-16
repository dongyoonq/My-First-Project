using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace HomeWork_05_16
{
    public class Fire : MonoBehaviour
    {
        public GameObject Bullet;
        public Transform FirePos;

        private AudioSource audioSource;

        [SerializeField]
        private float repeatTime = 0.1f;

        [SerializeField]
        private AudioClip fireClip;
        public bool isRepeatMode = true;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private Coroutine bulletRoutine;

        IEnumerator BulletMakeRepeatRoutine()
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
            if (inputValue.isPressed && isRepeatMode)
            {
                bulletRoutine = StartCoroutine(BulletMakeRepeatRoutine());
            }
            else if (inputValue.isPressed && !isRepeatMode)
            {
                audioSource.PlayOneShot(fireClip);
                Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            }
            else
            {
                if(bulletRoutine != null)
                    StopCoroutine(bulletRoutine);
            }
        }

        private void OnChangeMode(InputValue inputValue)
        {
            if (inputValue.isPressed)
            {
                isRepeatMode = isRepeatMode ? false : true;
                DisplayMessage();
            }
        }

        private void DisplayMessage()
        {
            if(isRepeatMode)
                ToastMsg.Instance.showMessage("연사모드 활성화", 1.0f);
            else
                ToastMsg.Instance.showMessage("단발모드 활성화", 1.0f);
        }
    }
}