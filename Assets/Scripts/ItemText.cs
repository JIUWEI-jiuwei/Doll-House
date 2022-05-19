using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///物品栏物品的介绍
///</summary>
static class ItemText
{
    public static string lip = "由崔斯特王子为婚礼精心挑选，优雅的正红色。";
    public static string candle = "有火了";
    public static string necklace = "资本洗涤过的卑微元素，若隐若现的真情实感";
    public static string xisheng = "项链上的细绳";
    public static string ribbon = "矫饰之物，但或许能派上新的用场";
    public static string yandou = "有了烟斗，怎么能少了烟草呢？";
    public static string scissor = "一把普普通通的剪刀";
    public static string zhongzi = "普通的种子，不过有些似曾相识";
    public static string shengrou = "总会引起各种各样的贪婪念头";
    public static string shurou = "恰到好处的火候，垂涎欲滴的美味";
    public static string shaojiaoderou = "又黑又硬，牙齿的灾难";
    public static string cup = "做工精良，但依然只能盛液体";
    public static string chengshuidebeizi = "只是……水？";
    public static string ningmaotuoyedebeizi = "……说不定有点用呢？";
    public static string yancao = "弱碱性环境下的作物";
    public static string yan = "伤害与宽慰并存";
    public static string ducao = "种子在强酸性环境下的作物";
    public static string duyao = "纯粹的伤害";
    public static string mimazhitiao = "上面写着一个奇怪的数字";
    public static string edeyumao = "干净得不落一粒灰尘，轻盈得让人怜惜";
    public static string eningmaodeduanchi = "为贪欲而付出的代价";
    public static string hamadefei = "发黑的肺，见证了多少年的忧愁";
    public static string wuguideke = "身世与荣耀的象征，不过，是假的";
    public static string yaoshi = "逃吧";
    public static string bottle = "很沉，说明里面装着不少水";

    public static string lip01 = "口红";
    public static string candle01 = "蜡烛";
    public static string necklace01 = "项链";
    public static string xisheng01 = "细绳";
    public static string ribbon01 = "丝带";
    public static string yandou01 = "烟斗";
    public static string scissor01 = "剪刀";
    public static string cup01 = "杯子";
    public static string bottle01 = "水壶";

    public static string ShowTextByItemName(string itemName)
    {
        if (itemName == "lip") return lip;
        if (itemName == "candle") return candle;
        if (itemName == "scissor") return scissor;
        if (itemName == "cup") return cup;
        if (itemName == "ribbon") return ribbon;

        return itemName;
    }   
    public static string ShowItemName(string itemName)
    {
        if (itemName == "lip01") return lip01;
        if (itemName == "candle01") return candle01;
        if (itemName == "scissor01") return scissor01;
        if (itemName == "cup01") return cup01;
        if (itemName == "ribbon01") return ribbon01;
        return itemName;
    }
}
