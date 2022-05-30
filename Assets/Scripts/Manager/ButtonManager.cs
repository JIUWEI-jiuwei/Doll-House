using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///管理所有交互按钮的动画响应
///</summary>
class ButtonManager : MonoBehaviour
{
    private int num = 0;
    private int numTre1 = 0;
    private int numTre2 = 0;
    private int numTre3 = 0;

    private Animator bedCase;
    private Animator rightCase1;
    private Animator rightCase2;
    private Animator rightCase3;

    private GameObject diaryPanel;
    private GameObject blackPanel;


    private void Start()
    {
        bedCase = GameObject.FindGameObjectWithTag("BC").GetComponent<Animator>();
        rightCase1 = GameObject.FindGameObjectWithTag("CT1").GetComponent<Animator>();
        rightCase2 = GameObject.FindGameObjectWithTag("CT2").GetComponent<Animator>();
        rightCase3 = GameObject.FindGameObjectWithTag("CT3").GetComponent<Animator>();

        diaryPanel = GameObject.Find("diary").transform.GetChild(0).gameObject;
        
    }
    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("blackpanel") != null)
        {
            blackPanel = GameObject.FindGameObjectWithTag("blackpanel");
        }
    }
    public void BedCaseRight()
    {
        num++;
        if (num % 2 == 0)
        {
            bedCase.SetBool("bedCaseRight", true);
        }
        else
        {
            bedCase.SetBool("bedCaseRight", false);
        }
    }
    public void ThreeRightCase1()
    {
        numTre1++;
        if (numTre1 % 2 == 0)
        {
            rightCase1.SetBool("CT1pull", false);
        }
        else
        {
            rightCase1.SetBool("CT1pull",true);
        }
    }
    public void ThreeRightCase2()
    {
        numTre2++;
        rightCase2.SetInteger("CT2INT", numTre2 % 3);
    }
    public void ThreeRightCase3()
    {
        numTre3++;
        rightCase3.SetInteger("CT3INT", numTre3 % 4);
    }
    /// <summary>
    /// 日记本按钮
    /// </summary>
    public void Diary()
    {
        diaryPanel.SetActive(true);
    }
    public void CloseBlackPanel()
    {
        blackPanel.SetActive(false);
    }
}
