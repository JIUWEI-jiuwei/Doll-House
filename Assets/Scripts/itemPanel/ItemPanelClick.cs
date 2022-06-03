using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

///<summary>
///��Ʒ���������
///</summary>
class ItemPanelClick : MonoBehaviour, IPointerClickHandler
{
    /// <summary>��Ʒ���е�panel���</summary>
    public static GameObject panel;
    public static GameObject panel1;
    public static GameObject panel2;
    public static GameObject panel3;
    

    public static GameObject panelStd;
    public static GameObject blackpanel;
    /// <summary>��ȡ����Ʒ�����ϵĶ���</summary>
    public static itemPanel itemPanel;
    /// <summary>Ԥ���屾��</summary>
    public GameObject itemImage;
    public static GameObject s_item;
    public float timer = 0.2f;

    private void Awake()
    {
        //FindGameObjectWithTag����Ҫactive����������ҵ����������ҵ�����SetActive(false)
        panel = GameObject.FindGameObjectWithTag("panel");
        panel1 = GameObject.FindGameObjectWithTag("panel1");
        panel2 = GameObject.FindGameObjectWithTag("panel2");
        panel3 = GameObject.FindGameObjectWithTag("panel3");

        panelStd = GameObject.FindGameObjectWithTag("panelStd");
        blackpanel = GameObject.FindGameObjectWithTag("itemblackpanel").transform.GetChild(0).gameObject;
        s_item = itemImage;
    }
    private void Start()
    {
        panel2.SetActive(false);
        panel3.SetActive(false);
        itemPanel = panel.GetComponent<itemPanel>();
        blackpanel.SetActive(false);
    }
    /// <summary>
    /// ��Ʒ���½�����
    /// </summary>
    public static void ItemPanelDown()
    {
        itemPanel.itemPanelAnim.SetBool("up", false);
        StaticClass.isPlayerMove = true;
    }
    /// <summary>
    /// ��Ʒ����������
    /// </summary>
    public static void ItemPanelKing()
    {
        itemPanel.itemPanelAnim.SetBool("up", true);
        StaticClass.isPlayerMove = false;
    }
    
    public void CloseAllPanels(int num)
    {
        panel1.SetActive(false);
        panel3.SetActive(false);
        panel2.SetActive(false);

    }
    public void blackPanelOpen()
    {
        blackpanel.SetActive(true);
    }
    public void blackPanelClose()
    {
        blackpanel.SetActive(false);
    }
    public void Invokeblopen()
    {
        Invoke("blackPanelOpen", timer);
    }
    public void Invokebjclose()
    {
        Invoke("blackPanelClose", timer);
    }

    /// <summary>
    /// ���������ť����Ҫ�����ڰ�ť����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {       
        if (StaticClass.isFinishedMove&&eventData.pointerPress.gameObject.layer==6)
        {
            if (eventData.pointerPress.name == "rawmeat")
            {
                if (ButtonManager.isGetRawMeat)
                {
                    ButtonDown(eventData);
                }               
            }
            else
            {
                ButtonDown(eventData);
            }
        }
    }
    /// <summary>
    /// ������Ʒ����Ʒ
    /// </summary>
    /// <param name="eventData"></param>
    private void ButtonDown(PointerEventData eventData)
    {
        Destroy(eventData.pointerPress.gameObject);
        itemPanel.itemPanelAnim.SetBool("up", true);
        blackPanelOpen();

        ChangeItemPanel(eventData.pointerPress.gameObject.name);

        StaticClass.isPlayerMove = false;
        StaticClass.isItemClick = false;
    }
    /// <summary>
    /// �л���Ʒ����panel
    /// </summary>
    /// <param name="name"></param>
    public static void ChangeItemPanel(string name)
    {
        if (Resources.Load(name) != null)
        {
            //ʵ����resources����ġ�Ԥ���塱��Instantiateʵ�����ı�����Ԥ����
            GameObject a = Instantiate(s_item);
            a.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(name);
            //�����Ʒ����һҳδ��
            if (panel1.transform.childCount <= 5)
            {
                a.transform.SetParent(panel1.transform);
                a.transform.localScale = new Vector3(1, 1, 1);

            }
            else if (panel2.transform.childCount <= 5)
            {
                a.transform.SetParent(panel2.transform);
                a.transform.localScale = new Vector3(1, 1, 1);
                panel1.SetActive(false);
                panel3.SetActive(false);
                panel2.SetActive(true);

            }
            else//�����Ʒ����һҳ����
            {
                a.transform.SetParent(panel3.transform);
                a.transform.localScale = new Vector3(1, 1, 1);
                panel1.SetActive(false);
                panel2.SetActive(false);
                panel3.SetActive(true);
            }
        }
    }
}
