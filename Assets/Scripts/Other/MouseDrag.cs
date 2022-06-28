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
    private GameObject paiting;

    public GameObject jitaiItemPrefab;
    public GameObject seedPrefab;
    private GameObject catTextBg;

    private GameObject plate1;
    private GameObject plate2;
    private GameObject plate3;
    private GameObject plate4;
    private Transform jitai;

    private GameObject seed1;
    private GameObject seed2;
    private GameObject seed3;
    private GameObject seed4;
    private Transform seedF;
   // private AudioSource hama;

    private float itemTime = 0;
    private float itemTimer = 0.2f;
    private float itemTime2 = 0;
    private float itemTimer2 = 0.2f;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "DollLayer1")
        {
            paiting = GameObject.Find("nonAnim").transform.GetChild(0).gameObject;
            videoPlayer = GameObject.Find("VideoClips").GetComponent<VideoPlayer>();
            catTextBg = GameObject.Find("cat").transform.GetChild(0).gameObject;
            player = GameObject.Find("Player");
            //dialogPos = player.transform.GetChild(0);
        }
        freePanel = GameObject.FindGameObjectWithTag("freePanel").transform;       
        rectTrans = GetComponent<RectTransform>();
        FindGrid();
        itemPanelClick = GameObject.Find("itemPanelClick").GetComponent<ItemPanelClick>();        

        //存档
        if (SceneManager.GetActiveScene().name == "DollLayer2")
        {
            jitai = GameObject.Find("JiTaiF").transform.GetChild(0);
            plate1 = jitai.GetChild(0).gameObject;
            plate2 = jitai.GetChild(1).gameObject;
            plate3 = jitai.GetChild(2).gameObject;
            plate4 = jitai.GetChild(3).gameObject;
            seedF = GameObject.Find("FlowerF").transform.GetChild(0);
            seed1 = seedF.GetChild(0).gameObject;
            seed2 = seedF.GetChild(1).gameObject;
            seed3 = seedF.GetChild(2).gameObject;
            seed4 = seedF.GetChild(3).gameObject;
            //hama = GameObject.Find("hama").GetComponent<AudioSource>();
            if (PlayerPrefs.GetInt("isGui1") == 1)
            {
                GameObject a = Instantiate(jitaiItemPrefab);
                a.GetComponent<Image>().sprite = Resources.Load<Sprite>("yumao00");
                a.transform.SetParent(plate1.transform);
                a.transform.localScale = new Vector3(1, 1, 1);
                //MouseDragForJiTai.tempTF = eventData.pointerCurrentRaycast.gameObject;
                a.transform.position = plate1.transform.position;
            }
            if(PlayerPrefs.GetInt("isGui2") == 1)
            {
                GameObject a = Instantiate(jitaiItemPrefab);
                a.GetComponent<Image>().sprite = Resources.Load<Sprite>("lung00");
                a.transform.SetParent(plate2.transform);
                a.transform.localScale = new Vector3(1, 1, 1);
                //MouseDragForJiTai.tempTF = eventData.pointerCurrentRaycast.gameObject;
                a.transform.position = plate2.transform.position;
            }
            if(PlayerPrefs.GetInt("isGui3") == 1)
            {
                GameObject a = Instantiate(jitaiItemPrefab);
                a.GetComponent<Image>().sprite = Resources.Load<Sprite>("turtleshell00");
                a.transform.SetParent(plate3.transform);
                a.transform.localScale = new Vector3(1, 1, 1);
                //MouseDragForJiTai.tempTF = eventData.pointerCurrentRaycast.gameObject;
                a.transform.position = plate3.transform.position;
            }
            if(PlayerPrefs.GetInt("isGui4") == 1)
            {
                GameObject a = Instantiate(jitaiItemPrefab);
                a.GetComponent<Image>().sprite = Resources.Load<Sprite>("cattooth00");
                a.transform.SetParent(plate4.transform);
                a.transform.localScale = new Vector3(1, 1, 1);
                //MouseDragForJiTai.tempTF = eventData.pointerCurrentRaycast.gameObject;
                a.transform.position = plate4.transform.position;
            }
            if(PlayerPrefs.GetInt("isSeed1") == 1)
            {
                GameObject s = Instantiate(seedPrefab);
                s.transform.SetParent(seed1.transform);
                s.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                s.transform.position = seed1.transform.GetChild(0).position;
            }
            if(PlayerPrefs.GetInt("isSeed2") == 1)
            {
                GameObject s = Instantiate(seedPrefab);
                s.transform.SetParent(seed2.transform);
                s.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                s.transform.position = seed2.transform.GetChild(0).position;
            }
            if(PlayerPrefs.GetInt("isSeed3") == 1)
            {
                GameObject s = Instantiate(seedPrefab);
                s.transform.SetParent(seed3.transform);
                s.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                s.transform.position = seed3.transform.GetChild(0).position;
            }
            if(PlayerPrefs.GetInt("isSeed4") == 1)
            {
                GameObject s = Instantiate(seedPrefab);
                s.transform.SetParent(seed3.transform);
                s.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                s.transform.position = seed3.transform.GetChild(0).position;
            }
            if (PlayerPrefs.GetInt("isHamaDrinking") == 1)
            {                
                Hama.hama.SetBool("death", true);
                //StaticClass.isHamaDuyao = true;
                PlayerPrefs.SetInt("isHamaDuyao", 1);
            }
            if (PlayerPrefs.GetInt("isHamaDuyao") == 2)
            {                
                Hama.hama.SetBool("sci", true);
            }
            if (PlayerPrefs.GetInt("isHamaDuyao") == 1)
            {                
                Hama.hama.SetBool("death", true);
                Hama.hamaAudio.enabled = false;
                StaticClass.isHamaDialog = true;
                StaticClass.isHamaClick = false;
            }
        }

    }
    private void FixedUpdate()
    {
        if (MouseDragForJiTai.videoPlayer2 != null)
        {
            if (MouseDragForJiTai.videoPlayer2.isPlaying && MouseDragForJiTai.videoPlayer2.clip.name == "剪开蛤蟆肚子")
            {
                if ((int)MouseDragForJiTai.videoPlayer2.frame >= (int)MouseDragForJiTai.videoPlayer2.frameCount - 3)
                {
                    MouseDragForJiTai.videoPlayer2.Stop();
                    AudioManager.audioSource.Play();
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
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            //拖动到左箭头翻页
            if (hit.collider.gameObject.name == "left_item")
            {
                if (PanelManager.itemNum > 0)
                {
                    itemTime += Time.deltaTime;
                    if (itemTime < itemTimer)return;
                    ItemNumMinus();
                    itemTime = 0f;
                }
            }
            //拖动到右箭头翻页
            else if (hit.collider.gameObject.name == "right_item")
            {
                if (PanelManager.itemNum < 2)
                {
                    itemTime2 += Time.deltaTime;
                    if (itemTime2 < itemTimer2) return;
                    ItemNumPlus();
                    itemTime2 = 0f;
                }
            }
            
        }
        
    }

    private static void ItemNumPlus()
    {
        PanelManager.itemNum++;
    }

    private static void ItemNumMinus()
    {
        PanelManager.itemNum--;
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
                Destroy(this.gameObject);
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
                Destroy(this.gameObject);               
            }
            else
            {
                Diaryy.gooseSpeak = true;
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
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("cattuoye");
            catTextBg.GetComponentInChildren<Text>().text = "这块肉倒是不错，再找块更熟点的吧";
            catTextBg.SetActive(true);
            Invoke("CloseCatText", 8f);
        }
        //生肉+猫=》文本
        else if (this.GetComponent<Image>().sprite.name == "rawmeat" && eventData.pointerCurrentRaycast.gameObject.name == "cat")
        {
            catTextBg.GetComponentInChildren<Text>().text = "太生的肉我可不喜欢";
            catTextBg.SetActive(true);
            Invoke("CloseCatText", 3f);
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
            catTextBg.GetComponentInChildren<Text>().text = "我的牙…";
            catTextBg.SetActive(true);
            Invoke("CloseCatText", 8f);
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
        /*//唾液+杯子=》盛唾液的杯子
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
        }*/
        //蜡烛+纸条1
        else if (this.GetComponent<Image>().sprite.name == "candle" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "note4")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            //获得丝带
            ItemPanelClick.ChangeItemPanel("note1_b");
        }
        //蜡烛+纸条1 2
        else if (this.GetComponent<Image>().sprite.name == "note4" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "candle")
        {
            Destroy(this.gameObject);
            //获得丝带
            ItemPanelClick.ChangeItemPanel("note1_b");
        }
        //杯子+水壶=》水杯
        else if (this.GetComponent<Image>().sprite.name == "cup" && eventData.pointerCurrentRaycast.gameObject.name == "bottle")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("shuidebeizi");
        }

        #endregion

        #region 第二关物品拖拽
        //口红+乌龟=》打开panel
        else if (this.GetComponent<Image>().sprite.name == "lip" && eventData.pointerCurrentRaycast.gameObject.name == "gui")
        {
            if(PlayerPrefs.GetInt("isGuiClickNum") >= 2)
            {
                WuGui.wuGuiPanel.SetActive(true);
                WuGui.wuGuiLeft.SetActive(true);
                WuGui.cameraBrush.SetActive(true);
            }
        }
        //种植种子
        else if (this.GetComponent<Image>().sprite.name == "seed" && eventData.pointerCurrentRaycast.gameObject.name == "red")
        {
            PlayerPrefs.SetInt("isSeed1", 1);
            Destroy(this.gameObject);
            GameObject s = Instantiate(seedPrefab);
            s.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            s.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            s.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
            ItemPanelClick.audioSource.Play();
        }
        else if (this.GetComponent<Image>().sprite.name == "seed" && eventData.pointerCurrentRaycast.gameObject.name == "yellow")
        {
            PlayerPrefs.SetInt("isSeed2", 1);
            Destroy(this.gameObject);
            GameObject s = Instantiate(seedPrefab);
            s.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            s.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            s.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
            ItemPanelClick.audioSource.Play();
        }
        else if (this.GetComponent<Image>().sprite.name == "seed" && eventData.pointerCurrentRaycast.gameObject.name == "green")
        {
            PlayerPrefs.SetInt("isSeed3", 1);
            Destroy(this.gameObject);
            GameObject s = Instantiate(seedPrefab);
            s.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            s.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            s.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
            ItemPanelClick.audioSource.Play();
        }
        else if (this.GetComponent<Image>().sprite.name == "seed" && eventData.pointerCurrentRaycast.gameObject.name == "purple")
        {
            PlayerPrefs.SetInt("isSeed4", 1);
            Destroy(this.gameObject);
            GameObject s = Instantiate(seedPrefab);
            s.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            s.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            s.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
            ItemPanelClick.audioSource.Play();
        }
        //烟斗+烟草=》烟
        else if (this.GetComponent<Image>().sprite.name == "yancao" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "yandou")
        {
            Destroy(this.gameObject);
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("yan");
        }
        //烟斗+烟草=》烟
        else if (this.GetComponent<Image>().sprite.name == "yandou" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "yancao")
        {
            Destroy(this.gameObject);
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
            if (PlayerPrefs.GetInt("isHamaDrinking") ==1)
            {
                Destroy(this.gameObject);
                Hama.hama.SetBool("death", true);
                //StaticClass.isHamaDuyao = true;
                PlayerPrefs.SetInt("isHamaDuyao", 1);
            }                   
        }
        //剪刀+蛤蟆=》播放剪肚子视频得到：剪刀静帧+肺  
        else if (this.GetComponent<Image>().sprite.name == "scissor" && eventData.pointerCurrentRaycast.gameObject.name == "hama")
        {
            if (PlayerPrefs.GetInt("isHamaDuyao") == 1)
            {
                MouseDragForJiTai.videoPlayer2.clip = MouseDragForJiTai.videoPlayer2.GetComponent<VideoClips>().videoClips[2];
                MouseDragForJiTai.videoPlayer2.Play();
                AudioManager.audioSource.Stop();
                Hama.hama.SetBool("sci", true);
                ItemPanelClick.ChangeItemPanel("lung");
                Hama.hamaAudio.enabled = false;
                StaticClass.isHamaDialog= true;
                StaticClass.isHamaClick = false;
                PlayerPrefs.SetInt("isHamaDuyao", 2);
            }           
        }
        //水杯+蛤蟆=》播放说话动画+文本框提示抽烟
        else if (this.GetComponent<Image>().sprite.name == "shuidebeizi" && eventData.pointerCurrentRaycast.gameObject.name == "hama")
        {
            Hama.hama.SetBool("hamatalk", true);
            Hama.hamaDialog0.SetActive(true);
            PlayerPrefs.SetInt("isHamaDrinking", 0);
        }
        //烟+蛤蟆=》播放抽烟动画+文本框提示喝水
        else if (this.GetComponent<Image>().sprite.name == "yan" && eventData.pointerCurrentRaycast.gameObject.name == "hama")
        {
            Hama.hama.SetBool("hamasmoke", true);//1.3f
            Invoke("HamaDialog1", 1.2f);
            PlayerPrefs.SetInt("isHamaDrinking", 1);
        }
        //唾液+种子=》浇灌
        else if (this.GetComponent<Image>().sprite.name == "cattuoye" && eventData.pointerCurrentRaycast.gameObject.name == "seed(Clone)")
        {
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Animator>().SetBool("grow", true);
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Seed>().isTuoYe = true;
            ItemPanelClick.audioSource.Play();
            PlayerPrefs.SetInt("isSeed1", 0);
            PlayerPrefs.SetInt("isSeed2", 0);
            PlayerPrefs.SetInt("isSeed3", 0);
            PlayerPrefs.SetInt("isSeed4", 0);
        }
        //盛水的杯子+种子=》浇灌
        else if (this.GetComponent<Image>().sprite.name == "shuidebeizi" && eventData.pointerCurrentRaycast.gameObject.name == "seed(Clone)")
        {
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Animator>().SetBool("grow", true);
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Seed>().isWater= true;
            ItemPanelClick.audioSource.Play();
            PlayerPrefs.SetInt("isSeed1", 0);
            PlayerPrefs.SetInt("isSeed2", 0);
            PlayerPrefs.SetInt("isSeed3", 0);
            PlayerPrefs.SetInt("isSeed4", 0);

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
        else if (this.GetComponent<Image>().sprite.name == "yumao" && eventData.pointerCurrentRaycast.gameObject.name == "plate1")
        {
            //StaticClass.one = true;
            PlayerPrefs.SetInt("isGui1", 1);
            Destroy(this.gameObject);
            GameObject a = Instantiate(jitaiItemPrefab);
            a.GetComponent<Image>().sprite = Resources.Load<Sprite>(this.GetComponent<Image>().sprite.name + "00");
            a.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            a.transform.localScale = new Vector3(1, 1, 1);
            //MouseDragForJiTai.tempTF = eventData.pointerCurrentRaycast.gameObject;
            a.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
            a.GetComponent<DontDestroyOnLoadJT>().enabled = true;
        }
        else if(this.GetComponent<Image>().sprite.name == "lung" && eventData.pointerCurrentRaycast.gameObject.name == "plate2")
        {
            //StaticClass.one = true;
            PlayerPrefs.SetInt("isGui2", 1);
            Destroy(this.gameObject);
            GameObject a = Instantiate(jitaiItemPrefab);
            a.GetComponent<Image>().sprite = Resources.Load<Sprite>(this.GetComponent<Image>().sprite.name + "00");
            a.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            a.transform.localScale = new Vector3(1, 1, 1);
            //MouseDragForJiTai.tempTF = eventData.pointerCurrentRaycast.gameObject;
            a.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        }
        else if(this.GetComponent<Image>().sprite.name == "turtleshell" && eventData.pointerCurrentRaycast.gameObject.name == "plate3")
        {
            //StaticClass.one = true;
            PlayerPrefs.SetInt("isGui3", 1);
            Destroy(this.gameObject);
            GameObject a = Instantiate(jitaiItemPrefab);
            a.GetComponent<Image>().sprite = Resources.Load<Sprite>(this.GetComponent<Image>().sprite.name + "00");
            a.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            a.transform.localScale = new Vector3(1, 1, 1);
            //MouseDragForJiTai.tempTF = eventData.pointerCurrentRaycast.gameObject;
            a.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        }
        else if(this.GetComponent<Image>().sprite.name == "cattooth" && eventData.pointerCurrentRaycast.gameObject.name == "plate4")
        {
            //StaticClass.one = true;
            PlayerPrefs.SetInt("isGui4", 1);
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
            ItemPanelClick.audioSource2.Play();
        }
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
        else if(ItemPanelClick.panel2.transform.childCount <= 5)
        {
            this.transform.SetParent(ItemPanelClick.panel2.transform);
        }
        else
        {
            this.transform.SetParent(ItemPanelClick.panel3.transform);
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
    public void CloseCatText()
    {
        catTextBg.SetActive(false);
    }
}

