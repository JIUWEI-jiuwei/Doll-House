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

    private void Start()
    {
        GameObject bedcase = GameObject.FindGameObjectWithTag("BC");
        bedCase = bedcase.GetComponent<Animator>();
        GameObject rightcase1 = GameObject.FindGameObjectWithTag("CT1");
        rightCase1 = rightcase1.GetComponent<Animator>();
        GameObject rightcase2 = GameObject.FindGameObjectWithTag("CT2");
        rightCase2 = rightcase2.GetComponent<Animator>();
        GameObject rightcase3 = GameObject.FindGameObjectWithTag("CT3");
        rightCase3 = rightcase3.GetComponent<Animator>();

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
}
