using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///
///</summary>
class LoadingNextLevelInvoke : MonoBehaviour
{
    public string sceneName2 = "DollLayer2";
    public void Next()
    {
        Invoke("SceneLoad", 2.5f);
    }
    public void SceneLoad()
    {
        SceneManager.LoadSceneAsync(sceneName2);
    }
}
