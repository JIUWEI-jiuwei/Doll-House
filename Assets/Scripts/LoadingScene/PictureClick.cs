using UnityEngine.UI;
using UnityEngine;

///<summary>
///½áÊø³¡¾°µã»÷Í¼Æ¬
///</summary>
class PictureClick : MonoBehaviour
{
    //public static GameObject child0;
    public static GameObject text1;
    public static GameObject text2;
    public static GameObject text3;
    public static GameObject text4;
    public static GameObject text5;
    public static GameObject pic1;
    public static GameObject pic2;
    public static GameObject pic3;
    public static GameObject pic4;
    public static GameObject pic5;
    public AudioSource audioSource;
    public AudioClip[] audioClips = new AudioClip[5];
    public GameObject[] pics = new GameObject[5];

    public static bool b_pic1 = false;
    private bool b_pic2 = false;
    private bool b_pic3 = false;
    private bool b_pic4 = false;
    private bool b_pic5 = false;

    private bool isMouseDown = false;
    private void Start()
    {
        //child0 = this.gameObject.transform.GetChild(0).gameObject;
        text1 = GameObject.Find("Text1").transform.GetChild(1).gameObject;
        pic1 = GameObject.Find("Text1").transform.GetChild(0).gameObject;

        text2 = GameObject.Find("Text2").transform.GetChild(1).gameObject;
        pic2 = GameObject.Find("Text2").transform.GetChild(0).gameObject;

        text3 = GameObject.Find("Text3").transform.GetChild(1).gameObject;
        pic3 = GameObject.Find("Text3").transform.GetChild(0).gameObject;

        text4 = GameObject.Find("Text4").transform.GetChild(1).gameObject;
        pic4 = GameObject.Find("Text4").transform.GetChild(0).gameObject;

        text5 = GameObject.Find("Text5").transform.GetChild(1).gameObject;
        pic5 = GameObject.Find("Text5").transform.GetChild(0).gameObject;
        //audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        isMouseDown = true;

    }
    private void FixedUpdate()
    {
        if (isMouseDown)
        {
            
            //audioSource.Play();
            if (this.gameObject.name == "picture1")
            {
                pic1.SetActive(true);
            }
            else if (this.gameObject.name == "picture2")
            {
                pic2.SetActive(true);
                if (!b_pic2)
                {
                    text2.SetActive(true);
                    audioSource.clip = audioClips[1];
                    audioSource.Play();
                    b_pic2 = true;
                }
            }
            else if (this.gameObject.name == "picture3")
            {
                pic3.SetActive(true);
                if (!b_pic3)
                {
                    text3.SetActive(true);
                    audioSource.clip = audioClips[2];
                    audioSource.Play();
                    b_pic3 = true;
                }
            }
            else if (this.gameObject.name == "picture4")
            {
                pic4.SetActive(true);
                if (!b_pic4)
                {
                    text4.SetActive(true);
                    audioSource.clip = audioClips[3];
                    audioSource.Play();
                    b_pic4 = true;
                }
            }
            else if (this.gameObject.name == "picture5")
            {
                pic5.SetActive(true);
                if (!b_pic5)
                {
                    text5.SetActive(true);
                    audioSource.clip = audioClips[4];
                    audioSource.Play();
                    b_pic5 = true;
                }
            }
            else if (this.gameObject.name == "picture0")
            {
                for(int i = 0; i < pics.Length; i++)
                {
                    pics[i].SetActive(true);
                }
                pic1.SetActive(true);
                this.gameObject.SetActive(false);
                if (!b_pic1)
                {
                    text1.SetActive(true);
                    audioSource.clip = audioClips[0];
                    audioSource.Play();
                    b_pic1 = true;
                }
            }

            isMouseDown = false;
            StaticClass.isPlayerMove = false;
        }
    }
    public void Back1()
    {
        pic1.SetActive(false);
        StaticClass.isPlayerMove = true;
    }
    public void Back2()
    {
        pic2.SetActive(false);
        StaticClass.isPlayerMove = true;
    }
    public void Back3()
    {
        pic3.SetActive(false);
        StaticClass.isPlayerMove = true;
    }
    public void Back4()
    {
        pic4.SetActive(false);
        StaticClass.isPlayerMove = true;
    }
    public void Back5()
    {
        pic5.SetActive(false);
        StaticClass.isPlayerMove = true;
    }

}
