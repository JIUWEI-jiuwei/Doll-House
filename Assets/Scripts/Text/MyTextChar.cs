using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class MyTextChar : MonoBehaviour
{

    private Text uiText;
    //储存中间值
    private string words;
    //每个字符的显示速度
    private float timer;
    private float timer2;
    //限制条件，是否可以进行文本的输出
    private bool isPrint = false;
    private float perCharSpeed = 1;

    //private int text_length = 0;
    private string Ctext;
    // Use this for initialization
    void Start()
    {

        uiText = GetComponent<Text>();
        words = GetComponent<Text>().text;
        isPrint = true;
    }

    // Update is called once per frame
    void Update()
    {

        printText();
    }

    void printText()
    {
        try
        {
            if (isPrint)
            {

                uiText.text = words.Substring(0, (int)(perCharSpeed * timer));//截取

                timer += Time.deltaTime;

            }
        }
        catch (System.Exception)
        {
            printEnd();
        }
    }

    void printEnd()
    {
        isPrint = false;
    }
}