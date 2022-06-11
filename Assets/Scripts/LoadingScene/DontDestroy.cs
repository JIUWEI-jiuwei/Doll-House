using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///所有不销毁的物体均挂此脚本
///</summary>
class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
