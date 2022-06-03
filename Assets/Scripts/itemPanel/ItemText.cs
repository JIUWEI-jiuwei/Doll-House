using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///��Ʒ����Ʒ�Ľ���
///</summary>
static class ItemText
{
    public static string lip = "�ɴ�˹������Ϊ��������ѡ�����ŵ�����ɫ��";
    public static string candle = "�л���";
    public static string necklace = "�ʱ�ϴ�ӹ��ı�΢Ԫ�أ��������ֵ�����ʵ��";
    public static string xisheng = "�����ϵ�ϸ��";
    public static string ribbon = "����֮��������������µ��ó�";
    public static string yandou = "�����̶�����ô�������̲��أ�";
    public static string scissor = "һ������ͨͨ�ļ���";
    public static string zhongzi = "��ͨ�����ӣ�������Щ������ʶ";
    public static string shengrou = "�ܻ�������ָ�����̰����ͷ";
    public static string meatshu = "ǡ���ô��Ļ�򣬴������ε���ζ";
    public static string boiledmeat = "�ֺ���Ӳ�����ݵ�����";
    public static string cup = "��������������Ȼֻ��ʢҺ��";
    public static string shuidebeizi = "ֻ�ǡ���ˮ��";
    public static string tuoyedebeizi = "����˵�����е����أ�";
    public static string yancao = "�����Ի����µ�����";
    public static string yan = "�˺����ο����";
    public static string ducao = "������ǿ���Ի����µ�����";
    public static string duyao = "������˺�";
    public static string mimazhitiao = "����д��һ����ֵ�����";
    public static string yumao = "�ɾ��ò���һ���ҳ�����ӯ��������ϧ";
    public static string cattooth = "Ϊ̰���������Ĵ���";
    public static string hamadefei = "���ڵķΣ���֤�˶�������ǳ�";
    public static string wuguideke = "��������ҫ���������������Ǽٵ�";
    public static string yaoshi = "�Ӱ�";
    public static string bottle = "�ܳ���˵������װ�Ų���ˮ";
    public static string note1 = "�հ׵�ֽ����������һ��ţ��ζ";
    public static string note2 = "ֽ����ֻд��һ������5";
    public static string note3 = "��è�����ڻ����ڣ�����Ͷι���ڼ�Ӳ��ʳ��";
    public static string rawmeat = "����";
    public static string cattuoye = "��è����Һ";
    public static string note1_b = "ֽ���ϳ����˷��Ƶ��ּ�������������2";


    public static string lip01 = "�ں�";
    public static string candle01 = "����";
    public static string necklace01 = "����";
    public static string xisheng01 = "ϸ��";
    public static string ribbon01 = "˿��";
    public static string yandou01 = "�̶�";
    public static string scissor01 = "����";
    public static string cup01 = "����";
    public static string bottle01 = "ˮ��";
    public static string note101 = "��ױ̨�ϵ�ֽ��";
    public static string note201 = "�����ֽ��";
    public static string note301 = "���ϵ�ֽ��";
    public static string yumao01 = "��ë";
    public static string cattooth01 = "��è�Ķϳ�";
    public static string tuoyedebeizi01 = "ʢ��Һ�ı���";
    public static string shuidebeizi01 = "ʢˮ�ı���";
    public static string meatshu01 = "�������";
    public static string rawmeat01 = "����";
    public static string cattuoye01 = "��è����Һ";
    public static string boiledmeat01 = "�ս�����";
    public static string note1_b01 = "��ױ̨�ϵ�ֽ��";


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
