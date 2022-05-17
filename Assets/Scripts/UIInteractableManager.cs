using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>
class UIInteractableManager : MonoBehaviour
{
    private GameObject panel;
    private itemPanel itemPanel;
    public GameObject itemImage;

    private void Awake()
    {
        
    }
    private void Start()
    {
        //FindGameObjectWithTag必须要active的物体才能找到，所以先找到，再SetActive(false)
        panel = GameObject.FindGameObjectWithTag("panel");
        itemPanel = panel.GetComponent<itemPanel>();
    }
    /// <summary>
    /// 鼠标点击交互之后(按钮的名称和resources里面的物品名保持一致)
    /// </summary>
    public void MouseUpButton()
    {
        Destroy(this.gameObject);
        itemPanel.itemPanelAnim.SetBool("up",true);
        if (Resources.Load(this.gameObject.name) != null)
        {
            //实例化resources里面的“预制体”，Instantiate实例化的必须是预制体
            GameObject a = Instantiate(itemImage);
            a.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(this.gameObject.name);
            a.transform.SetParent(panel.transform);
            a.transform.localScale = new Vector3(1,1,1);
        }
        else
        {
            Debug.Log("null");
        }
    }
    public void ItemPanelDown()
    {
        itemPanel.itemPanelAnim.SetBool("up", false);
    }
    public void ItemPanelKing()
    {
        itemPanel.itemPanelAnim.SetBool("up", true);
    }
}
