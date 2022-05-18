
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
/// <summary>
/// 鼠标拖拽物品栏的物品
/// </summary>
class MouseDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    /// <summary>图像位置</summary>
    private RectTransform rectTrans;
    private Transform freePanel;

    private void Start()
    {
        freePanel = GameObject.FindGameObjectWithTag("freePanel").transform;
        rectTrans = GetComponent<RectTransform>();
        FindGrid();
    }
    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //解决物体拖拽时父物体移动导致的鼠标偏移问题
        this.transform.SetParent(freePanel);
    }
    /// <summary>
    /// 正在拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        //鼠标位置移动+矫正鼠标偏移
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.name == "Canvas")
            {
                rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }
        //物品栏下降+物品名字消失+物品介绍消失
        TextShow.child0.gameObject.SetActive(false);
        TextShow.text_name.gameObject.SetActive(false);
        UIInteractableManager.ItemPanelDown();
    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        //结束拖拽之后父物体回归
        if (UIInteractableManager.panel1.transform.childCount <= 5)
        {
            this.transform.SetParent(UIInteractableManager.panel1.transform);
        }
        else
        {
            this.transform.SetParent(UIInteractableManager.panel2.transform);
        }
        //物品栏回归并且物品名字出现
        UIInteractableManager.ItemPanelKing();
        TextShow.text_name.gameObject.SetActive(true);

        //若未使用，则回到最初位置
        if (rectTrans != null)
        {
            FindGrid();
        }
        //将UI词条拖拽到角色身上
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);           
        }

    }
    /// <summary>
    /// 将词条位置与卡槽位置相匹配
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

