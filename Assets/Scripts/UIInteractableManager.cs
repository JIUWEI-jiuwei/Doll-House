using UnityEngine;

///<summary>
///
///</summary>
class UIInteractableManager : MonoBehaviour
{
    private GameObject panel;
    private void Awake()
    {
        
    }
    private void Start()
    {
        //FindGameObjectWithTag必须要active的物体才能找到，所以先找到，再SetActive(false)
        panel = GameObject.FindGameObjectWithTag("panel");
        panel.SetActive(false);
    }
    /// <summary>
    /// 鼠标点击交互之后(按钮的名称和resources里面的物品名保持一致)
    /// </summary>
    public void MouseDownButton()
    {
        Destroy(this.gameObject);
        panel.SetActive(true);
        if (Resources.Load(this.gameObject.name) != null)
        {
            //实例化resources里面的“预制体”，Instantiate实例化的必须是预制体
            GameObject a = Instantiate(Resources.Load(this.gameObject.name)) as GameObject;
            a.transform.SetParent(panel.transform);
        }
        else
        {
            Debug.Log("null");
        }
    }
}
