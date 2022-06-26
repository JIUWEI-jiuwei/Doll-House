using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
    private GameObject rayitem;
    public static int numDown=0;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name!= "StartGame")
        {
            blackpanel = GameObject.FindGameObjectWithTag("itemblackpanel").transform.GetChild(0).gameObject;            
            
            s_item = itemImage;
            itemPanel = panel.GetComponent<itemPanel>();
            blackpanel.SetActive(false);
        }
        panelStd = GameObject.FindGameObjectWithTag("panelStd");
        rayitem = GameObject.Find("rayitem");
    }
    private void Start()
    {
        //FindGameObjectWithTag����Ҫactive����������ҵ����������ҵ�����SetActive(false)
        panel = GameObject.FindGameObjectWithTag("panel");
        panel1 = rayitem.transform.GetChild(5).gameObject;
        panel2 = rayitem.transform.GetChild(6).gameObject;
        panel3 = rayitem.transform.GetChild(7).gameObject;
        if (panel2 != null)
        {
            panel2.SetActive(false);
            panel3.SetActive(false);
            
        }                
        /*if (PlayerPrefs.GetInt(this.name) == 1)
        {//���ٸ�����
            Destroy(this.gameObject);
            //ChangeItemPanel(this.gameObject.name);
        }*/
    }
    /// <summary>
    /// ��Ʒ���½�����
    /// </summary>
    public static void ItemPanelDown()
    {
        itemPanel.itemPanelAnim.SetBool("up", false);
        StaticClass.isPlayerMove = true;
        numDown++;
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
    public static void blackPanelOpen()
    {
        blackpanel.SetActive(true);
    }
    public static void blackPanelClose()
    {
        blackpanel.SetActive(false);
    }

    /// <summary>
    /// ���������ť����Ҫ�����ڰ�ť����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (StaticClass.isFinishedMove && eventData.pointerPress.gameObject.layer == 6)
        {
            ButtonDown(eventData.pointerPress);
            PlayerPrefs.SetInt(eventData.pointerPress.name, 1);
        }
        else if (StaticClass.isFinishedMove && eventData.pointerPress.name=="seed")
        {
            itemPanel.itemPanelAnim.SetBool("up", true);
            blackPanelOpen();

            ChangeItemPanel(eventData.pointerPress.name);

            StaticClass.isPlayerMove = false;
            StaticClass.isItemClick = false;
        }
    }
    /// <summary>
    /// ������Ʒ����Ʒ
    /// </summary>
    /// <param name="eventData"></param>
    public static void ButtonDown(GameObject c)
    {
        Destroy(c);
        itemPanel.itemPanelAnim.SetBool("up", true);
        blackPanelOpen();

        ChangeItemPanel(c.name);

        StaticClass.isPlayerMove = false;
        StaticClass.isItemClick = false;
    }
    /// <summary>
    /// �����Ʒ��
    /// </summary>
    public static void DestroyAllItem()
    {
        if (panel1.transform.childCount != 0)
        {
            for (int i = 0; i < panel1.transform.childCount; i++)
            {
                Destroy(panel1.transform.GetChild(i).gameObject);
            }
        }
        if (panel2.transform.childCount != 0)
        {
            for (int i = 0; i < panel2.transform.childCount; i++)
            {
                Destroy(panel2.transform.GetChild(i).gameObject);
            }
        }
        if (panel3.transform.childCount != 0)
        {
            for (int i = 0; i < panel3.transform.childCount; i++)
            {
                Destroy(panel3.transform.GetChild(i).gameObject);
            }
        }
        
    }
    /// <summary>
    /// �л���Ʒ����panel
    /// </summary>
    /// <param name="name"></param>
    public static void ChangeItemPanel(string name)
    {
        ItemPanelKing();
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
