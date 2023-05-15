using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEquipSystem : MonoBehaviour
{
    [SerializeField]
    private Transform character;

    [SerializeField]
    private Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject hand = GameObject.Find("Bip001 R Finger1");
            if (!hand.transform.Find("Weapon(Clone)"))
            {
                Instantiate(weapon, hand.transform.position, hand.transform.rotation, hand.transform);
            }
        }
    }
}
