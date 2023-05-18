using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HomeWork_05_18
{
    public class SceneLoad : MonoBehaviour
    {
        public void ChangeSceneByName(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}