
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

///<summary>
///显示物品栏的文本和对话框
///</summary>
class TextShow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>物品预制体的第一个子物体</summary>
    public static Transform child0;
    /// <summary>物品预制体的第二个子物体</summary>
    private Transform child1;
    /// <summary>物品的文本简介</summary>
    private Text text_details;
    /// <summary>物品的名称</summary>
    public static Text text_name;
    /// <summary>储存鼠标射线检测到的物体</summary>
    private GameObject temp;
    private void Start()
    {
        child0 = this.transform.GetChild(0); 
        child1 = this.transform.GetChild(1);
        text_details = child0.GetComponentInChildren<Text>();
        text_name = child1.GetComponent<Text>();        
        text_name.text = ItemText.ShowItemName(this.gameObject.GetComponentInChildren<Image>().sprite.name + "01");
        child0.gameObject.SetActive(false);
        child1.gameObject.SetActive(true);

    }

    //鼠标悬停
    public void OnPointerEnter(PointerEventData eventData)
    {
        //eventData.pointerCurrentRaycast 是指包含当前响应射线检测事件的信息，可以用它来获取当前物体
        text_details.text = ItemText.ShowTextByItemName(eventData.pointerCurrentRaycast.gameObject.GetComponentInChildren<Image>().sprite.name);
        if (eventData.pointerCurrentRaycast.gameObject.name == "item(Clone)"||eventData.pointerCurrentRaycast.gameObject.name == "item1(Clone)"
            ||eventData.pointerCurrentRaycast.gameObject.name == "item(Clone)(Clone)" ||eventData.pointerCurrentRaycast.gameObject.name == "item1(Clone)(Clone)"  )
        {
            temp = eventData.pointerCurrentRaycast.gameObject;
            eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    //鼠标离开
    public void OnPointerExit(PointerEventData eventData)
    {
        //因为鼠标离开之后检测到的物体就改变了，所以需要将该物体储存到temp变量中
        temp.transform.GetChild(0).gameObject.SetActive(false);
    }
}
