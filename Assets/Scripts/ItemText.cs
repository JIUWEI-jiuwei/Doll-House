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
    public static string shurou = "ǡ���ô��Ļ�򣬴������ε���ζ";
    public static string shaojiaoderou = "�ֺ���Ӳ�����ݵ�����";
    public static string cup = "��������������Ȼֻ��ʢҺ��";
    public static string chengshuidebeizi = "ֻ�ǡ���ˮ��";
    public static string ningmaotuoyedebeizi = "����˵�����е����أ�";
    public static string yancao = "�����Ի����µ�����";
    public static string yan = "�˺����ο����";
    public static string ducao = "������ǿ���Ի����µ�����";
    public static string duyao = "������˺�";
    public static string mimazhitiao = "����д��һ����ֵ�����";
    public static string edeyumao = "�ɾ��ò���һ���ҳ�����ӯ��������ϧ";
    public static string eningmaodeduanchi = "Ϊ̰���������Ĵ���";
    public static string hamadefei = "���ڵķΣ���֤�˶�������ǳ�";
    public static string wuguideke = "��������ҫ���������������Ǽٵ�";
    public static string yaoshi = "�Ӱ�";
    public static string bottle = "�ܳ���˵������װ�Ų���ˮ";

    public static string lip01 = "�ں�";
    public static string candle01 = "����";
    public static string necklace01 = "����";
    public static string xisheng01 = "ϸ��";
    public static string ribbon01 = "˿��";
    public static string yandou01 = "�̶�";
    public static string scissor01 = "����";
    public static string cup01 = "����";
    public static string bottle01 = "ˮ��";

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
