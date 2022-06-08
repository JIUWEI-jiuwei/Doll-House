using UnityEngine.UI;
using UnityEngine;

///<summary>
///猫
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
            {//鹅嘴没被绑
                catTextBg.GetComponentInChildren<Text>().text = "鹅很吵，想办法让鹅闭嘴";
                catTextBg.SetActive(true);
                Invoke("CloseCatText", 2f);
            }
            else if (Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("Mouseidle"))
            {//鹅嘴被绑，腿没被绑
                catTextBg.GetComponentInChildren<Text>().text = "将鹅的腿绑起来或许会好一些";
                catTextBg.SetActive(true);
                Invoke("CloseCatText", 2f);
            }
            else //鹅嘴被绑，腿被绑
            {
                catTextBg.GetComponentInChildren<Text>().text = "想吃肉";
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
