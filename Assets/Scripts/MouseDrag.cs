using UnityEngine.Video;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
/// <summary>
/// �����ק��Ʒ������Ʒ
/// </summary>
class MouseDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    /// <summary>ͼ��λ��</summary>
    private RectTransform rectTrans;
    private Transform freePanel;
    private Animator goose;
    private ItemPanelClick itemPanelClick;
    private VideoClips videoClips;

    private void Start()
    {
        freePanel = GameObject.FindGameObjectWithTag("freePanel").transform;
        rectTrans = GetComponent<RectTransform>();
        FindGrid();
        goose = GameObject.Find("goose").GetComponent<Animator>();
        itemPanelClick = GameObject.Find("itemPanelClick").GetComponent<ItemPanelClick>();
        videoClips = GameObject.Find("VideoClips").GetComponent<VideoClips>();
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
            goose.SetBool("EMouse",true);
            //mov��ƵҪ����һ����Ƶ��ʽʵ��
            videoClips.videoPlayer.clip = videoClips.videoClips[0];
            videoClips.videoPlayer.Play();
        }
        else if (this.GetComponent<Image>().sprite.name == "xisheng" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {//ϸ��+��
            //
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

