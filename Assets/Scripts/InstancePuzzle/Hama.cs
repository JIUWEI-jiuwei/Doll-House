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
    public static AudioSource hamaAudio;

    private void Start()
    {
        hamaDialog0 = GameObject.Find("hama").transform.GetChild(0).gameObject;
        hamaDialog1 = GameObject.Find("hama").transform.GetChild(1).gameObject;
        hama = this.gameObject.GetComponent<Animator>();
        hamaAudio= this.gameObject.GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        if (!StaticClass.isHamaDialog)
        {
            if (StaticClass.isFinishedMove && StaticClass.isHamaClick)
            {
                StaticClass.isHamaClick = false;
                if (PlayerPrefs.GetInt("isHamaDrinking") == 1)
                {
                    hama.SetBool("hamasmoke", true);
                    Invoke("HamaDialog1", 1.2f);
                }
                else if(PlayerPrefs.GetInt("isHamaDrinking") == 0)
                {
                    hamaDialog0.SetActive(true);
                    hama.SetBool("hamatalk", true);
                }
                else
                {
                    
                }
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
        if (PlayerPrefs.GetInt("isHamaDuyao") == 1)
        {
            hama.SetBool("death", true);
            hamaAudio.enabled = false;
            StaticClass.isHamaDialog = true;
            StaticClass.isHamaClick = false;
        }
        if (PlayerPrefs.GetInt("isHamaDuyao") == 2)
        {
            hama.SetBool("sci", true);
            
        }

    }
    public void OpenPanel()
    {
        StaticClass.isHamaClick = true;
    }
    public void HamaDialog1()
    {
        hamaDialog1.SetActive(true);
        hama.SetBool("hamasmoke", false);
    }
}
