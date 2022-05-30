using UnityEngine;
using UnityEngine.UI;

///<summary>
///物品栏点击交互
///</summary>
class UIInteractableManager : MonoBehaviour
{
    /// <summary>物品栏中的panel面板</summary>
    public static GameObject panel;
    public static GameObject panel1;
    public static GameObject panel2;
    public static GameObject panelStd;
    public static GameObject blackpanelF;
    public static GameObject blackpanel;
    /// <summary>获取到物品栏身上的动画</summary>
    public static itemPanel itemPanel;
    /// <summary>预制体本身</summary>
    public GameObject itemImage;
    public float timer = 0.2f;

    private void Awake()
    {
        //FindGameObjectWithTag必须要active的物体才能找到，所以先找到，再SetActive(false)
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
    /// 鼠标点击交互之后(按钮的名称和resources里面的物品名保持一致)
    /// </summary>
    public void MouseUpButton()
    {
        Destroy(this.gameObject);
        itemPanel.itemPanelAnim.SetBool("up", true);
        blackPanelOpen();
        CreateItemInPanel();
    }
    /// <summary>
    /// 生成物品栏物品
    /// </summary>
    public void CreateItemInPanel()
    {
        if (Resources.Load(this.gameObject.name) != null)
        {
            //实例化resources里面的“预制体”，Instantiate实例化的必须是预制体
            GameObject a = Instantiate(itemImage);
            a.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(this.gameObject.name);
            //如果物品栏第一页未满
            if (panel1.transform.childCount <= 5)
            {
                a.transform.SetParent(panel1.transform);
                a.transform.localScale = new Vector3(1, 1, 1);

            }
            else//如果物品栏第一页满了
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
    /// 物品栏下降动画
    /// </summary>
    public static void ItemPanelDown()
    {
        itemPanel.itemPanelAnim.SetBool("up", false);
    }
    /// <summary>
    /// 物品栏上升动画
    /// </summary>
    public static void ItemPanelKing()
    {
        itemPanel.itemPanelAnim.SetBool("up", true);        
    }
    /// <summary>
    /// 物品栏下一页
    /// </summary>
    public void ItemPanelRight()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    /// <summary>
    /// 物品栏上一页
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
