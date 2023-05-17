using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFire : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletPos;
    [SerializeField]
    private GameObject tank;

    public void Fire()
    {
        if (!tank.GetComponent<Fire>().isActiveAndEnabled)
        {
            Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
            Destroy(bulletPrefab, 5f);
        }

    }
}
