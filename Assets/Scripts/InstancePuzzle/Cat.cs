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
            if (Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("GooseAnim"))
            {//����û����
                catTextBg.GetComponentInChildren<Text>().text = "��ܳ�����취�ö����";
                catTextBg.SetActive(true);
                Invoke("CloseCatText", 2f);
            }
            else if (Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("Mouseidle"))
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
    }
    public void CloseCatText()
    {
        catTextBg.SetActive(false);
    }
}
