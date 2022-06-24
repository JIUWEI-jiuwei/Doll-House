using UnityEngine.UI;
using UnityEngine;

///<summary>
///½áÊø³¡¾°µã»÷Í¼Æ¬
///</summary>
class PictureClick : MonoBehaviour
{
    public static GameObject child0;
    public static GameObject text1;
    public static GameObject text2;
    public static GameObject text3;
    private AudioSource audioSource;
    private bool isMouseDown = false;
    private void Start()
    {
        child0 = this.gameObject.transform.GetChild(0).gameObject;
        text1 = GameObject.Find("Text1").transform.GetChild(0).gameObject;
        text2 = GameObject.Find("Text2").transform.GetChild(0).gameObject;
        text3 = GameObject.Find("Text3").transform.GetChild(0).gameObject;
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        isMouseDown = true;
        StaticClass.isPlayerMove = false ;
    }
    private void FixedUpdate()
    {
        if (StaticClass.isFinishedMove&&isMouseDown==true)
        {
            child0.SetActive(true);
            audioSource.Play();
            if (this.gameObject.name == "picture1")
            {
                text1.SetActive(true);
            }
            else if (this.gameObject.name == "picture2")
            {
                text2.SetActive(true);
            }
            else if (this.gameObject.name == "picture3")
            {
                text3.SetActive(true);
            }
        }
    }
}
