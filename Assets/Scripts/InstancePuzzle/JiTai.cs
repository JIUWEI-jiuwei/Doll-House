using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
class JiTai : MonoBehaviour
{
    public static GameObject jitaiPanel;

    private void Start()
    {
        jitaiPanel = GameObject.Find("JiTaiF").transform.GetChild(0).gameObject;
    }
    private void FixedUpdate()
    {
        
    }
    public void OpenPanel()
    {
        jitaiPanel.SetActive(true);
    }
    public void ExitPanel()
    {
        jitaiPanel.SetActive(false);
    }
}
