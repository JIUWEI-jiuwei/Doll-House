using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;

///<summary>
///密码盒
///</summary>
class HeartBox : MonoBehaviour
{
    /// <summary>密码盒的两段视频</summary>
    public VideoPlayer heartVideo;
    public VideoPlayer necklaceVideo;
    public GameObject itemImage;
    private int num1 = 0;
    private int num2 = 0;
    private int num3 = 0;
    private int num4 = 0;
    public Button bt1;
    public Button bt2;
    public Button bt3;
    public Button bt4;
    /// <summary>解开密码的panel面板的父物体F</summary>
    private GameObject mimaPanel;
    /// <summary>解开密码的panel面板</summary>
    private Transform mimaPanel0;
    /// <summary>密码盒按钮的SpriteState</summary>
    private SpriteState spriteStatus;
    /// <summary>是否为第一次点击按钮</summary>
    //private bool isFirst = true;

    private void Start()
    {
        //获取按钮的文本
        bt1.GetComponentInChildren<Text>().text = num1.ToString();
        bt2.GetComponentInChildren<Text>().text = num2.ToString();
        bt3.GetComponentInChildren<Text>().text = num3.ToString();
        bt4.GetComponentInChildren<Text>().text = num4.ToString();
        //获取密码盒面板
        mimaPanel = GameObject.FindGameObjectWithTag("mimahe");
        mimaPanel0 = mimaPanel.transform.GetChild(0);
        mimaPanel0.gameObject.SetActive(false);
        //创建一个新的SpriteState（唯一可行的修改SpriteState的方法）
        spriteStatus = new SpriteState();
        if (PlayerPrefs.GetInt("HeartBox") == 1)
        {
            SwapSprite();
        }
        if(PlayerPrefs.GetInt("isHearBoxFirstPlay") == 1)
        {
            GetComponent<Button>().interactable = false;
        }
    }
    private void Update()
    {
        //判断打开密码盒视频是否播放完成(注意：一定要放在update里面，才可以判断视频当前帧数)
        if (heartVideo.isPlaying)
        {
            if ((int)heartVideo.frame >= (int)heartVideo.frameCount - 1)
            {
                heartVideo.gameObject.SetActive(false);
                mimaPanel0.gameObject.SetActive(true);
                StaticClass.isPlayerMove = false;
                AudioManager.audioSource.Play();
            }
        }
        //点击密码盒按钮
        if (StaticClass.isFinishedMove && StaticClass.isHeartBoxClick)
        {
            if (PlayerPrefs.GetInt("HeartBox")==0)//第一次点击
            {
                heartVideo.Play();
                AudioManager.audioSource.Stop();
                //获得丝带
                ItemPanelClick.ChangeItemPanel("ribbon");
                ItemPanelClick.ChangeItemPanel("note4");
                Invoke("SwapSprite", 1f);//延迟1s调用是为了防止视频延迟播放的情况
                PlayerPrefs.SetInt("HeartBox", 1);
            }
            else//第二次及以后点击
            {
                mimaPanel0.gameObject.SetActive(true);

            }
            StaticClass.isPlayerMove = false;
            StaticClass.isHeartBoxClick = false;
        }
        //如果密码正确
        OpenBoxWin();
    }
    /// <summary>
    /// 成功打开密码盒
    /// </summary>
    private void OpenBoxWin()
    {
        if (PlayerPrefs.GetInt("isHearBoxFirstPlay")==0)
        {
            if (num1 == 0 && num2 == 8 && num3 == 1 && num4 == 4)
            {
                necklaceVideo.Play();
                AudioManager.audioSource.Stop();
                if (necklaceVideo.isPlaying)
                {
                    //判断视频是否播放完成
                    if ((int)necklaceVideo.frame >= (int)necklaceVideo.frameCount - 1)
                    {
                        AudioManager.audioSource.Play();
                        necklaceVideo.gameObject.SetActive(false);
                        mimaPanel0.gameObject.SetActive(false);
                        StaticClass.isPlayerMove = true;
                        //密码盒不可再交互
                        GetComponent<Button>().interactable = false;
                        //获得项链
                        ItemPanelClick.ChangeItemPanel("necklace");
                        PlayerPrefs.SetInt("isHearBoxFirstPlay", 1);
                    }
                }
            }
        }        
    }

    /// <summary>
    /// 第一次点击密码盒，播放视频
    /// </summary>
    public void FirstOpenBox()
    {
        StaticClass.isHeartBoxClick = true;
    }
    /// <summary>
    /// 切换按钮的sprite图片
    /// </summary>
    private void SwapSprite()
    {
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("heartbox");
        spriteStatus.highlightedSprite = Resources.Load<Sprite>("heartboxY");
        spriteStatus.pressedSprite = Resources.Load<Sprite>("heartboxY");
        spriteStatus.selectedSprite = Resources.Load<Sprite>("heartboxY");
        this.GetComponent<Button>().spriteState = spriteStatus;
    }

    /// <summary>
    /// 四个密码数字
    /// </summary>
    public void Button1()
    {
        num1++;
        if (num1 > 9)
        {
            num1 = 0;
        }
        bt1.GetComponentInChildren<Text>().text = num1.ToString();
    }
    public void Button2()
    {
        num2++;
        if (num2 > 9)
        {
            num2 = 0;
        }
        bt2.GetComponentInChildren<Text>().text = num2.ToString();
    }
    public void Button3()
    {
        num3++;
        if (num3 > 9)
        {
            num3 = 0;
        }
        bt3.GetComponentInChildren<Text>().text = num3.ToString();
    }
    public void Button4()
    {
        num4++;
        if (num4 > 9)
        {
            num4 = 0;
        }
        bt4.GetComponentInChildren<Text>().text = num4.ToString();
    }
    //解密界面的返回按钮
    public void backGame()
    {
        mimaPanel0.gameObject.SetActive(false);
        StaticClass.isPlayerMove = true;
    }
}
