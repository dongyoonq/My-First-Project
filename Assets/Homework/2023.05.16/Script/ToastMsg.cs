using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HomeWork_05_16
{
    public class ToastMsg : MonoBehaviour
    {
        private Text message;
        private float fadeInOutTime = 0.3f;

        private static ToastMsg instance = null;
        public static ToastMsg Instance
        {
            get
            {
                if (null == instance) instance = FindObjectOfType<ToastMsg>();
                return instance;
            }
        }

        private void Awake()
        {
            if (null == instance) instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            message = this.gameObject.GetComponent<Text>();
            message.enabled = false;
        }

        private void OnDestroy()
        {
            Destroy(instance);
            CancelInvoke();
        }

        private IEnumerator fadeInOut(Text target, float durationTime, bool inOut)
        {
            float start, end;
            if (inOut)
            {
                start = 0.0f;
                end = 1.0f;
            }
            else
            {
                start = 1.0f;
                end = 0f;
            }

            Color current = Color.clear; /* (0, 0, 0, 0) = 검은색 글자, 투명도 100% */
            float elapsedTime = 0.0f;

            while (elapsedTime < durationTime)
            {
                float alpha = Mathf.Lerp(start, end, elapsedTime / durationTime);

                target.color = new Color(current.r, current.g, current.b, alpha);

                elapsedTime += Time.deltaTime;

                yield return null;
            }
        }

        private IEnumerator showMessageCoroutine(string msg, float durationTime)
        {
            Color originalColor = message.color;
            message.text = msg;
            message.enabled = true;

            yield return fadeInOut(message, fadeInOutTime, true);

            float elapsedTime = 0.0f;
            while (elapsedTime < durationTime)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            yield return fadeInOut(message, fadeInOutTime, false);

            message.enabled = false;
            message.color = originalColor;
        }

        public void showMessage(string msg, float durationTime)
        {
            StartCoroutine(showMessageCoroutine(msg, durationTime));
        }

        public void showMessage(string msg)
        {
            message.enabled = true;
            message.text = msg;
        }

        public void hideMessage()
        {
            message.enabled = false;
        }
    }
}
