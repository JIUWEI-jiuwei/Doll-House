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
            //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
            //���ֵ����⣺���⵽�������壨���ܹ�ѡ�˲����Ҳû��
            //����Ʒ��ק����Ʒ��֮�⣬��Ʒ���Żή��ȥ
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
        BackToItemPanel();
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //���߼��
        /*RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }*/

        TextShow.text_name.gameObject.SetActive(true);
        //�ж������ק�����������ɿ�������
        if (this.GetComponent<Image>().sprite.name == "ribbon" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {//˿��+������
            //���Ű��춯��
            player.SetActive(false);
            paiting.SetActive(false);
            Goose.goose.SetBool("closemouth", true);
                                  
            //��Ƶ������ϣ�����������
            Invoke("MediaVideoFinished", 8f);
        }
        else if (this.GetComponent<Image>().sprite.name == "xisheng" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {//ϸ��+��
            //��������ѱ���
            if (Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("Mouseidle"))
            {
                //���Ű��ȶ���                
                Goose.goose.SetBool("closelegs", true);
                player.SetActive(false);

                //��Ƶ������ϣ�����������
                Invoke("MediaVideoFinished2", 6.5f);
            }
            else
            {
                foreach (Canvas canvas in FindObjectsOfType<Canvas>())
                {
                    if (canvas.name == "OtherCanvas")
                    {
                        dialog = Instantiate(dialogPrefab, canvas.transform);
                        dialog.transform.GetChild(0).GetComponent<Text>().text = "�����̫ϸ�ˣ����Ҹ���̵Ķ�����";
                        Invoke("DestroyDialog", 2f);                        
                    }
                }
                
            }
        }
        //����+����=������
        else if (this.GetComponent<Image>().sprite.name == "candle"&& eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "rawmeat")
        {            
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            CreateNewItem("meatshu");
        }
        //����+����=������2 
        else if (this.GetComponent<Image>().sprite.name == "rawmeat" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "candle")
        {           
            Destroy(this.gameObject);
            CreateNewItem("meatshu");
        }
        //����+è=����Һ
        else if (this.GetComponent<Image>().sprite.name == "meatshu" && eventData.pointerCurrentRaycast.gameObject.name == "cat")
        {            
            CreateNewItem("cattuoye");
        }
        //����+è=����Һ2
        else if (this.GetComponent<Image>().sprite.name == "cat" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "meatshu")
        {            
            CreateNewItem("cattuoye");
        }
        //����+����=���ս�����
        else if (this.GetComponent<Image>().sprite.name == "candle"&& eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "meatshu")
        {            
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            CreateNewItem("boiledmeat");
        }
        //����+����=���ս�����2
        else if (this.GetComponent<Image>().sprite.name == "meatshu" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "candle")
        {            
            Destroy(this.gameObject);
            CreateNewItem("boiledmeat");
        }
        //�ս�����+è=>�ϳ�
        else if (this.GetComponent<Image>().sprite.name == "boiledmeat" && eventData.pointerCurrentRaycast.gameObject.name == "cat")
        { 
            Destroy(this.gameObject);
            CreateNewItem("cattooth");
        }
        //�ս�����+è=>�ϳ�2
        else if (this.GetComponent<Image>().sprite.name == "cat" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "boiledmeat")
        { 
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            CreateNewItem("cattooth");
        }
        //����+����=��ϸ��
        else if (this.GetComponent<Image>().sprite.name == "necklace" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "scissor")
        { 
            Destroy(this.gameObject);
            CreateNewItem("xisheng");
        }
        //����+����=��ϸ��2
        else if (this.GetComponent<Image>().sprite.name == "scissor" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "necklace")
        { 
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            CreateNewItem("xisheng");
        }
        //��Һ+����=��ʢ��Һ�ı���
        else if (this.GetComponent<Image>().sprite.name == "cattuoye" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "cup")
        { 
            Destroy(this.gameObject);
            CreateNewItem("xisheng");
        }
        //��Һ+����=��ʢ��Һ�ı���2
        else if (this.GetComponent<Image>().sprite.name == "cup" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "cattuoye")
        { 
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            CreateNewItem("xisheng");
        }

        else
        {
            //��Ʒ���ع鲢����Ʒ���ֳ���
            ItemPanelClick.ItemPanelKing();
            itemPanelClick.blackPanelOpen();
            
        }
    }
    /// <summary>
    /// �����µ�����
    /// </summary>
    private void CreateNewItem(string itemName)
    {
        GameObject a = Instantiate(itemImage);
        a.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(itemName);
        //�����Ʒ����һҳδ��
        if (ItemPanelClick.panel1.transform.childCount <= 5)
        {
            a.transform.SetParent(ItemPanelClick.panel1.transform);
            a.transform.localScale = new Vector3(1, 1, 1);

        }
        else//�����Ʒ����һҳ����
        {
            a.transform.SetParent(ItemPanelClick.panel2.transform);
            a.transform.localScale = new Vector3(1, 1, 1);
            ItemPanelClick.panel1.SetActive(false);
            ItemPanelClick.panel2.SetActive(true);
        }
    }

    private void DestroyDialog()
    {
        Destroy(dialog);
    }

    /// <summary>
    /// ������ק֮����Ʒ�ص���Ʒ����panel����
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
        //��δʹ�ã���ص����λ��
        if (rectTrans != null)
        {
            FindGrid();
        }
    }

    /// <summary>
    /// ��Ƶ������ϣ�����������
    /// </summary>
    private void MediaVideoFinished()
    {
        player.SetActive(true);
        paiting.SetActive(true);
        ButtonManager. note2.SetActive(true);
    }
    private void MediaVideoFinished2()
    {
        player.SetActive(true);
        
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

