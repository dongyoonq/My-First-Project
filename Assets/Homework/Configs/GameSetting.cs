using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork_05_18
{
    public class GameSetting
    {
        // ������ �����ϱ� �� �ʿ��� ������
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            InitProjectSetting();
            InitManager();
        }

        private static void InitProjectSetting()
        {
            Physics.gravity = new Vector3(0, -25f, 0);
        }

        private static void InitManager()
        {
            if (GameManager.Instance == null)
            {
                GameObject gameManager = new GameObject() { name = "GameManager" };
                gameManager.AddComponent<GameManager>();
            }
        }
    }
}