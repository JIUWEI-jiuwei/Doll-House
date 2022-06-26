using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 当前使用的(字幕整体渐变效果)
/// </summary>
public class InitUIFrm : MonoBehaviour
{

    Text m_TextValue;//组件 Text
    string m_TextValueColor;//Text组件的color颜色文本值

    // 介绍的内容
    string[] m_IntroContent = {//10space
            "我曾经有个家庭。     " ,
            "     ",
            "我们会围坐在大桌旁。     " ,
                        "     ",
                        "妈妈总是停不下嘴。她热衷于抱怨一些琐事。     " ,
                        "     ",
                        "爸爸与烟斗形影不离，即使在餐桌上。     " ,
                        "     ",
                        "爷爷总会记得帮奶奶夹菜，他仍然认为她还没死。     " ,
                        "     ",
                        "除此以外，他就是在谈论祖上的功绩和荣耀。     "

        };

    int m_AlphaSpan = 30;//每个渐变颜色之间的间隔
    Dictionary<int, int> m_AlphaLine;//AlpheLine 当前字对应的alpha度，当为100的时候完全显示字体
    string m_NowText;//当前显示的文字内容
    int m_TextIndex = 0;//当前迭代索引 txtIndex==intro[?].Length的时候则为print完成
    int m_BeginIndex = 0;//当前迭代开始索引，已经透明度为100的可以保存起来，避免遍历提高效率
    int m_NowPrintIndex = 0;//当前Print索引

    public float m_TimeSpan = 0.1f;//每个字的间隔时间
    float m_Timer = 0;//计时器

    bool m_IsPrint = false;//是否打印
    //bool m_IsEnd = false;//是否打印结束

    private void Awake()
    {
        m_AlphaLine = new Dictionary<int, int>();
        m_TextValue = transform.GetComponent<Text>();
        Initialize();

    }

    /// <summary>
    /// 开启打字机
    /// </summary>
    public void Initialize()
    {
        //获得颜色值
        m_TextValueColor = ColorUtility.ToHtmlStringRGB(m_TextValue.color);
        //开启打印

        m_IsPrint = true;
    }

    /// <summary>
    /// 打印方法
    /// </summary>
    public void Print()
    {
        if (m_IsPrint)
        {
            if (m_NowPrintIndex == m_IntroContent.Length)
            {
                m_IsPrint = false;
                return;
            }
            //打印内容
            if (m_TextIndex < m_IntroContent[m_NowPrintIndex].Length)
            {
                //等一段时间在继续打印下一个字
                while (m_Timer < m_TimeSpan)
                {
                    m_Timer += Time.deltaTime;
                    return;
                }
                m_Timer = 0;
                //增加一个字
                m_TextIndex++;
            }
            else
            {
                //打印完一段
                m_TextValue.color = new Color(m_TextValue.color.r, m_TextValue.color.g, m_TextValue.color.b, 0);
                //清空text的值，等下一轮打印
                m_NowPrintIndex++;
                //数据初始化
                m_TextValue.text = "";
                m_BeginIndex = 0;
                m_TextIndex = 0;
                m_AlphaLine.Clear();
                m_TextValue.color = new Color(m_TextValue.color.r, m_TextValue.color.g, m_TextValue.color.b, 1);
                //Debug.Log("这段已经打完了");
                return;

            }

            for (int i = m_BeginIndex; i < m_TextIndex; i++)
            {

                if (!m_AlphaLine.ContainsKey(i))
                {
                    m_AlphaLine.Add(i, 0);
                }
                int alpha = m_AlphaLine[i];
                //如果alpha已经大于100了，可以完全显示了，>100的没有标签，
                if (alpha >= 100)
                {
                    m_BeginIndex = i + 1;
                    m_NowText += m_IntroContent[m_NowPrintIndex].Substring(0, m_BeginIndex);
                }
                else //小于100的每个字都有标签，大于txtIndex的甚至都还轮不到它们显示
                {
                    //增加颜色标签，归一化为两位数
                    m_NowText += $"<color=#{m_TextValueColor}";
                    if (m_AlphaLine[i] < 10)
                    {
                        m_NowText += $"0{m_AlphaLine[i]}>";
                    }
                    else
                    {
                        m_NowText += $"{m_AlphaLine[i]}>";
                    }
                    m_NowText += $"{m_IntroContent[m_NowPrintIndex].Substring(i, 1)}</color>"; //把i这个字加入
                                                                                               //插值增加
                    m_AlphaLine[i] += m_AlphaSpan;
                }
            }
            //获得_NowText,文本赋值
            m_TextValue.text = m_NowText;
            m_NowText = "";
        }
        else
        {
            //Debug.Log("打印完所有的内容");
            //隐藏text和放大的图片
            //PictureClick.child0.SetActive(false);
            PictureClick.text1.SetActive(false);
            StaticClass.isPlayerMove = true;
        }
    }

   /* private void PrintNext()
    {
        //打印完一段
        m_TextValue.color = new Color(m_TextValue.color.r, m_TextValue.color.g, m_TextValue.color.b, 0);
        //清空text的值，等下一轮打印
        m_NowPrintIndex++;
        //数据初始化
        m_TextValue.text = "";
        m_BeginIndex = 0;
        m_TextIndex = 0;
        m_AlphaLine.Clear();
        m_TextValue.color = new Color(m_TextValue.color.r, m_TextValue.color.g, m_TextValue.color.b, 1);
        //Debug.Log("这段已经打完了");
        return;
    }*/

    public void Update()
    {
        Print();
    }
}


