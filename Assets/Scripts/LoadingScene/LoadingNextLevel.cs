using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///
///</summary>
class LoadingNextLevel : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadSceneAsync("DollLayer2");
    }
}
