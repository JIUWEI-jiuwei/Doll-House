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
    /// <summary>判断点击门按钮</summary>
    public static bool isDoorClick = false;
    /// <summary>判断</summary>
    public static bool isItemClick = false;
    /// <summary>判断点击密码盒按钮</summary>
    public static bool isHeartBoxClick = false;
    public static int isMoveTarget = 0;
    public static int isMoveTarget2 = 0;
    public static bool isClimb = false;
    public static bool isHearBoxFirstPlay = false;

    //第二关
    /// <summary>判断点击乌龟按钮</summary>
    public static int isGuiClickNum = 0;
    public static bool isGuiClick = false;
    public static bool isGuiWin = false;

    /// <summary>判断点击祭台按钮</summary>
    public static bool isJiTaiClick = false;
    /// <summary>判断点击花盆按钮</summary>
    public static bool isFlowerPotClick = false;
    /// <summary>判断点击蛤蟆按钮</summary>
    public static bool isHamaClick = false;
    /// <summary>判断蛤蟆是想喝水还是抽烟</summary>
    public static bool isHamaDrinking = false;
    /// <summary>判断蛤蟆是否喝了毒药</summary>
    public static bool isHamaDuyao = false;
    

    public static bool one = false;
    public static bool two = false;
    public static bool three = false;
    public static bool four = false;


}
