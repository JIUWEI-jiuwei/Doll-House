using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///全局panel管理器
///</summary>
class PanelManager : MonoBehaviour
{
    private int num = 0;
    private int itemNum = 0;
    public Transform[] panels1;
    public Transform[] itemPanels;

    private void Start()
    {
        OpenPanelOnly(panels1);
    }
    private void FixedUpdate()
    {
        CloseAllPanels(panels1,num);
        CloseAllPanels(itemPanels,itemNum);

    }
    /// <summary>
    /// 打开第一个panel
    /// </summary>
    /// <param name="pages">当前panel数组</param>
    /// <param name="page">第一个panel</param>
    public void OpenPanelOnly(Transform[] pages)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].gameObject.SetActive(false);
        }
        pages[0].gameObject.SetActive(true);
    }
    /// <summary>
    /// 只显示当前panel
    /// </summary>
    /// <param name="currentPanel"></param>
    public void CloseAllPanels(Transform[] panels, int currentPanel)
    {
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].gameObject.SetActive(false);
        }
        panels[currentPanel].gameObject.SetActive(true);
    }
    public void RightButton()
    {
        if (num < 7)
        {
            num++;
        }
    }

    public void LeftButton()
    {
        if (num > 0)
        {
            num--;
        }
    }
    public void ItemRightButton()
    {
        if (itemNum < 2)
        {
            itemNum++;
        }
    }

    public void ItemLeftButton()
    {
        if (itemNum > 0)
        {
            itemNum--;
        }
    }


}
