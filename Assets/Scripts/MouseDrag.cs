using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    private GameObject player;
    public GameObject dialogPrefab;
    public GameObject itemImage;
    public float timer = 0f;
    public float resTime = 2f;
    private GameObject dialog;
    private Transform dialogPos;
    private GameObject paiting;

    private void Start()
    {
        freePanel = GameObject.FindGameObjectWithTag("freePanel").transform;
        paiting = GameObject.Find("nonAnim").transform.GetChild(0).gameObject;
        rectTrans = GetComponent<RectTransform>();
        FindGrid();
        player = GameObject.Find("Player");
        itemPanelClick = GameObject.Find("itemPanelClick").GetComponent<ItemPanelClick>();
        videoClips = GameObject.Find("VideoClips").GetComponent<VideoClips>();
        dialogPos = player.transform.GetChild(0);
    }
    private void FixedUpdate()
    {
        if (dialog != null)
        {
            dialog.transform.position = dialogPos.position;
        }
        if (StaticClass.isMoveTarget==2)
        {
            Goose.goose.SetBool("closemouth", true);
            player.SetActive(false);
            //视频播放完毕，将物体显现
            Invoke("MediaVideoFinished", 8f);
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
        TextShow.child0.gameObject.SetActive(false);
        TextShow.text_name.gameObject.SetActive(false);

        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
            //出现的问题：会检测到自身物体（尽管勾选了不检测也没用
            //将物品拖拽到物品栏之外，物品栏才会降下去
            if (eventData.pointerCurrentRaycast.gameObject.name == "blackPanel")
            {
                ItemPanelClick.ItemPanelDown();
                itemPanelClick.blackPanelClose();
            }
        }
        //

    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        BackToItemPanel();
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;

        TextShow.text_name.gameObject.SetActive(true);
        //判断鼠标拖拽的物体和鼠标松开的物体
        if (this.GetComponent<Image>().sprite.name == "ribbon" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {//丝带+鹅身上
            //播放绑嘴动画
            StaticClass.isMoveTarget = 1;
            Destroy(this.gameObject);
            
            
        }
        else if (this.GetComponent<Image>().sprite.name == "xisheng" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {//细绳+鹅
            //如果鹅嘴已被绑
            if (Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("Mouseidle"))
            {
                //播放绑腿动画                
                Goose.goose.SetBool("closelegs", true);
                player.SetActive(false);

                //视频播放完毕，将物体显现
                Invoke("MediaVideoFinished2", 8f);
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
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("meatshu");
        }
        //蜡烛+生肉=》熟肉2 
        else if (this.GetComponent<Image>().sprite.name == "rawmeat" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "candle")
        {
            Destroy(this.gameObject);
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
    private void MediaVideoFinished()
    {
        player.SetActive(true);
        paiting.SetActive(true);
        ButtonManager.note2.SetActive(true);
    }
    private void MediaVideoFinished2()
    {
        player.SetActive(true);

        ButtonManager.yumao.SetActive(true);
    }

    /// <summary>
    /// 将物品位置与物品栏位置相匹配
    /// </summary>
    public void FindGrid()
    {
        for (int i = 0; i < ItemPanelClick.panel1.transform.childCount; i++)
        {
            ItemPanelClick.panel1.transform.GetChild(i).position = ItemPanelClick.panelStd.transform.GetChild(i).position;
        }
        for (int i = 0; i < ItemPanelClick.panel2.transform.childCount; i++)
        {
            ItemPanelClick.panel2.transform.GetChild(i).position = ItemPanelClick.panelStd.transform.GetChild(i).position;
        }
        for (int i = 0; i < ItemPanelClick.panel3.transform.childCount; i++)
        {
            ItemPanelClick.panel3.transform.GetChild(i).position = ItemPanelClick.panelStd.transform.GetChild(i).position;
        }

    }
}

