using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///��Ʒ����Ʒ�Ľ���
///</summary>
static class ItemText
{
    public static string kouhong = "�ɴ�˹������Ϊ��������ѡ�����ŵ�����ɫ��";
    public static string lazhu = "";
    public static string xainglian = "�ʱ�ϴ�ӹ��ı�΢Ԫ�أ��������ֵ�����ʵ��";
    public static string xisheng = "�����ϵ�ϸ��";
    public static string sidai = "����֮��������������µ��ó�";
    public static string yandou = "�����̶�����ô�������̲��أ�";
    public static string jiandao = "һ������ͨͨ�ļ���";
    public static string zhongzi = "��ͨ�����ӣ�������Щ������ʶ";
    public static string shengrou = "�ܻ�������ָ�����̰����ͷ";
    public static string shurou = "ǡ���ô��Ļ�򣬴������ε���ζ";
    public static string shaojiaoderou = "�ֺ���Ӳ�����ݵ�����";
    public static string beizi = "��������������Ȼֻ��ʢҺ��";
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

    public static string ShowTextByItemName(string itemName)
    {
        if (itemName == "kouhong") return kouhong;
        return itemName;
    }   
}
