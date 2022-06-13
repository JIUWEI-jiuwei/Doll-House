using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///¸òó¡
///</summary>
class Hama : MonoBehaviour
{
    public static GameObject hamaDialog0;
    public static GameObject hamaDialog1;
    public static Animator hama;

    private void Start()
    {
        hamaDialog0 = GameObject.Find("hama").transform.GetChild(0).gameObject;
        hamaDialog1 = GameObject.Find("hama").transform.GetChild(1).gameObject;
        hama = this.gameObject.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (StaticClass.isFinishedMove && StaticClass.isHamaClick)
        {           
            hamaDialog0.SetActive(true);
            hama.SetBool("hamatalk", true);
            StaticClass.isHamaClick = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (hamaDialog0 != null)
            {
                hamaDialog0.SetActive(false);
                hamaDialog1.SetActive(false);
                hama.SetBool("hamatalk", false);
            }
        }
    }
    public void OpenPanel()
    {
        StaticClass.isHamaClick = true;
    }
}
