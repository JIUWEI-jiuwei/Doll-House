using UnityEngine.UI;
using UnityEngine;

///<summary>
///è
///</summary>
class Cat : MonoBehaviour
{
    public Animator cat;
    private GameObject catTextBg;
    private void Start()
    {
        catTextBg = cat.transform.GetChild(0).gameObject;
    }
    private void FixedUpdate()
    {
        
    }
    public void CatSpeak()
    {
        if (StaticClass.isFinishedMove)
        {
            cat.SetBool("catspeak", true);
            if (PlayerPrefs.GetInt("isGoose1") == 0)//Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("GooseAnim")
            {//����û����
                catTextBg.GetComponentInChildren<Text>().text = "��ͷ�쳳�����ˣ�����취�������������";
                catTextBg.SetActive(true);
                Invoke("CloseCatText", 2f);
            }
            else if (PlayerPrefs.GetInt("isGoose1") == 1)
            {//���챻����û����
                catTextBg.GetComponentInChildren<Text>().text = "�������Ƕ�һ�������ڣ������������Ҳ��������";
                catTextBg.SetActive(true);
                Invoke("CloseCatText", 2f);
            }
            else //���챻���ȱ���
            {
                catTextBg.GetComponentInChildren<Text>().text = "�����徻�ˣ����һ��ж��ӵ��";
                catTextBg.SetActive(true);
                Invoke("CloseCatText", 2f);
            }
        }        
    }
    public void CloseCatText()
    {
        catTextBg.SetActive(false);
    }
}
