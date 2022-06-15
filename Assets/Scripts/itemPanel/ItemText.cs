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
    public static string necklace = "若隐若现的真情实感";
    public static string xisheng = "从项链上剪下来的细绳";
    public static string ribbon = "矫饰之物，但或许能派上新的用场";
    public static string yandou = "有了烟斗，怎么能少了烟草呢？";
    public static string scissor = "一把普普通通的剪刀";
    public static string seed = "普通的种子，不过有些似曾相识";
    public static string meatshu = "恰到好处的火候，垂涎欲滴的美味";
    public static string boiledmeat = "又黑又硬，牙齿的灾难";
    public static string cup = "做工精良，但依然只能盛液体";

    public static string shuidebeizi = "只是……水？";
    public static string tuoyedebeizi = "……说不定有点用呢？";
    public static string yancao = "弱碱性环境下的作物";
    public static string yan = "伤害与宽慰并存";
    public static string ducao = "种子在强酸性环境下的作物";
    public static string duyao = "纯粹的伤害";
    public static string yumao = "干净得不落一粒灰尘，轻盈得让人怜惜";
    public static string cattooth = "为贪欲而付出的代价";
    public static string lung = "发黑的肺，见证了多少年的忧愁";
    public static string turtleshell = "身世与荣耀的象征，不过，是假的";
    public static string yaoshi = "逃吧";

    public static string bottle = "很沉，说明里面装着不少水";
    public static string note1 = "空白的纸条，但是有一股牛奶味";
    public static string note2 = "纸条上只写着一个数字5";
    public static string note3 = "狞猫正处于换牙期，请勿投喂过于坚硬的食物";
    public static string note4 = "新婚快乐，我的艾尔公主！谨奉盒中之礼以表我心意。对了，密码是你的生日。";
    public static string rawmeat = "总会引起各种各样的贪婪念头";
    public static string cattuoye = "……说不定有点用呢？";
    public static string note1_b = "纸条上出现了发黄的字迹，看着像数字2";
    public static string zacao = "浪费了一粒种子";

    //第一关
    public static string lip01 = "口红";
    public static string candle01 = "蜡烛";
    public static string necklace01 = "项链";
    public static string xisheng01 = "细绳";
    public static string ribbon01 = "丝带";
    public static string scissor01 = "剪刀";
    public static string cup01 = "杯子";
    public static string bottle01 = "水壶";
    public static string note101 = "梳妆台上的纸条";
    public static string note201 = "掉落的纸条";
    public static string note301 = "地上的纸条";
    public static string note401 = "珠宝盒内的纸条";
    public static string yumao01 = "羽毛";
    public static string cattooth01 = "狞猫的断齿";
    public static string tuoyedebeizi01 = "盛唾液的杯子";
    public static string shuidebeizi01 = "盛水的杯子";
    public static string meatshu01 = "烤熟的肉";
    public static string rawmeat01 = "生肉";
    public static string cattuoye01 = "狞猫的唾液";
    public static string boiledmeat01 = "烧焦的肉";
    public static string note1_b01 = "梳妆台上的纸条";

    //第二关
    public static string yandou01 = "烟斗";
    public static string seed01 = "种子";
    public static string yancao01 = "烟草";
    public static string yan01 = "烟";
    public static string ducao01 = "毒草";
    public static string duyao01 = "毒药";
    public static string lung01 = "蛤蟆的肺";
    public static string turtleshell01 = "乌龟的壳";
    public static string yaoshi01 = "钥匙";
    public static string zacao01 = "无用的杂草";


    public static string ShowTextByItemName(string itemName)
    {
        if (itemName == "lip") return lip;
        if (itemName == "candle") return candle;
        if (itemName == "scissor") return scissor;
        if (itemName == "cup") return cup;
        if (itemName == "ribbon") return ribbon;
        if (itemName == "bottle") return bottle;
        if (itemName == "note1") return note1;
        if (itemName == "note1_b") return note1_b;
        if (itemName == "note2") return note2;
        if (itemName == "note3") return note3;
        if (itemName == "note4") return note4;
        if (itemName == "yumao") return yumao;
        if (itemName == "xisheng") return xisheng;
        if (itemName == "cattooth") return cattooth;
        if (itemName == "cattuoye") return cattuoye;
        if (itemName == "tuoyedebeizi") return tuoyedebeizi;
        if (itemName == "shuidebeizi") return shuidebeizi;
        if (itemName == "meatshu") return meatshu;
        if (itemName == "rawmeat") return rawmeat;
        if (itemName == "boiledmeat") return boiledmeat;
        if (itemName == "necklace") return necklace;
        
        if (itemName == "yandou") return yandou;
        if (itemName == "seed") return seed;
        if (itemName == "yancao") return yancao;
        if (itemName == "yan") return yan;
        if (itemName == "ducao") return ducao;
        if (itemName == "duyao") return duyao;
        if (itemName == "lung") return lung;
        if (itemName == "turtleshell") return turtleshell;
        if (itemName == "yaoshi") return yaoshi;
        if (itemName == "zacao") return zacao;


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
        if (itemName == "note1_b01") return note1_b01;
        if (itemName == "note201") return note201;
        if (itemName == "note301") return note301;
        if (itemName == "note401") return note401;
        if (itemName == "yumao01") return yumao01;
        if (itemName == "xisheng01") return xisheng01;
        if (itemName == "cattooth01") return cattooth01;
        if (itemName == "tuoyedebeizi01") return tuoyedebeizi01;
        if (itemName == "shuidebeizi01") return shuidebeizi01;
        if (itemName == "meatshu01") return meatshu01;
        if (itemName == "rawmeat01") return rawmeat01;
        if (itemName == "cattuoye01") return cattuoye01;
        if (itemName == "boiledmeat01") return boiledmeat01;
        if (itemName == "necklace01") return necklace01;
        
        if (itemName == "yandou01") return yandou01;
        if (itemName == "seed01") return seed01;
        if (itemName == "yancao01") return yancao01;
        if (itemName == "yan01") return yan01;
        if (itemName == "ducao01") return ducao01;
        if (itemName == "duyao01") return duyao01;
        if (itemName == "lung01") return lung01;
        if (itemName == "turtleshell01") return turtleshell01;
        if (itemName == "yaoshi01") return yaoshi01;
        if (itemName == "zacao01") return zacao01;


        return itemName;
    }
}
