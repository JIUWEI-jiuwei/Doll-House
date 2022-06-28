using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MovieText : MonoBehaviour
{

    //������ʾ��Ļ��TextUI
    public Text Titles;
    //�ļ���,���ڶ�ȡ�ı�
    StreamReader sr;
    //�ı��е���Ļ������
    public int lineCount = 0;
    public float tempTime = 0.2f;
    void Start()
    {
        StartCoroutine(Display());
    }
    IEnumerator Display()
    {
        sr = new StreamReader(Application.streamingAssetsPath + "/text1.txt");
        //����һ���������ڶ�ȡ����
        StreamReader srLine = new StreamReader(Application.streamingAssetsPath + "/text1.txt");
        //ѭ������ȡ������ֱ��Ϊnullֹͣ
        while (srLine.ReadLine() != null)
        {
            lineCount++;
        }
        //�رղ��ͷ���
        srLine.Close();
        srLine.Dispose();
        for (int i = 0; i < lineCount; i++)
        {
            string tempText = sr.ReadLine();//��ȡ��һ���ı�
            if (tempText != null)
            {
                Titles.text = tempText.Split('$')[0];

                //�����е��Ǹ�$3�е�3��ȡ����
                if (float.TryParse(tempText.Split('$')[1], out tempTime))
                {
                    //Э�̵ȴ�
                    yield return new WaitForSeconds(tempTime);
                }
            }
        }
        PictureClick.text1.SetActive(false);
        StaticClass.isPlayerMove = true;
        //�رղ��ͷ���
        sr.Close();
        sr.Dispose();

    }
}