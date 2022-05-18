
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
/// <summary>
/// �����ק��Ʒ������Ʒ
/// </summary>
class MouseDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    /// <summary>ͼ��λ��</summary>
    private RectTransform rectTrans;
    private Transform freePanel;

    private void Start()
    {
        freePanel = GameObject.FindGameObjectWithTag("freePanel").transform;
        rectTrans = GetComponent<RectTransform>();
        FindGrid();
    }
    /// <summary>
    /// ��ʼ��ק
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //���������קʱ�������ƶ����µ����ƫ������
        this.transform.SetParent(freePanel);
    }
    /// <summary>
    /// ������ק
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        //���λ���ƶ�+�������ƫ��
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.name == "Canvas")
            {
                rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }
        //��Ʒ���½�+��Ʒ������ʧ+��Ʒ������ʧ
        TextShow.child0.gameObject.SetActive(false);
        TextShow.text_name.gameObject.SetActive(false);
        UIInteractableManager.ItemPanelDown();
    }
    /// <summary>
    /// ��ק����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        //������ק֮������ع�
        if (UIInteractableManager.panel1.transform.childCount <= 5)
        {
            this.transform.SetParent(UIInteractableManager.panel1.transform);
        }
        else
        {
            this.transform.SetParent(UIInteractableManager.panel2.transform);
        }
        //��Ʒ���ع鲢����Ʒ���ֳ���
        UIInteractableManager.ItemPanelKing();
        TextShow.text_name.gameObject.SetActive(true);

        //��δʹ�ã���ص����λ��
        if (rectTrans != null)
        {
            FindGrid();
        }
        //��UI������ק����ɫ����
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);           
        }

    }
    /// <summary>
    /// ������λ���뿨��λ����ƥ��
    /// </summary>
    public void FindGrid()
    {
        for (int i = 0; i < UIInteractableManager.panel1.transform.childCount; i++)
        {
            UIInteractableManager.panel1.transform.GetChild(i).position = UIInteractableManager.panelStd.transform.GetChild(i).position;
        }
        for (int i = 0; i < UIInteractableManager.panel2.transform.childCount; i++)
        {
            UIInteractableManager.panel2.transform.GetChild(i).position = UIInteractableManager.panelStd.transform.GetChild(i).position;
        }
    }
}

