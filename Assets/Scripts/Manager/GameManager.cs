
using UnityEngine;
using UnityEditor;
///<summary>
///ȫ�ֹ���Manager
///</summary>
class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            //EditorApplication.isPlaying = false;
        }
    }
}
