using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///销毁在一二场景中的加载物体
///</summary>
class DestroyLoadingObjects : MonoBehaviour
{
    private void Awake()
    {
        foreach(DontDestroy item in Resources.FindObjectsOfTypeAll(typeof(DontDestroy)))
        {
            if(item.gameObject.name!= "GameManager")
            {
                Destroy(item.gameObject);
            }
        }
    }
}
