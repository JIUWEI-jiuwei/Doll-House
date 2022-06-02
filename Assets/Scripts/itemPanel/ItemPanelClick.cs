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
    public static GameObject panelStd;
    public static GameObject blackpanel;
    /// <summary>��ȡ����Ʒ�����ϵĶ���</summary>
    public static itemPanel itemPanel;
    /// <summary>Ԥ���屾��</summary>
    public GameObject itemImage;
    public float timer = 0.2f;

    private void Awake()
    {
        //FindGameObjectWithTag����Ҫactive����������ҵ����������ҵ�����SetActive(false)
        panel = GameObject.FindGameObjectWithTag("panel");
        panel1 = GameObject.FindGameObjectWithTag("panel1");
        panel2 = GameObject.FindGameObjectWithTag("panel2");
        panelStd = GameObject.FindGameObjectWithTag("panelStd");
        blackpanel = GameObject.FindGameObjectWithTag("itemblackpanel").transform.GetChild(0).gameObject;
    }
    private void Start()
    {
        panel2.SetActive(false);
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
    /// <summary>
    /// ��Ʒ����һҳ
    /// </summary>
    public void ItemPanelRight()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    /// <summary>
    /// ��Ʒ����һҳ
    /// </summary>
    public void ItemPanelLeft()
    {
        panel1.SetActive(true);
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
        if (StaticClass.isFinishedMove&&eventData.pointerPress.gameObject.layer==6)//&& StaticClass.isItemClick
        {
            if (eventData.pointerPress.name == "rawmeat")
            {
                if (!ButtonManager.isGetRawMeat) return;
               /* //��ɫ״̬�ı�
                playerAI.player.SetBool("stop", false);
                playerAI.player.SetBool("backidle", false);
                playerAI.player.SetBool("startwalk", true);
                playerAI.player.SetBool("walk", true);
                playerAI.player.SetBool("climb", true);*/

                ButtonDown(eventData);
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

        if (Resources.Load(eventData.pointerPress.gameObject.name) != null)
        {
            //ʵ����resources����ġ�Ԥ���塱��Instantiateʵ�����ı�����Ԥ����
            GameObject a = Instantiate(itemImage);
            a.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(eventData.pointerPress.gameObject.name);
            //�����Ʒ����һҳδ��
            if (panel1.transform.childCount <= 5)
            {
                a.transform.SetParent(panel1.transform);
                a.transform.localScale = new Vector3(1, 1, 1);

            }
            else//�����Ʒ����һҳ����
            {
                a.transform.SetParent(panel2.transform);
                a.transform.localScale = new Vector3(1, 1, 1);
                panel1.SetActive(false);
            }
        }

        StaticClass.isPlayerMove = false;
        StaticClass.isItemClick = false;
    }
}
