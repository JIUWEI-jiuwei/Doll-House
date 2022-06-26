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
                    dialog.transform.GetChild(0).GetComponent<ShrinkText>().text = "日记本中有许多重要提示，不妨在这里找找线索。";
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
                    dialog.transform.GetChild(0).GetComponent<ShrinkText>().text = "1.拖拽道具至场景中以使用道具。\n2.拖拽道具至物品栏中的其他道具可将其组合使用。\n3.要留意道具的介绍哦。";
                    Invoke("DestroyDialog", 4f);
                    first2 = true;
                }
            }
        }
        
    }
    /// <summary>
    /// 日记本按钮（一二关）
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
    /// 打开日记本（仅限于第三关）
    /// </summary>
    public void OpenDiaryForScene3()
    {
        diaryPanel.SetActive(true);
    }
    /// <summary>
    /// 关闭日记本（仅限于第三关）
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
                dialog.transform.GetChild(0).GetComponent<ShrinkText>().text = "那地方太高，我碰不着，得找个方法上去才行……";
                Invoke("DestroyDialog", 2f);
            }
        }
    }
}
