using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///ȫ��panel������
///</summary>
class PanelManager : MonoBehaviour
{
    private int num = 0;
    public Transform[] panels1;

    private void Start()
    {
        OpenPanelOnly(panels1);
    }
    private void FixedUpdate()
    {
        CloseAllPanels(num);
    }
    /// <summary>
    /// �򿪵�һ��panel
    /// </summary>
    /// <param name="pages">��ǰpanel����</param>
    /// <param name="page">��һ��panel</param>
    public void OpenPanelOnly(Transform[] pages)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].gameObject.SetActive(false);
        }
        pages[0].gameObject.SetActive(true);
    }
    /// <summary>
    /// ֻ��ʾ��ǰpanel
    /// </summary>
    /// <param name="currentPanel"></param>
    public void CloseAllPanels(int currentPanel)
    {
        for(int i = 0; i < panels1.Length; i++)
        {
            panels1[i].gameObject.SetActive(false);
        }
        panels1[currentPanel].gameObject.SetActive(true);
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
}
