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
        cat.SetBool("catspeak", true);
        if (Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("EIdle"))
        {//����û����
            catTextBg.GetComponentInChildren<Text>().text = "��ܳ�����취�ö����";
            catTextBg.SetActive(true);
            Invoke("CloseCatText", 2f);
        }
        else if (Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("EMouseIdle"))
        {//���챻����û����
            catTextBg.GetComponentInChildren<Text>().text = "������Ȱ�����������һЩ";
            catTextBg.SetActive(true);
            Invoke("CloseCatText", 2f);
        }
        else //���챻���ȱ���
        {
            catTextBg.GetComponentInChildren<Text>().text = "�����";
            catTextBg.SetActive(true);
            Invoke("CloseCatText", 2f);
        }
    }
    public void CloseCatText()
    {
        catTextBg.SetActive(false);
    }
}
