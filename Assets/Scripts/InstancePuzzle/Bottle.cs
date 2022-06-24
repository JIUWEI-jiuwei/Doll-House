using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
class Bottle : MonoBehaviour
{
    private GameObject bottleText;
    private void Start()
    {
        bottleText = this.transform.GetChild(0).gameObject;
    }
    public void ShowText()
    {
        bottleText.SetActive(true);
        Invoke("SetFalse", 1.8f);
    }
    public void SetFalse()
    {
        bottleText.SetActive(false);
    }
}
