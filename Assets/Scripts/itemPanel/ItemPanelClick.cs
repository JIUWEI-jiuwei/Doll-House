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
    public static GameObject panelStd;
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
        blackpanel = GameObject.FindGameObjectWithTag("itemblackpanel").transform.GetChild(0).gameObject;
    }
    private void Start()
    {
        panel2.SetActive(false);
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

    /// <summary>
    /// 点击交互按钮（需要挂载在按钮身上
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (StaticClass.isFinishedMove&&eventData.pointerPress.gameObject.layer==6)//&& StaticClass.isItemClick
        {
            if (eventData.pointerPress.name == "rawmeat")
            {
                if (!ButtonManager.isGetRawMeat) return;
               /* //角色状态改变
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
    /// 生成物品栏物品
    /// </summary>
    /// <param name="eventData"></param>
    private void ButtonDown(PointerEventData eventData)
    {
        Destroy(eventData.pointerPress.gameObject);
        itemPanel.itemPanelAnim.SetBool("up", true);
        blackPanelOpen();

        if (Resources.Load(eventData.pointerPress.gameObject.name) != null)
        {
            //实例化resources里面的“预制体”，Instantiate实例化的必须是预制体
            GameObject a = Instantiate(itemImage);
            a.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(eventData.pointerPress.gameObject.name);
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

        StaticClass.isPlayerMove = false;
        StaticClass.isItemClick = false;
    }
}
