using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///�������н�����ť�Ķ�����Ӧ
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
