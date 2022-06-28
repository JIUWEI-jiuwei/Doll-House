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
            StaticClass.isHamaClick = false;
            if(PlayerPrefs.GetInt("isHamaDrinking") == 1)
            {
                hama.SetBool("hamasmoke", true);
                Invoke("HamaDialog1", 1.2f);
            }
            else
            {
                hamaDialog0.SetActive(true);
                hama.SetBool("hamatalk", true);
            }
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
    public void HamaDialog1()
    {
        Hama.hamaDialog1.SetActive(true);
        Hama.hama.SetBool("hamasmoke", false);
    }
}
