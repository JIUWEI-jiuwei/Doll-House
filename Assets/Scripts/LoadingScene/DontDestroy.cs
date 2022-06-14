using UnityEngine.SceneManagement;
using UnityEngine;

///<summary>
///���в����ٵ�������Ҵ˽ű�
///</summary>
class DontDestroy : MonoBehaviour
{
    public GameObject MusicBk; //Ԥ���壨�����ٵ����壨����Ԥ���壩��
    public static bool isHave = false;
    private GameObject clone;//��¡�Ĳ���������
    private GameObject item;
    private void Awake()
    {
        item = GameObject.Find("itemmmm");
        //���λ���ƶ�+�������ƫ��
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
        DontDestroyOnLoad(clone);//�л�����������clone
    }
}
