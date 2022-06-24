using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MovieText : MonoBehaviour
{

    //用来显示字幕的TextUi
    public Text Titles;
    //文件流,用于读取文本
    StreamReader sr;
    //文本中的字幕的行数
    int lineCount = 0;
    void Start()
    {
        StartCoroutine(Display());
    }
    IEnumerator Display()
    {
        sr = new StreamReader(Application.dataPath + "/text.txt");
        //创建一个流，用于读取行数
        StreamReader srLine = new StreamReader(Application.dataPath + "/text.txt");
        //循环来读取行数，直到为null停止
        while (srLine.ReadLine() != null)
        {
            lineCount++;
        }
        //关闭并释放流
        srLine.Close();
        srLine.Dispose();
        for (int i = 0; i < lineCount; i++)
        {
            string tempText = sr.ReadLine();
            Titles.text = tempText.Split('$')[0];
            Debug.Log(Titles.text);
            //也就是
            float tempTime;
            //将文中的那个$3中的3读取出来
            if (float.TryParse(tempText.Split('$')[1], out tempTime))
            {
                //协程等待
                yield return new WaitForSeconds(tempTime);
            }
        }
        //关闭并释放流
        sr.Close();
        sr.Dispose();
    }
}