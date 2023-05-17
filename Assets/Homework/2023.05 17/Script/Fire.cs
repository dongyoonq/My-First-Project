using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace HomeWork_05_17
{
    public class Fire : MonoBehaviour
    {
        public GameObject Bullet;
        public Transform FirePos;

        private AudioSource audioSource;
        private Animator animator;

        [SerializeField]
        private float repeatTime = 0.1f;

        [SerializeField]
        private AudioClip fireClip;
        public bool isRepeatMode = true;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
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

        // ���� Ű �Է� �Ұ����ϰ� �����ϴ� �÷���
        private bool isFiring = false;

        private void OnFire(InputValue inputValue)
        {
            animator.SetTrigger("Fire");
            if (inputValue.isPressed && isRepeatMode)
            {
                if (!isFiring)
                {
                    bulletRoutine = StartCoroutine(BulletMakeRepeatRoutine());
                    isFiring = true;
                }
            }
            else if (inputValue.isPressed && !isRepeatMode)
            {
                if (!isFiring)
                {
                    audioSource.PlayOneShot(fireClip);
                    Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
                    isFiring = true;
                }
            }
            else
            {
                if (bulletRoutine != null)
                {
                    StopCoroutine(bulletRoutine);
                }

                if (isFiring)
                {
                    isFiring = false;
                }
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
                ToastMsg.Instance.showMessage("������ Ȱ��ȭ", 1.0f);
            else
                ToastMsg.Instance.showMessage("�ܹ߸�� Ȱ��ȭ", 1.0f);
        }
    }
}