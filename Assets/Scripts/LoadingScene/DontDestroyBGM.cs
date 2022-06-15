using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
class DontDestroyBGM : MonoBehaviour
{
    public GameObject MusicBk;
    public static bool IsHaveMusicBk = false;
    private GameObject clone;

    void Start()
    {
        if (!IsHaveMusicBk)
        {
            clone = Instantiate(MusicBk, transform.position, transform.rotation) ;
            IsHaveMusicBk = true;
        }

        DontDestroyOnLoad(clone);
    }


}
