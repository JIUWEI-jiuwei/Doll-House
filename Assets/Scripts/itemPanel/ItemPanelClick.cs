using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

///<summary>
///物品栏点击交互
///</summary>
class ItemPanelClick : MonoBehaviour, IPointerClickHandler
{
    /// <summary>物品栏中的panel面板</summary>
    public static GameObject panel;
    public static GameObject panel1;
    public static GameObject panel2;
    public static GameObject panel3;
    

    public static GameObject panelStd;
    public static GameObject blackpanel;
    /// <summary>获取到物品栏身上的动画</summary>
    public static itemPanel itemPanel;
    /// <summary>预制体本身</summary>
    public GameObject itemImage;
    public static GameObject s_item;
    public float timer = 0.2f;

    private void Awake()
    {
        //FindGameObjectWithTag必须要active的物体才能找到，所以先找到，再SetActive(false)
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
    /// 物品栏下降动画
    /// </summary>
    public static void ItemPanelDown()
    {
        itemPanel.itemPanelAnim.SetBool("up", false);
        StaticClass.isPlayerMove = true;
    }
    /// <summary>
    /// 物品栏上升动画
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
    /// 点击交互按钮（需要挂载在按钮身上
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
    /// 生成物品栏物品
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
    /// 切换物品栏的panel
    /// </summary>
    /// <param name="name"></param>
    public static void ChangeItemPanel(string name)
    {
        if (Resources.Load(name) != null)
        {
            //实例化resources里面的“预制体”，Instantiate实例化的必须是预制体
            GameObject a = Instantiate(s_item);
            a.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(name);
            //如果物品栏第一页未满
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
            else//如果物品栏第一页满了
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
