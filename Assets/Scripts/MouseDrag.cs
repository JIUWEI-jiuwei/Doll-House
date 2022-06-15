using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

/// <summary>
/// 鼠标拖拽物品栏的物品
/// </summary>
class MouseDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    /// <summary>图像位置</summary>
    private RectTransform rectTrans;
    private Transform freePanel;
    private ItemPanelClick itemPanelClick;
    private VideoClips videoClips;
    public static VideoPlayer videoPlayer;

    private GameObject player;
    public GameObject dialogPrefab;
    public GameObject itemImage;
    public float timer = 0f;
    public float resTime = 2f;
    private GameObject dialog;
    private Transform dialogPos;
    private GameObject paiting;

    public GameObject jitaiItemPrefab;
    public GameObject seedPrefab;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "DollLayer1")
        {
            paiting = GameObject.Find("nonAnim").transform.GetChild(0).gameObject;
            videoPlayer = GameObject.Find("VideoClips").GetComponent<VideoPlayer>();
        }
        freePanel = GameObject.FindGameObjectWithTag("freePanel").transform;       
        rectTrans = GetComponent<RectTransform>();
        FindGrid();
        player = GameObject.Find("Player");
        itemPanelClick = GameObject.Find("itemPanelClick").GetComponent<ItemPanelClick>();        
        if (player != null)
        {
            dialogPos = player.transform.GetChild(0);
        }
    }
    private void FixedUpdate()
    {
        if (dialog != null&&dialogPos!=null)
        {
            dialog.transform.position = dialogPos.position;
        }
        if (MouseDragForJiTai.videoPlayer2 != null)
        {
            if (MouseDragForJiTai.videoPlayer2.isPlaying && MouseDragForJiTai.videoPlayer2.clip.name == "剪开蛤蟆肚子")
            {
                if ((int)MouseDragForJiTai.videoPlayer2.frame >= (int)MouseDragForJiTai.videoPlayer2.frameCount - 3)
                {
                    MouseDragForJiTai.videoPlayer2.Stop();
                }
            }
        }        
    }
    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //解决物体拖拽时父物体移动导致的鼠标偏移问题
        this.transform.SetParent(freePanel);
    }
    /// <summary>
    /// 正在拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        //鼠标位置移动+矫正鼠标偏移
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.name == "Canvas")
            {
                rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
                this.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
        //物品栏下降+物品名字消失+物品介绍消失
        if (TextShow.child0 != null)
        {
            TextShow.child0.gameObject.SetActive(false);
            TextShow.text_name.gameObject.SetActive(false);
        }        
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
            //出现的问题：会检测到自身物体（尽管勾选了不检测也没用
            //将物品拖拽到物品栏之外，物品栏才会降下去
            if (eventData.pointerCurrentRaycast.gameObject.name == "blackPanel")
            {
                ItemPanelClick.ItemPanelDown();
                ItemPanelClick.blackPanelClose();
            }
        }
    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        BackToItemPanel();
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (TextShow.text_name != null)
        {
            TextShow.text_name.gameObject.SetActive(true);
        }

        #region 第一关的物品拖拽
        //判断鼠标拖拽的物体和鼠标松开的物体
        //丝带+鹅身上
        if (this.GetComponent<Image>().sprite.name == "ribbon" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {           
            if (PlayerPrefs.GetInt("isGoose1") == 0)
            {
                //控制变量=1，角色移动
                StaticClass.isMoveTarget = 1;
            }                                   
        }
        //细绳+鹅
        else if (this.GetComponent<Image>().sprite.name == "xisheng" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {
            //如果鹅嘴已被绑,绑腿
            if (PlayerPrefs.GetInt("isGoose1") == 1)//Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("Mouseidle")
            {
                //控制变量=1，角色移动
                StaticClass.isMoveTarget2 = 1;
                //Destroy(this.gameObject);               
            }
            else
            {
                foreach (Canvas canvas in FindObjectsOfType<Canvas>())
                {
                    if (canvas.name == "OtherCanvas")
                    {
                        dialog = Instantiate(dialogPrefab, canvas.transform);
                        dialog.transform.GetChild(0).GetComponent<Text>().text = "这根绳太细了，得找更坚固的东西。";
                        Invoke("DestroyDialog", 2f);
                    }
                }

            }
        }
        //蜡烛+生肉=》熟肉
        else if (this.GetComponent<Image>().sprite.name == "candle" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "rawmeat")
        {
            //Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("meatshu");
        }
        //蜡烛+生肉=》熟肉2 
        else if (this.GetComponent<Image>().sprite.name == "rawmeat" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "candle")
        {
            //Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("meatshu");
        }
        //熟肉+猫=》唾液
        else if (this.GetComponent<Image>().sprite.name == "meatshu" && eventData.pointerCurrentRaycast.gameObject.name == "cat")
        {
            ItemPanelClick.ChangeItemPanel("cattuoye");
        }
        //熟肉+猫=》唾液2
        else if (this.GetComponent<Image>().sprite.name == "cat" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "meatshu")
        {
            ItemPanelClick.ChangeItemPanel("cattuoye");
        }
        //蜡烛+熟肉=》烧焦的肉
        else if (this.GetComponent<Image>().sprite.name == "candle" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "meatshu")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("boiledmeat");
        }
        //蜡烛+熟肉=》烧焦的肉2
        else if (this.GetComponent<Image>().sprite.name == "meatshu" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "candle")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("boiledmeat");
        }
        //烧焦的肉+猫=>断齿
        else if (this.GetComponent<Image>().sprite.name == "boiledmeat" && eventData.pointerCurrentRaycast.gameObject.name == "cat")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("cattooth");
        }
        //烧焦的肉+猫=>断齿2
        else if (this.GetComponent<Image>().sprite.name == "cat" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "boiledmeat")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("cattooth");
        }
        //项链+剪刀=》细绳
        else if (this.GetComponent<Image>().sprite.name == "necklace" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "scissor")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("xisheng");

        }
        //项链+剪刀=》细绳2
        else if (this.GetComponent<Image>().sprite.name == "scissor" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "necklace")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("xisheng");
        }
        //唾液+杯子=》盛唾液的杯子
        else if (this.GetComponent<Image>().sprite.name == "cattuoye" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "cup")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("tuoyedebeizi");
        }
        //唾液+杯子=》盛唾液的杯子2
        else if (this.GetComponent<Image>().sprite.name == "cup" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "cattuoye")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("tuoyedebeizi");
        }
        //蜡烛+纸条1
        else if (this.GetComponent<Image>().sprite.name == "candle" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "note1")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            //获得丝带
            ItemPanelClick.ChangeItemPanel("note1_b");
        }
        //蜡烛+纸条1 2
        else if (this.GetComponent<Image>().sprite.name == "note1" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "candle")
        {
            Destroy(this.gameObject);
            //获得丝带
            ItemPanelClick.ChangeItemPanel("note1_b");
        }
        //杯子+水壶=》水杯
        else if (this.GetComponent<Image>().sprite.name == "cup" && eventData.pointerCurrentRaycast.gameObject.name == "bottle")
        {
            ItemPanelClick.ChangeItemPanel("shuidebeizi");
        }

        #endregion

        #region 第二关物品拖拽
        //口红+乌龟=》打开panel
        else if (this.GetComponent<Image>().sprite.name == "lip" && eventData.pointerCurrentRaycast.gameObject.name == "gui")
        {
            WuGui.wuGuiPanel.SetActive(true);
        }
        //种植种子
        else if (this.GetComponent<Image>().sprite.name == "seed" && eventData.pointerCurrentRaycast.gameObject.name == "red")
        {
            Destroy(this.gameObject);
            GameObject s = Instantiate(seedPrefab);
            s.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            s.transform.localScale = new Vector3(1, 1, 1);
            s.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
        }
        else if (this.GetComponent<Image>().sprite.name == "seed" && eventData.pointerCurrentRaycast.gameObject.name == "yellow")
        {
            Destroy(this.gameObject);
            GameObject s = Instantiate(seedPrefab);
            s.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            s.transform.localScale = new Vector3(1, 1, 1);
            s.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
        }
        else if (this.GetComponent<Image>().sprite.name == "seed" && eventData.pointerCurrentRaycast.gameObject.name == "green")
        {
            Destroy(this.gameObject);
            GameObject s = Instantiate(seedPrefab);
            s.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            s.transform.localScale = new Vector3(1, 1, 1);
            s.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
        }
        else if (this.GetComponent<Image>().sprite.name == "seed" && eventData.pointerCurrentRaycast.gameObject.name == "purple")
        {
            Destroy(this.gameObject);
            GameObject s = Instantiate(seedPrefab);
            s.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            s.transform.localScale = new Vector3(1, 1, 1);
            s.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
        }
        //烟斗+烟草=》烟
        else if (this.GetComponent<Image>().sprite.name == "yancao" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "yandou")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("yan");
        }
        //烟斗+烟草=》烟
        else if (this.GetComponent<Image>().sprite.name == "yandou" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "yancao")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("yan");
        }
         //毒草+水杯=》毒药
        else if (this.GetComponent<Image>().sprite.name == "ducao" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "shuidebeizi")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("duyao");
        }
        //毒草+水杯=》毒药
        else if (this.GetComponent<Image>().sprite.name == "shuidebeizi" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "ducao")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("duyao");
        }
        //毒药+蛤蟆=》死亡静帧
        else if (this.GetComponent<Image>().sprite.name == "duyao" && eventData.pointerCurrentRaycast.gameObject.name == "hama")
        {
            if (StaticClass.isHamaDrinking)
            {             
                Hama.hama.SetBool("death", true);
                StaticClass.isHamaDuyao = true;
            }                   
        }
        //剪刀+蛤蟆=》播放剪肚子视频得到：剪刀静帧+肺  
        else if (this.GetComponent<Image>().sprite.name == "scissor" && eventData.pointerCurrentRaycast.gameObject.name == "hama")
        {
            if (StaticClass.isHamaDuyao)
            {
                MouseDragForJiTai.videoPlayer2.clip = MouseDragForJiTai.videoPlayer2.GetComponent<VideoClips>().videoClips[2];
                MouseDragForJiTai.videoPlayer2.Play();
                Hama.hama.SetBool("sci", true);
                ItemPanelClick.ChangeItemPanel("lung");
            }           
        }
        //水杯+蛤蟆=》播放说话动画+文本框提示抽烟
        else if (this.GetComponent<Image>().sprite.name == "shuidebeizi" && eventData.pointerCurrentRaycast.gameObject.name == "hama")
        {
            Hama.hama.SetBool("hamatalk", true);
            Hama.hamaDialog0.SetActive(true);
            StaticClass.isHamaDrinking = false;
        }
        //烟+蛤蟆=》播放抽烟动画+文本框提示喝水
        else if (this.GetComponent<Image>().sprite.name == "yan" && eventData.pointerCurrentRaycast.gameObject.name == "hama")
        {
            Hama.hama.SetBool("hamasmoke", true);//1.3f
            Invoke("HamaDialog1", 1.2f);
            StaticClass.isHamaDrinking = true;
        }
        //盛唾液的杯子+种子=》浇灌
        else if (this.GetComponent<Image>().sprite.name == "tuoyedebeizi" && eventData.pointerCurrentRaycast.gameObject.name == "seed(Clone)")
        {
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Animator>().SetBool("grow", true);
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Seed>().isTuoYe = true;
        }
        //盛水的杯子+种子=》浇灌
        else if (this.GetComponent<Image>().sprite.name == "shuidebeizi" && eventData.pointerCurrentRaycast.gameObject.name == "seed(Clone)")
        {
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Animator>().SetBool("grow", true);
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Seed>().isWater= true;
        }
        //烟草+烟斗=》烟
        else if (this.GetComponent<Image>().sprite.name == "yancao" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "yandou")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("yan");
        }
        //烟草+烟斗=》烟
        else if (this.GetComponent<Image>().sprite.name == "yandou" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "yancao")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("yan");
        }



        //祭台：乌龟的壳+盘子1=》吸附
        else if ((this.GetComponent<Image>().sprite.name == "turtleshell"|| this.GetComponent<Image>().sprite.name == "cattooth"||
            this.GetComponent<Image>().sprite.name == "lung" || this.GetComponent<Image>().sprite.name == "yumao") && 
            (eventData.pointerCurrentRaycast.gameObject.name == "plate1"||eventData.pointerCurrentRaycast.gameObject.name == "plate2"||
            eventData.pointerCurrentRaycast.gameObject.name == "plate3" || eventData.pointerCurrentRaycast.gameObject.name == "plate4"))
        {
            if (this.GetComponent<Image>().sprite.name == "yumao" && eventData.pointerCurrentRaycast.gameObject.name == "plate1")
            {
                //StaticClass.one = true;
                PlayerPrefs.SetInt("isGui1", 1);
            }
            else if (this.GetComponent<Image>().sprite.name == "lung" && eventData.pointerCurrentRaycast.gameObject.name == "plate2")
            {
                //StaticClass.two = true;
                PlayerPrefs.SetInt("isGui2", 1);
            }
            else if (this.GetComponent<Image>().sprite.name == "turtleshell" && eventData.pointerCurrentRaycast.gameObject.name == "plate3")
            {
                //StaticClass.three = true;
                PlayerPrefs.SetInt("isGui3", 1);
            }
            else if (this.GetComponent<Image>().sprite.name == "cattooth" && eventData.pointerCurrentRaycast.gameObject.name == "plate4")
            {
                //StaticClass.four = true;
                PlayerPrefs.SetInt("isGui4", 1);
            }
            Destroy(this.gameObject);
            GameObject a = Instantiate(jitaiItemPrefab);
            a.GetComponent<Image>().sprite = Resources.Load<Sprite>(this.GetComponent<Image>().sprite.name + "00");
            a.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            a.transform.localScale = new Vector3(1, 1, 1);
            //MouseDragForJiTai.tempTF = eventData.pointerCurrentRaycast.gameObject;
            a.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        }



        #endregion
        else
        {
            //物品栏回归并且物品名字出现
            ItemPanelClick.ItemPanelKing();
            ItemPanelClick.blackPanelOpen();
        }
    }

    private void DestroyDialog()
    {
        Destroy(dialog);
    }

    /// <summary>
    /// 结束拖拽之后物品回到物品栏的panel里面
    /// </summary>
    private void BackToItemPanel()
    {
        if (ItemPanelClick.panel1.transform.childCount <= 5)
        {
            this.transform.SetParent(ItemPanelClick.panel1.transform);
        }
        else
        {
            this.transform.SetParent(ItemPanelClick.panel2.transform);
        }
        //若未使用，则回到最初位置
        if (rectTrans != null)
        {
            FindGrid();
        }
    }

    /// <summary>
    /// 视频播放完毕，将物体显现
    /// </summary>
    /*private void MediaVideoFinished()
    {
        player.SetActive(true);
        paiting.SetActive(true);
        ButtonManager.note2.SetActive(true);
    }
    private void MediaVideoFinished2()
    {
        player.SetActive(true);

        ButtonManager.yumao.SetActive(true);
    }*/

    /// <summary>
    /// 将物品位置与物品栏位置相匹配
    /// </summary>
    public void FindGrid()
    {
        for (int i = 0; i < ItemPanelClick.panel1.transform.childCount; i++)
        {
            ItemPanelClick.panel1.transform.GetChild(i).position = ItemPanelClick.panelStd.transform.GetChild(i).position;
        }
        if (ItemPanelClick.panel2 != null)
        {
            for (int i = 0; i < ItemPanelClick.panel2.transform.childCount; i++)
            {
                ItemPanelClick.panel2.transform.GetChild(i).position = ItemPanelClick.panelStd.transform.GetChild(i).position;
            }
        }
        if(ItemPanelClick.panel3 != null)
        {
            for (int i = 0; i < ItemPanelClick.panel3.transform.childCount; i++)
            {
                ItemPanelClick.panel3.transform.GetChild(i).position = ItemPanelClick.panelStd.transform.GetChild(i).position;
            }
        }        
    }
    public void HamaDialog1()
    {
        Hama.hamaDialog1.SetActive(true);
        Hama.hama.SetBool("hamasmoke", false);
    }
}

