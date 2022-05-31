using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using RenderHeads.Media.AVProVideo;

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
    private MediaPlayer _mediaPlayer;
    private MediaPlayer _mediaPlayerB;
    private GameObject _mediaDisplay;
    private GameObject _mediaDisplayB;
    private GameObject player;
    //private Goose s_goose;


    private void Start()
    {
        freePanel = GameObject.FindGameObjectWithTag("freePanel").transform;
        rectTrans = GetComponent<RectTransform>();
        FindGrid();
        //s_goose = GameObject.Find("goose").GetComponent<Goose>();
        player = GameObject.Find("Player");
        itemPanelClick = GameObject.Find("itemPanelClick").GetComponent<ItemPanelClick>();
        videoClips = GameObject.Find("VideoClips").GetComponent<VideoClips>();
        _mediaPlayer = GameObject.Find("MediaPlayer").GetComponent<MediaPlayer>();
        _mediaPlayerB = GameObject.Find("MediaPlayerB").GetComponent<MediaPlayer>();

        _mediaDisplay = GameObject.Find("AVPro VideoF").transform.GetChild(0).gameObject;
        _mediaDisplayB = GameObject.Find("AVPro VideoF").transform.GetChild(1).gameObject;
        

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
            Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
            //出现的问题：会检测到自身物体（尽管勾选了不检测也没用
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
        //结束拖拽之后父物体回归
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
        //将UI词条拖拽到角色身上
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);           
        }

        //判断鼠标拖拽的物体和鼠标松开的物体
        if (this.GetComponent<Image>().sprite.name == "ribbon" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {//丝带+鹅身上
            //将物体隐藏，播放绑嘴视频
            Goose.goose.SetBool("EMouse", true);
            Goose.goose.gameObject.SetActive(false);            
            player.SetActive(false);

            //mov视频实现
            _mediaDisplay.SetActive(true);
            _mediaDisplay.GetComponent<DisplayUGUI>()._mediaPlayer.Play();

            //视频播放完毕，将物体显现
            Invoke("MediaVideoFinished", 2f);
        }
        else if (this.GetComponent<Image>().sprite.name == "xisheng" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {//细绳+鹅
            //如果鹅嘴已被绑
            if (Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("EMouseIdle"))
            {
                //播放绑腿动画
                _mediaDisplayB.SetActive(true);
                _mediaDisplayB.GetComponent<DisplayUGUI>()._mediaPlayer.Play();
                Goose.goose.gameObject.SetActive(false);
                player.SetActive(false);

                //视频播放完毕，将物体显现
                Invoke("MediaVideoFinished2", 2f);
            }

        }
        else
        {
            //物品栏回归并且物品名字出现
            ItemPanelClick.ItemPanelKing();
            itemPanelClick.blackPanelOpen();
            TextShow.text_name.gameObject.SetActive(true);
        }

    }
    /// <summary>
    /// 视频播放完毕，将物体显现
    /// </summary>
    private void MediaVideoFinished()
    {
        Goose.goose.gameObject.SetActive(true);
        Goose.goose.SetBool("EMouse", true);
        player.SetActive(true);
        _mediaDisplay.SetActive(false);
        _mediaDisplayB.SetActive(false);
        ButtonManager. note2.SetActive(true);
    }
    private void MediaVideoFinished2()
    {
        Goose.goose.gameObject.SetActive(true);
        Goose.goose.SetBool("EMouse", true);
        Goose.goose.SetBool("stop", true);
        player.SetActive(true);
        _mediaDisplay.SetActive(false);
        _mediaDisplayB.SetActive(false);
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
    }
}

