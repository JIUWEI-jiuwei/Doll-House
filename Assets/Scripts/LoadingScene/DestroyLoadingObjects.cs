using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///������һ�������еļ�������
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
