using UnityEngine.SceneManagement;
using UnityEngine;

///<summary>
///
///</summary>
class Diaryy : MonoBehaviour
{
    private GameObject diaryPanel;
    private GameObject blackPanel;
    private int diaryNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        diaryPanel = GameObject.Find("diary").transform.GetChild(0).gameObject;
    }
    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("blackpanel") != null)
        {
            blackPanel = GameObject.FindGameObjectWithTag("blackpanel");
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
}
