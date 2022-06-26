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
            if (PlayerPrefs.GetInt("isGoose1") == 0)//Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("GooseAnim")
            {//鹅嘴没被绑
                catTextBg.GetComponentInChildren<Text>().text = "那头鹅吵死人了！能想办法把它的嘴闭上吗？";
                catTextBg.SetActive(true);
                Invoke("CloseCatText", 2f);
            }
            else if (PlayerPrefs.GetInt("isGoose1") == 1)
            {//鹅嘴被绑，腿没被绑
                catTextBg.GetComponentInChildren<Text>().text = "它还在那儿一个劲扑腾！真想把它的腿也绑起来。";
                catTextBg.SetActive(true);
                Invoke("CloseCatText", 2f);
            }
            else //鹅嘴被绑，腿被绑
            {
                catTextBg.GetComponentInChildren<Text>().text = "耳朵清净了，但我还有肚子得填饱";
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
