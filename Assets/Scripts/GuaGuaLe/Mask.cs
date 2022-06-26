using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///简单粗暴的刮刮乐实现方法
///</summary>
class Mask : MonoBehaviour
{
    public GameObject brush;

    private void Update()
    {
        Vector3 pos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        if (Input.GetMouseButton(0))
        {
            Instantiate(brush, pos, Quaternion.identity, transform);
        }
        if (this.transform.childCount >= 180)//判断完成
        {
            PlayerPrefs.SetInt("isGuiWin", 1);
        }
    }
}
