using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///
///</summary>
class LoadingNextLevel : MonoBehaviour
{
    public string sceneName = "DollLayer2";
    public void Next()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
