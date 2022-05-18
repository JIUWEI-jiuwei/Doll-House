using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>
class UIInteractableManager : MonoBehaviour
{
    /// <summary>��Ʒ���е�panel���</summary>
    public static GameObject panel;
    public static GameObject panel1;
    public static GameObject panel2;
    public static GameObject panelStd;
    /// <summary>��ȡ����Ʒ�����ϵĶ���</summary>
    public static itemPanel itemPanel;
    /// <summary>Ԥ���屾��</summary>
    public GameObject itemImage;

    private void Awake()
    {
        //FindGameObjectWithTag����Ҫactive����������ҵ����������ҵ�����SetActive(false)
        panel = GameObject.FindGameObjectWithTag("panel");
        panel1 = GameObject.FindGameObjectWithTag("panel1");
        panel2 = GameObject.FindGameObjectWithTag("panel2");
        panelStd = GameObject.FindGameObjectWithTag("panelStd");
    }
    private void Start()
    {       
        panel2.SetActive(false);
        itemPanel = panel.GetComponent<itemPanel>();
    }
    /// <summary>
    /// ���������֮��(��ť�����ƺ�resources�������Ʒ������һ��)
    /// </summary>
    public void MouseUpButton()
    {
        Destroy(this.gameObject);
        itemPanel.itemPanelAnim.SetBool("up",true);
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
}
