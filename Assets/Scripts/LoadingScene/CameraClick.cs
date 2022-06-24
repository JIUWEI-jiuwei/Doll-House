using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///挂在角色本身
///</summary>
class CameraClick : MonoBehaviour
{
    private GameObject child0;
    private void Start()
    {
        child0 = this.transform.GetChild(0).gameObject;
        child0.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            child0.SetActive(true);
            Invoke("SetFalse", 1.2f);
        }
    }
    public void SetFalse()
    {
        child0.SetActive(false);
    }
}
