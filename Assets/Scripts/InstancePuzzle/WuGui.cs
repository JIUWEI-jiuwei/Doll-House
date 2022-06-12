using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///�ڹ�
///</summary>
class WuGui : MonoBehaviour
{
    public static GameObject wuGuiPanel;
    public static GameObject guiDialog0;
    public static GameObject guiDialog1;
    private GameObject guiDialog2;


    private void Start()
    {
        wuGuiPanel = GameObject.Find("GuiF").transform.GetChild(0).gameObject;
        guiDialog0 = GameObject.Find("gui").transform.GetChild(0).gameObject;
        guiDialog1 = GameObject.Find("gui").transform.GetChild(1).gameObject;
        guiDialog2 = GameObject.Find("gui").transform.GetChild(2).gameObject;

    }
    private void FixedUpdate()
    {
        if (StaticClass.isFinishedMove&& StaticClass.isGuiClick)
        {
            if(StaticClass.isGuiClickNum == 1)
            {
                guiDialog0.SetActive(true);
                
            }
            else if(StaticClass.isGuiClickNum >= 2)
            {
                if (StaticClass.isGuiWin)
                {
                    guiDialog2.SetActive(true);
                    Invoke("DestroyDialog", 2f);
                }
                else
                {
                    guiDialog1.SetActive(true);
                }
            }
            StaticClass.isGuiClick = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (guiDialog0 != null)
            {
                guiDialog0.SetActive(false);
                guiDialog1.SetActive(false);
            }
        }

    }
    public void OpenPanel()
    {
        StaticClass.isGuiClickNum++;
        StaticClass.isGuiClick = true;
    }
    public void ExitPanel()
    {
        wuGuiPanel.SetActive(false);

    }
    public void ButtonWin()
    {
        StaticClass.isGuiWin = true;
    }
    public void DestroyDialog()
    {
        guiDialog2.SetActive(false);
    }
}