using UnityEngine.SceneManagement;
using UnityEngine;

///<summary>
///所有不销毁的物体均挂此脚本
///</summary>
class DontDestroy : MonoBehaviour
{
    public GameObject MusicBk; //预制体（不销毁的物体（做成预制体））
    public static bool isHave = false;
    private GameObject clone;//克隆的不销毁物体
    private GameObject item;
    private void Awake()
    {
        item = GameObject.Find("itemmmm");
        //鼠标位置移动+矫正鼠标偏移
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.name == "CanvasUp")
            {
                if (!isHave)
                {
                    clone = Instantiate(MusicBk);
                    clone.transform.SetParent(canvas.transform);
                    clone.transform.localScale = new Vector3(1, 1, 1);
                    clone.transform.position = item.transform.position;
                    isHave = true;
                }
            }
        }
        DontDestroyOnLoad(clone);//切换场景不销毁clone
    }
}
