using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour
{
    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
