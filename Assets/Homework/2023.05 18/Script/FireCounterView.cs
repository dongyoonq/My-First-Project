using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FireCounterView : MonoBehaviour
{
    private TMP_Text textView;

    private void Awake()
    {
        textView = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        GameManager.Data.OnChangedCount += UpdateText;
    }

    private void OnDisable()
    {
        GameManager.Data.OnChangedCount -= UpdateText;
    }

    private void UpdateText(int count)
    {
        textView.text = $"Fire Count : {count}";
    }
}
