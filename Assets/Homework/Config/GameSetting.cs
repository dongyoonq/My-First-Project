using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork_05_18
{
    public class GameSetting
    {
        // 게임을 시작하기 전 필요한 설정들
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