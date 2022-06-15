using UnityEngine.SceneManagement;
using UnityEngine;

///<summary>
///
///</summary>
class DontDestroyItemPanel : MonoBehaviour
{
    public static bool layer2 = false;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "DollLayer2")
        {
            this.GetComponent<DontDestroyItemPanel>().enabled = false;
        }
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "DollLayer2")
        {
            layer2 = true;
        }
        if (layer2)
        {
            Destroy(this.gameObject);
        }
    }
}
