using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///���в����ٵ�������Ҵ˽ű�
///</summary>
class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
