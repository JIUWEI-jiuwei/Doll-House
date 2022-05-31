using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using RenderHeads.Media.AVProVideo;

/// <summary>
/// �����ק��Ʒ������Ʒ
/// </summary>
class MouseDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    /// <summary>ͼ��λ��</summary>
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
    /// ��ʼ��ק
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //���������קʱ�������ƶ����µ����ƫ������
        this.transform.SetParent(freePanel);
    }
    /// <summary>
    /// ������ק
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        //���λ���ƶ�+�������ƫ��
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.name == "Canvas")
            {
                rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
                this.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
        //��Ʒ���½�+��Ʒ������ʧ+��Ʒ������ʧ
        TextShow.child0.gameObject.SetActive(false);
        TextShow.text_name.gameObject.SetActive(false);

        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
            //���ֵ����⣺���⵽�������壨���ܹ�ѡ�˲����Ҳû��
            if (eventData.pointerCurrentRaycast.gameObject.name == "blackPanel")
            {
                ItemPanelClick.ItemPanelDown();
                itemPanelClick.blackPanelClose();
            }
        }
        
        

        //
        
    }
    /// <summary>
    /// ��ק����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        //������ק֮������ع�
        if (ItemPanelClick.panel1.transform.childCount <= 5)
        {
            this.transform.SetParent(ItemPanelClick.panel1.transform);
        }
        else
        {
            this.transform.SetParent(ItemPanelClick.panel2.transform);
        }
        

        //��δʹ�ã���ص����λ��
        if (rectTrans != null)
        {
            FindGrid();
        }
        //��UI������ק����ɫ����
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);           
        }

        //�ж������ק�����������ɿ�������
        if (this.GetComponent<Image>().sprite.name == "ribbon" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {//˿��+������
            //���������أ����Ű�����Ƶ
            Goose.goose.SetBool("EMouse", true);
            Goose.goose.gameObject.SetActive(false);            
            player.SetActive(false);

            //mov��Ƶʵ��
            _mediaDisplay.SetActive(true);
            _mediaDisplay.GetComponent<DisplayUGUI>()._mediaPlayer.Play();

            //��Ƶ������ϣ�����������
            Invoke("MediaVideoFinished", 2f);
        }
        else if (this.GetComponent<Image>().sprite.name == "xisheng" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {//ϸ��+��
            //��������ѱ���
            if (Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("EMouseIdle"))
            {
                //���Ű��ȶ���
                _mediaDisplayB.SetActive(true);
                _mediaDisplayB.GetComponent<DisplayUGUI>()._mediaPlayer.Play();
                Goose.goose.gameObject.SetActive(false);
                player.SetActive(false);

                //��Ƶ������ϣ�����������
                Invoke("MediaVideoFinished2", 2f);
            }

        }
        else
        {
            //��Ʒ���ع鲢����Ʒ���ֳ���
            ItemPanelClick.ItemPanelKing();
            itemPanelClick.blackPanelOpen();
            TextShow.text_name.gameObject.SetActive(true);
        }

    }
    /// <summary>
    /// ��Ƶ������ϣ�����������
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
    /// ����Ʒλ������Ʒ��λ����ƥ��
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

