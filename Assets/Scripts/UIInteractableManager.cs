using UnityEngine;
using UnityEngine.UI;

///<summary>
///��Ʒ���������
///</summary>
class UIInteractableManager : MonoBehaviour
{
    /// <summary>��Ʒ���е�panel���</summary>
    public static GameObject panel;
    public static GameObject panel1;
    public static GameObject panel2;
    public static GameObject panelStd;
    public static GameObject blackpanelF;
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
        blackpanelF = GameObject.FindGameObjectWithTag("blackpanel");
        blackpanel = blackpanelF.transform.GetChild(0).gameObject;
    }
    private void Start()
    {       
        panel2.SetActive(false);
        itemPanel = panel.GetComponent<itemPanel>();
        blackpanel.SetActive(false);
    }
    /// <summary>
    /// ���������֮��(��ť�����ƺ�resources�������Ʒ������һ��)
    /// </summary>
    public void MouseUpButton()
    {
        Destroy(this.gameObject);
        itemPanel.itemPanelAnim.SetBool("up", true);
        blackPanelOpen();
        CreateItemInPanel();
    }
    /// <summary>
    /// ������Ʒ����Ʒ
    /// </summary>
    public void CreateItemInPanel()
    {
        if (Resources.Load(this.gameObject.name) != null)
        {
            //ʵ����resources����ġ�Ԥ���塱��Instantiateʵ�����ı�����Ԥ����
            GameObject a = Instantiate(itemImage);
            a.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(this.gameObject.name);
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
        else
        {
            Debug.Log("null");
        }
    }

    /// <summary>
    /// ��Ʒ���½�����
    /// </summary>
    public static void ItemPanelDown()
    {
        itemPanel.itemPanelAnim.SetBool("up", false);
    }
    /// <summary>
    /// ��Ʒ����������
    /// </summary>
    public static void ItemPanelKing()
    {
        itemPanel.itemPanelAnim.SetBool("up", true);        
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
}
