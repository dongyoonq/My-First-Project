using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace HomeWork_05_18
{
    public class BulletFire : MonoBehaviour
    {
        [SerializeField]
        private float repeatTime = 0.1f;

        public GameObject Bullet;
        public Transform FirePos;
        public UnityEvent OnFired;
        public UnityEvent<string, float> OnChangedMode;

        public bool isRepeatMode = true;

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private Coroutine bulletRoutine;

        // ���� Ű �Է� �Ұ����ϰ� �����ϴ� �÷���
        private bool isFiring = false;

        private void OnFire(InputValue inputValue)
        {
            if (inputValue.isPressed && isRepeatMode)
            {
                RepeatFire();
            }
            else if (inputValue.isPressed && !isRepeatMode)
            {
                OneFire();
            }
            else
            {
                if (bulletRoutine != null)
                    StopCoroutine(bulletRoutine);

                if (isFiring)
                    isFiring = false;
            }
        }

        private void OnChangeMode(InputValue inputValue)
        {
            if (inputValue.isPressed)
            {
                isRepeatMode = isRepeatMode ? false : true;
                DisplayMessage();
                StopCoroutine(bulletRoutine);
            }
        }

        private void RepeatFire()
        {
            if (!isFiring)
            {
                bulletRoutine = StartCoroutine(BulletMakeRepeatRoutine());
                isFiring = true;
            }
        }

        private void OneFire()
        {
            if (!isFiring)
            {
                Fire();
                isFiring = true;
            }
        }

        IEnumerator BulletMakeRepeatRoutine()
        {
            while (true)
            {
                Fire();
                yield return new WaitForSeconds(repeatTime);
            }
        }

        private void Fire()
        {
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            GameManager.Data.AddShootCount(1);
            OnFired?.Invoke();
        }

        private void DisplayMessage()
        {
            if (isRepeatMode)
                OnChangedMode?.Invoke("������ Ȱ��ȭ", 1.0f);
            else
                OnChangedMode?.Invoke("������ ��Ȱ��ȭ", 1.0f);
        }
    }
}