using UnityEngine.SceneManagement;
using UnityEngine;

///<summary>
///
///</summary>
class DontDestroyItemPanel : MonoBehaviour
{
    public static bool layer2 = false;
    public static int layerCurrent = 0;
    private GameObject obj;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "DollLayer2")
        {
            this.GetComponent<DontDestroyItemPanel>().enabled = false;
        }
        obj = GameObject.Find("ŒÔ∆∑¿∏");
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "DollLayer2")
        {            
            layer2 = true;
            layerCurrent++;
        }
        if (SceneManager.GetActiveScene().name == "DollLayer1")
        {                        
            
        }

    }
}
