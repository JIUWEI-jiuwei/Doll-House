using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///��ӰлĻ�´�
///</summary>
class CurtainCall : MonoBehaviour
{
    public float speed = 1f;

    private void Update()
    {
        this.transform.Translate(0, speed, 0);
    }
}
