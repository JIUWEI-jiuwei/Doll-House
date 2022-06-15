using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
class AudioManager : MonoBehaviour
{
    public static AudioSource audioSource;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

}
