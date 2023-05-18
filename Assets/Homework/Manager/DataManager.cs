using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    public int fireCount;

    public UnityAction<int> OnChangedCount;

    public void AddShootCount(int count)
    {
        fireCount += count;
        OnChangedCount?.Invoke(fireCount);
    }
}