using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterSpawner : MonoBehaviour
{
    public Transform points;
    public GameObject monsterPrefab;
    public float createTime;

    public const int maxMonster = 10;
    public bool IsGameOver = false;

    private void Start()
    {
        points = GameObject.Find("SpawnPoint").GetComponentInChildren<Transform>();
        StartCoroutine(this.CreateMonster());
    }

    private void Update()
    {
    }

    IEnumerator CreateMonster()
    {
        while (!IsGameOver)
        {
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Monster").Length;

            if (monsterCount < maxMonster)
            {
                yield return new WaitForSeconds(createTime);

                Instantiate(monsterPrefab, points.position, points.rotation);
            }
            else
            {
                yield return null;
            }
        }
    }
}