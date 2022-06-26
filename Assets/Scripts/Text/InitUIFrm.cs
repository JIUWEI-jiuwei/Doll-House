using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��ǰʹ�õ�(��Ļ���彥��Ч��)
/// </summary>
public class InitUIFrm : MonoBehaviour
{

    Text m_TextValue;//��� Text
    string m_TextValueColor;//Text�����color��ɫ�ı�ֵ

    // ���ܵ�����
    string[] m_IntroContent = {//10space
            "�������и���ͥ��     " ,
            "     ",
            "���ǻ�Χ���ڴ����ԡ�     " ,
                        "     ",
                        "��������ͣ�����졣�������ڱ�ԹһЩ���¡�     " ,
                        "     ",
                        "�ְ����̶���Ӱ���룬��ʹ�ڲ����ϡ�     " ,
                        "     ",
                        "үү�ܻ�ǵð����̼вˣ�����Ȼ��Ϊ����û����     " ,
                        "     ",
                        "�������⣬��������̸�����ϵĹ�������ҫ��     "

        };

    int m_AlphaSpan = 30;//ÿ��������ɫ֮��ļ��
    Dictionary<int, int> m_AlphaLine;//AlpheLine ��ǰ�ֶ�Ӧ��alpha�ȣ���Ϊ100��ʱ����ȫ��ʾ����
    string m_NowText;//��ǰ��ʾ����������
    int m_TextIndex = 0;//��ǰ�������� txtIndex==intro[?].Length��ʱ����Ϊprint���
    int m_BeginIndex = 0;//��ǰ������ʼ�������Ѿ�͸����Ϊ100�Ŀ��Ա�������������������Ч��
    int m_NowPrintIndex = 0;//��ǰPrint����

    public float m_TimeSpan = 0.1f;//ÿ���ֵļ��ʱ��
    float m_Timer = 0;//��ʱ��

    bool m_IsPrint = false;//�Ƿ��ӡ
    //bool m_IsEnd = false;//�Ƿ��ӡ����

    private void Awake()
    {
        m_AlphaLine = new Dictionary<int, int>();
        m_TextValue = transform.GetComponent<Text>();
        Initialize();

    }

    /// <summary>
    /// �������ֻ�
    /// </summary>
    public void Initialize()
    {
        //�����ɫֵ
        m_TextValueColor = ColorUtility.ToHtmlStringRGB(m_TextValue.color);
        //������ӡ

        m_IsPrint = true;
    }

    /// <summary>
    /// ��ӡ����
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
            //��ӡ����
            if (m_TextIndex < m_IntroContent[m_NowPrintIndex].Length)
            {
                //��һ��ʱ���ڼ�����ӡ��һ����
                while (m_Timer < m_TimeSpan)
                {
                    m_Timer += Time.deltaTime;
                    return;
                }
                m_Timer = 0;
                //����һ����
                m_TextIndex++;
            }
            else
            {
                //��ӡ��һ��
                m_TextValue.color = new Color(m_TextValue.color.r, m_TextValue.color.g, m_TextValue.color.b, 0);
                //���text��ֵ������һ�ִ�ӡ
                m_NowPrintIndex++;
                //���ݳ�ʼ��
                m_TextValue.text = "";
                m_BeginIndex = 0;
                m_TextIndex = 0;
                m_AlphaLine.Clear();
                m_TextValue.color = new Color(m_TextValue.color.r, m_TextValue.color.g, m_TextValue.color.b, 1);
                //Debug.Log("����Ѿ�������");
                return;

            }

            for (int i = m_BeginIndex; i < m_TextIndex; i++)
            {

                if (!m_AlphaLine.ContainsKey(i))
                {
                    m_AlphaLine.Add(i, 0);
                }
                int alpha = m_AlphaLine[i];
                //���alpha�Ѿ�����100�ˣ�������ȫ��ʾ�ˣ�>100��û�б�ǩ��
                if (alpha >= 100)
                {
                    m_BeginIndex = i + 1;
                    m_NowText += m_IntroContent[m_NowPrintIndex].Substring(0, m_BeginIndex);
                }
                else //С��100��ÿ���ֶ��б�ǩ������txtIndex�����������ֲ���������ʾ
                {
                    //������ɫ��ǩ����һ��Ϊ��λ��
                    m_NowText += $"<color=#{m_TextValueColor}";
                    if (m_AlphaLine[i] < 10)
                    {
                        m_NowText += $"0{m_AlphaLine[i]}>";
                    }
                    else
                    {
                        m_NowText += $"{m_AlphaLine[i]}>";
                    }
                    m_NowText += $"{m_IntroContent[m_NowPrintIndex].Substring(i, 1)}</color>"; //��i����ּ���
                                                                                               //��ֵ����
                    m_AlphaLine[i] += m_AlphaSpan;
                }
            }
            //���_NowText,�ı���ֵ
            m_TextValue.text = m_NowText;
            m_NowText = "";
        }
        else
        {
            //Debug.Log("��ӡ�����е�����");
            //����text�ͷŴ��ͼƬ
            //PictureClick.child0.SetActive(false);
            PictureClick.text1.SetActive(false);
            StaticClass.isPlayerMove = true;
        }
    }

   /* private void PrintNext()
    {
        //��ӡ��һ��
        m_TextValue.color = new Color(m_TextValue.color.r, m_TextValue.color.g, m_TextValue.color.b, 0);
        //���text��ֵ������һ�ִ�ӡ
        m_NowPrintIndex++;
        //���ݳ�ʼ��
        m_TextValue.text = "";
        m_BeginIndex = 0;
        m_TextIndex = 0;
        m_AlphaLine.Clear();
        m_TextValue.color = new Color(m_TextValue.color.r, m_TextValue.color.g, m_TextValue.color.b, 1);
        //Debug.Log("����Ѿ�������");
        return;
    }*/

    public void Update()
    {
        Print();
    }
}


