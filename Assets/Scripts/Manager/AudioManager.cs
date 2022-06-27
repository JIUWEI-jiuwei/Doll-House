using UnityEngine.SceneManagement;
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
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "DollLayer3")
        {
            Destroy(this.gameObject);
        }
    }
}
