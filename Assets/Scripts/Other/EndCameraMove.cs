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
    public AudioSource audioSource;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (player.position.x >= 0&& player.position.x<=163)
        {
            x = player.position.x;
            this.transform.position = new Vector3(x, this.transform.position.y, this.transform.position.z);
        }
        if(this.transform.position.x>15&& this.transform.position.x < 17)
        {
            audioSource.Play();
            audioSource.volume = 0.2f;
        }
        else if(this.transform.position.x > 80 && this.transform.position.x < 82)
        {
            audioSource.Play();
            audioSource.volume = 0.5f;
        }else if(this.transform.position.x > 50 && this.transform.position.x < 52)
        {
            audioSource.Play();
            audioSource.volume = 0.3f;
        }
        else if(this.transform.position.x > 100 && this.transform.position.x < 102)
        {
            audioSource.Play();
            audioSource.volume = 1f;
        }
        else if(this.transform.position.x > 150 && this.transform.position.x < 152)
        {
            audioSource.Stop();
        }

    }
}
