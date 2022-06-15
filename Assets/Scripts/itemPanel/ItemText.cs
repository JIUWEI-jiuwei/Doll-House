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
    public static string necklace = "�������ֵ�����ʵ��";
    public static string xisheng = "�������ϼ�������ϸ��";
    public static string ribbon = "����֮��������������µ��ó�";
    public static string yandou = "�����̶�����ô�������̲��أ�";
    public static string scissor = "һ������ͨͨ�ļ���";
    public static string seed = "��ͨ�����ӣ�������Щ������ʶ";
    public static string meatshu = "ǡ���ô��Ļ�򣬴������ε���ζ";
    public static string boiledmeat = "�ֺ���Ӳ�����ݵ�����";
    public static string cup = "��������������Ȼֻ��ʢҺ��";

    public static string shuidebeizi = "ֻ�ǡ���ˮ��";
    public static string tuoyedebeizi = "����˵�����е����أ�";
    public static string yancao = "�����Ի����µ�����";
    public static string yan = "�˺����ο����";
    public static string ducao = "������ǿ���Ի����µ�����";
    public static string duyao = "������˺�";
    public static string yumao = "�ɾ��ò���һ���ҳ�����ӯ��������ϧ";
    public static string cattooth = "Ϊ̰���������Ĵ���";
    public static string lung = "���ڵķΣ���֤�˶�������ǳ�";
    public static string turtleshell = "��������ҫ���������������Ǽٵ�";
    public static string yaoshi = "�Ӱ�";

    public static string bottle = "�ܳ���˵������װ�Ų���ˮ";
    public static string note1 = "�հ׵�ֽ����������һ��ţ��ζ";
    public static string note2 = "ֽ����ֻд��һ������5";
    public static string note3 = "��è�����ڻ����ڣ�����Ͷι���ڼ�Ӳ��ʳ��";
    public static string note4 = "�»���֣��ҵİ����������������֮���Ա������⡣���ˣ�������������ա�";
    public static string rawmeat = "�ܻ�������ָ�����̰����ͷ";
    public static string cattuoye = "����˵�����е����أ�";
    public static string note1_b = "ֽ���ϳ����˷��Ƶ��ּ�������������2";
    public static string zacao = "�˷���һ������";

    //��һ��
    public static string lip01 = "�ں�";
    public static string candle01 = "����";
    public static string necklace01 = "����";
    public static string xisheng01 = "ϸ��";
    public static string ribbon01 = "˿��";
    public static string scissor01 = "����";
    public static string cup01 = "����";
    public static string bottle01 = "ˮ��";
    public static string note101 = "��ױ̨�ϵ�ֽ��";
    public static string note201 = "�����ֽ��";
    public static string note301 = "���ϵ�ֽ��";
    public static string note401 = "�鱦���ڵ�ֽ��";
    public static string yumao01 = "��ë";
    public static string cattooth01 = "��è�Ķϳ�";
    public static string tuoyedebeizi01 = "ʢ��Һ�ı���";
    public static string shuidebeizi01 = "ʢˮ�ı���";
    public static string meatshu01 = "�������";
    public static string rawmeat01 = "����";
    public static string cattuoye01 = "��è����Һ";
    public static string boiledmeat01 = "�ս�����";
    public static string note1_b01 = "��ױ̨�ϵ�ֽ��";

    //�ڶ���
    public static string yandou01 = "�̶�";
    public static string seed01 = "����";
    public static string yancao01 = "�̲�";
    public static string yan01 = "��";
    public static string ducao01 = "����";
    public static string duyao01 = "��ҩ";
    public static string lung01 = "���ķ�";
    public static string turtleshell01 = "�ڹ�Ŀ�";
    public static string yaoshi01 = "Կ��";
    public static string zacao01 = "���õ��Ӳ�";


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
