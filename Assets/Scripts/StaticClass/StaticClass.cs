using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///全局静态类
///</summary>
 static class StaticClass
{
    public static bool alfa=false;
    /// <summary>判断是否有面板打开（若有面板打开，则不移动）</summary>
    public static bool isPlayerMove = true;
    /// <summary>判断角色是否完成移动</summary>
    public static bool isFinishedMove = false;
    public static bool isDoorClick = false;
    public static bool isItemClick = false;
    public static bool isHeartBoxClick = false;
    public static int isMoveTarget = 0;
    public static int isMoveTarget2 = 0;
    public static bool isClimb = false;
    public static bool isHearBoxFirstPlay = false;

}
