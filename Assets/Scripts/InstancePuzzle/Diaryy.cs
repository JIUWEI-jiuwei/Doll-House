using System.Collections;
using System.Collections.Generic;
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
    /// 日记本按钮
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
}
