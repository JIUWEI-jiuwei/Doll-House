using UnityEngine.SceneManagement;
using UnityEngine;
///<summary>
///
///</summary>
class AudioManager2 : MonoBehaviour
{
    public static AudioSource audioSource2;

    private void Start()
    {
        audioSource2 = this.GetComponent<AudioSource>();
    }
 
}
