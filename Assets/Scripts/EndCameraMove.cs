using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///最后场景的摄像机移动
///</summary>
class EndCameraMove : MonoBehaviour
{
    public Transform player;
    private float x;
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (player.position.x >= 0)
        {
            x = player.position.x;
            this.transform.position = new Vector3(x, this.transform.position.y, this.transform.position.z);
        }
        
    }
}
