
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

///<summary>
///��ʾ��Ʒ�����ı��ͶԻ���
///</summary>
class TextShow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Transform child0;
    private Text text;
    private void Start()
    {
        child0 = this.transform.GetChild(0);        
        text=this.GetComponentInChildren<Text>();
        child0.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.text = ItemText.ShowTextByItemName(this.gameObject.GetComponentInChildren<Image>().sprite.name);
        child0.gameObject.SetActive(true);       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        child0.gameObject.SetActive(false);
    }
}
