using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>
class Diaryy : MonoBehaviour
{
    private GameObject diaryPanel;
    private GameObject blackPanel;
    private GameObject dialog;
    private Transform dialogPos;
    private GameObject player;
    private int diaryNum = 0;
    public GameObject dialogPrefab;
    private int num = 0;
    private bool first1 = false;
    private bool first2 = false;


    // Start is called before the first frame update
    void Start()
    {
        diaryPanel = GameObject.Find("diary").transform.GetChild(0).gameObject;
        player = GameObject.Find("Player");
        if (player != null)
        {
            dialogPos = player.transform.GetChild(0);
        }
    }
    private void Update()
    {
        if (dialog != null && dialogPos != null)
        {
            dialog.transform.position = dialogPos.position;
        }
        if (GameObject.FindGameObjectWithTag("blackpanel") != null)
        {
            blackPanel = GameObject.FindGameObjectWithTag("blackpanel");
        }
        if (diaryNum==2)
        {
            foreach (Canvas canvas in FindObjectsOfType<Canvas>())
            {
                if (canvas.name == "OtherCanvas"&&first1==false)
                {
                    dialog = Instantiate(dialogPrefab, canvas.transform);
                    dialog.transform.GetChild(0).GetComponent<ShrinkText>().text = "�ռǱ����������Ҫ��ʾ����������������������";
                    Invoke("DestroyDialog", 2f);
                    first1 = true;
                }
            }
        }
        if (ItemPanelClick.numDown == 1)
        {
            foreach (Canvas canvas in FindObjectsOfType<Canvas>())
            {
                if (canvas.name == "OtherCanvas" && first2 == false)
                {
                    dialog = Instantiate(dialogPrefab, canvas.transform);
                    dialog.transform.GetChild(0).GetComponent<ShrinkText>().text = "1.��ק��������������ʹ�õ��ߡ�\n2.��ק��������Ʒ���е��������߿ɽ������ʹ�á�\n3.Ҫ������ߵĽ���Ŷ��";
                    Invoke("DestroyDialog", 4f);
                    first2 = true;
                }
            }
        }
        
    }
    /// <summary>
    /// �ռǱ���ť��һ���أ�
    /// </summary>
    public void Diary()
    {
        diaryNum++;
        if (diaryNum % 2 == 0)
        {
            blackPanel.SetActive(false);
            StaticClass.isPlayerMove = true;
        }
        else
        {
            diaryPanel.SetActive(true);
            StaticClass.isPlayerMove = false;
        }
    }
    /// <summary>
    /// ���ռǱ��������ڵ����أ�
    /// </summary>
    public void OpenDiaryForScene3()
    {
        diaryPanel.SetActive(true);
    }
    /// <summary>
    /// �ر��ռǱ��������ڵ����أ�
    /// </summary>
    public void BackDiary()
    {
        diaryPanel.SetActive(false);
    }
    private void DestroyDialog()
    {
        Destroy(dialog);
    }
   public void RawMeatDialog()
    {
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.name == "OtherCanvas" )
            {
                dialog = Instantiate(dialogPrefab, canvas.transform);
                dialog.transform.GetChild(0).GetComponent<ShrinkText>().text = "�ǵط�̫�ߣ��������ţ����Ҹ�������ȥ���С���";
                Invoke("DestroyDialog", 2f);
            }
        }
    }
}
