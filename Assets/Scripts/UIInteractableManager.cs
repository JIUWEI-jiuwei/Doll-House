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
        //FindGameObjectWithTag����Ҫactive����������ҵ����������ҵ�����SetActive(false)
        panel = GameObject.FindGameObjectWithTag("panel");
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
