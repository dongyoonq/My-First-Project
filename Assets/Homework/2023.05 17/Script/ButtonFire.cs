using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFire : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletPos;

    public void Fire()
    {
        Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
        Destroy(bulletPrefab, 5f);
    }
}
