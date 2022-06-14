using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

///<summary>
///��ʼ��Ϸ��ť
///</summary>
class StartGame : MonoBehaviour
{
    /// <summary>���ŵ���ƵstartCG </summary>
    public VideoPlayer videoPlayer;
    /// <summary>��Ļ�����ʱ�� </summary>
    public float timeout = 2f;
    /// <summary>��Ļ </summary>
    public GameObject alfa_black;
    public Animator headline;
    public Button start;

    private void Start()
    {
        videoPlayer.Play();
    }
    public void OnStartButton()
    {
        headline.SetBool("reverse", true);

    }
    private void Update()
    {
        if (headline.GetCurrentAnimatorStateInfo(0).IsName("stop"))
        {
            videoPlayer.Pause();
            StaticClass.alfa = true;
        }
        if (StaticClass.alfa == true)
        {
            AlfaChange();
        }
        if (alfa_black.GetComponent<SpriteRenderer>().color.a >= 0.95f)
        {
            alfa_black.SetActive(false);
            start.gameObject.SetActive(false);
            //������Ƶ����������Ƶ����ת����
            if (!StaticClass.isStartCG)
            {
                videoPlayer.clip = videoPlayer.GetComponent<VideoClips>().videoClips[1];
                videoPlayer.Play();
                StaticClass.isStartCG = true;
            }           
        }
        if (videoPlayer.isPlaying && videoPlayer.clip.name == "starttoone")
        {
            Debug.Log("jinqule");
            videoPlayer.isLooping = false;
            if ((int)videoPlayer.frame >= (int)videoPlayer.frameCount - 1)
            {
                Debug.Log("jinqule22");
                SceneManager.LoadSceneAsync("DollLayer1");
            }
        }
    }

    /// <summary>
    /// ��Ļ��͸�����
    /// </summary>
    public void AlfaChange()
    {
        alfa_black.GetComponent<SpriteRenderer>().color = new Color(
            alfa_black.GetComponent<SpriteRenderer>().color.r,
            alfa_black.GetComponent<SpriteRenderer>().color.g,
            alfa_black.GetComponent<SpriteRenderer>().color.b,
            alfa_black.GetComponent<SpriteRenderer>().color.a + Time.deltaTime / timeout
            );
    }
}
