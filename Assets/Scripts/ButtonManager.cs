using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///管理所有交互按钮的动画响应
///</summary>
class ButtonManager : MonoBehaviour
{
    private int num = 0;
    public Animator bedCase;
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
}
