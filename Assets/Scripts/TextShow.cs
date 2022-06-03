
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

///<summary>
///��ʾ��Ʒ�����ı��ͶԻ���
///</summary>
class TextShow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>��ƷԤ����ĵ�һ��������</summary>
    public static Transform child0;
    /// <summary>��ƷԤ����ĵڶ���������</summary>
    private Transform child1;
    /// <summary>��Ʒ���ı����</summary>
    private Text text_details;
    /// <summary>��Ʒ������</summary>
    public static Text text_name;
    /// <summary>����������߼�⵽������</summary>
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

    //�����ͣ
    public void OnPointerEnter(PointerEventData eventData)
    {
        //eventData.pointerCurrentRaycast ��ָ������ǰ��Ӧ���߼���¼�����Ϣ��������������ȡ��ǰ����
        text_details.text = ItemText.ShowTextByItemName(eventData.pointerCurrentRaycast.gameObject.GetComponentInChildren<Image>().sprite.name);
        if (eventData.pointerCurrentRaycast.gameObject.name == "item(Clone)"||eventData.pointerCurrentRaycast.gameObject.name == "item1(Clone)"
            ||eventData.pointerCurrentRaycast.gameObject.name == "item(Clone)(Clone)" ||eventData.pointerCurrentRaycast.gameObject.name == "item1(Clone)(Clone)"  )
        {
            temp = eventData.pointerCurrentRaycast.gameObject;
            eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    //����뿪
    public void OnPointerExit(PointerEventData eventData)
    {
        //��Ϊ����뿪֮���⵽������͸ı��ˣ�������Ҫ�������崢�浽temp������
        temp.transform.GetChild(0).gameObject.SetActive(false);
    }
}
