using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace allscene
{
    public class SceneChanger : MonoBehaviour
    {
        public void ChangeSceneTo(string sceneName) { SceneManager.LoadScene(sceneName); }

        public void GameQuit() { Application.Quit(); }
    }
}


