using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
class ColorTest : MonoBehaviour
{
    public float timeout = 3f;
    public float a = 255f;
    private void Update()
    {

    }
    public void AlfaChange()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(
             this.gameObject.GetComponent<SpriteRenderer>().color.r,
             this.gameObject.GetComponent<SpriteRenderer>().color.g,
             this.gameObject.GetComponent<SpriteRenderer>().color.b,
             this.gameObject.GetComponent<SpriteRenderer>().color.a + Time.deltaTime
             );
       
    }
}
