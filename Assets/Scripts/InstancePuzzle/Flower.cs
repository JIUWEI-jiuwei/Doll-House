using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
class Flower : MonoBehaviour
{
    private GameObject flowerPanel;

    private void Start()
    {
        flowerPanel = GameObject.Find("FlowerF").transform.GetChild(0).gameObject;

    }
    public void OpenPanel()
    {
        flowerPanel.SetActive(true);
    }
    public void ExitPanel()
    {
        flowerPanel.SetActive(false);
    }
}
