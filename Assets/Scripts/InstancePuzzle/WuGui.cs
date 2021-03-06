using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///?ڹ?
///</summary>
class WuGui : MonoBehaviour
{
    public static GameObject wuGuiPanel;
    public static GameObject wuGuiLeft;
    public static GameObject cameraBrush;
    public static GameObject guiDialog0;
    public static GameObject guiDialog1;
    private GameObject guiDialog2;

    public static bool getGui=false;
    private void Start()
    {
        wuGuiPanel = GameObject.Find("GuiF").transform.GetChild(0).gameObject;
        guiDialog0 = GameObject.Find("gui").transform.GetChild(0).gameObject;
        guiDialog1 = GameObject.Find("gui").transform.GetChild(1).gameObject;
        guiDialog2 = GameObject.Find("gui").transform.GetChild(2).gameObject;
        wuGuiLeft = GameObject.Find("Guileft");
        wuGuiLeft.SetActive(false);
        cameraBrush= GameObject.Find("CameraBrush");
        cameraBrush.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (StaticClass.isFinishedMove&& StaticClass.isGuiClick)
        {
            if(PlayerPrefs.GetInt("isGuiClickNum") == 1)
            {
                guiDialog0.SetActive(true); 
                Invoke("DestroyDialog0", 10f);
            }
            else if(PlayerPrefs.GetInt("isGuiClickNum") >= 2)
            {
                if (PlayerPrefs.GetInt("isGuiWin") == 1)
                {
                    guiDialog2.SetActive(true);
                    Invoke("DestroyDialog", 2f);
                }
                else
                {
                    guiDialog1.SetActive(true);
                    Invoke("DestroyDialog1", 2f);
                }
            }
            StaticClass.isGuiClick = false;
        }
        /*if (Input.GetMouseButtonUp(0))
        {
            if (guiDialog0 != null)
            {
                guiDialog0.SetActive(false);
                guiDialog1.SetActive(false);
            }
        }*/
        if (!getGui)
        {
            if (PlayerPrefs.GetInt("isGuiWin") == 1)
            {
                wuGuiPanel.SetActive(false);
                wuGuiLeft.SetActive(false);
                cameraBrush.SetActive(false);
                ItemPanelClick.ChangeItemPanel("turtleshell");
                getGui = true;
            }
        }
        
    }
    public void OpenPanel()
    {
        StaticClass.isGuiClickNum++;
        PlayerPrefs.SetInt("isGuiClickNum", StaticClass.isGuiClickNum);
        StaticClass.isGuiClick = true;
    }
    public void ExitPanel()
    {
        wuGuiPanel.SetActive(false);
        wuGuiLeft.SetActive(false);
        cameraBrush.SetActive(false);
    }
    public void ButtonWin()
    {
        PlayerPrefs.SetInt("isGuiWin", 1);
    }
    public void DestroyDialog()
    {
        guiDialog2.SetActive(false);
    }
    public void DestroyDialog0()
    {
        guiDialog0.SetActive(false);
    }
    public void DestroyDialog1()
    {
        guiDialog1.SetActive(false);
    }
}
