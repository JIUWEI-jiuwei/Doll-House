using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MovieText : MonoBehaviour
{

    //������ʾ��Ļ��TextUi
    public Text Titles;
    //�ļ���,���ڶ�ȡ�ı�
    StreamReader sr;
    //�ı��е���Ļ������
    int lineCount = 0;
    void Start()
    {
        StartCoroutine(Display());
    }
    IEnumerator Display()
    {
        sr = new StreamReader(Application.dataPath + "/text.txt");
        //����һ���������ڶ�ȡ����
        StreamReader srLine = new StreamReader(Application.dataPath + "/text.txt");
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
            string tempText = sr.ReadLine();
            Titles.text = tempText.Split('$')[0];
            Debug.Log(Titles.text);
            //Ҳ����
            float tempTime;
            //�����е��Ǹ�$3�е�3��ȡ����
            if (float.TryParse(tempText.Split('$')[1], out tempTime))
            {
                //Э�̵ȴ�
                yield return new WaitForSeconds(tempTime);
            }
        }
        //�رղ��ͷ���
        sr.Close();
        sr.Dispose();
    }
}