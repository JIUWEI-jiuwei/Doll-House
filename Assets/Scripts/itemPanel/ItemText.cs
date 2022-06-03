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
    public static string meatshu = "恰到好处的火候，垂涎欲滴的美味";
    public static string boiledmeat = "又黑又硬，牙齿的灾难";
    public static string cup = "做工精良，但依然只能盛液体";
    public static string shuidebeizi = "只是……水？";
    public static string tuoyedebeizi = "……说不定有点用呢？";
    public static string yancao = "弱碱性环境下的作物";
    public static string yan = "伤害与宽慰并存";
    public static string ducao = "种子在强酸性环境下的作物";
    public static string duyao = "纯粹的伤害";
    public static string mimazhitiao = "上面写着一个奇怪的数字";
    public static string yumao = "干净得不落一粒灰尘，轻盈得让人怜惜";
    public static string cattooth = "为贪欲而付出的代价";
    public static string hamadefei = "发黑的肺，见证了多少年的忧愁";
    public static string wuguideke = "身世与荣耀的象征，不过，是假的";
    public static string yaoshi = "逃吧";
    public static string bottle = "很沉，说明里面装着不少水";
    public static string note1 = "空白的纸条，但是有一股牛奶味";
    public static string note2 = "纸条上只写着一个数字5";
    public static string note3 = "狞猫正处于换牙期，请勿投喂过于坚硬的食物";
    public static string rawmeat = "生肉";
    public static string cattuoye = "狞猫的唾液";
    public static string note1_b = "纸条上出现了发黄的字迹，看着像数字2";


    public static string lip01 = "口红";
    public static string candle01 = "蜡烛";
    public static string necklace01 = "项链";
    public static string xisheng01 = "细绳";
    public static string ribbon01 = "丝带";
    public static string yandou01 = "烟斗";
    public static string scissor01 = "剪刀";
    public static string cup01 = "杯子";
    public static string bottle01 = "水壶";
    public static string note101 = "梳妆台上的纸条";
    public static string note201 = "掉落的纸条";
    public static string note301 = "地上的纸条";
    public static string yumao01 = "羽毛";
    public static string cattooth01 = "狞猫的断齿";
    public static string tuoyedebeizi01 = "盛唾液的杯子";
    public static string shuidebeizi01 = "盛水的杯子";
    public static string meatshu01 = "烤熟的肉";
    public static string rawmeat01 = "生肉";
    public static string cattuoye01 = "狞猫的唾液";
    public static string boiledmeat01 = "烧焦的肉";
    public static string note1_b01 = "梳妆台上的纸条";


    public static string ShowTextByItemName(string itemName)
    {
        if (itemName == "lip") return lip;
        if (itemName == "candle") return candle;
        if (itemName == "scissor") return scissor;
        if (itemName == "cup") return cup;
        if (itemName == "ribbon") return ribbon;
        if (itemName == "bottle") return bottle;
        if (itemName == "note1") return note1;
        if (itemName == "note1_b") return note1;
        if (itemName == "note2") return note2;
        if (itemName == "note3") return note3;
        if (itemName == "yumao") return yumao;
        if (itemName == "xisheng") return xisheng;
        if (itemName == "cattooth") return cattooth;
        if (itemName == "cattuoye") return cattuoye;
        if (itemName == "tuoyedebeizi") return tuoyedebeizi;
        if (itemName == "shuidebeizi") return shuidebeizi;
        if (itemName == "meatshu") return meatshu;
        if (itemName == "rawmeat") return rawmeat;
        if (itemName == "boiledmeat") return boiledmeat;


        return itemName;
    }   
    public static string ShowItemName(string itemName)
    {
        if (itemName == "lip01") return lip01;
        if (itemName == "candle01") return candle01;
        if (itemName == "scissor01") return scissor01;
        if (itemName == "cup01") return cup01;
        if (itemName == "ribbon01") return ribbon01;
        if (itemName == "bottle01") return bottle01;
        if (itemName == "note101") return note101;
        if (itemName == "note201") return note201;
        if (itemName == "note301") return note301;
        if (itemName == "yumao01") return yumao01;
        if (itemName == "xisheng01") return xisheng01;
        if (itemName == "cattooth01") return cattooth01;
        if (itemName == "tuoyedebeizi01") return tuoyedebeizi01;
        if (itemName == "shuidebeizi01") return shuidebeizi01;
        if (itemName == "meatshu01") return meatshu01;
        if (itemName == "rawmeat01") return rawmeat01;
        if (itemName == "cattuoye01") return cattuoye01;
        if (itemName == "boiledmeat01") return boiledmeat01;
        if (itemName == "note1_b01") return note1_b01;

        return itemName;
    }
}
