using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

///<summary>
///开始游戏按钮
///</summary>
class StartGame : MonoBehaviour
{
    /// <summary>播放的视频startCG </summary>
    public VideoPlayer videoPlayer;
    /// <summary>黑幕渐变的时间 </summary>
    public float timeout = 2f;
    /// <summary>黑幕 </summary>
    public GameObject alfa_black;
    public Animator headline;
    public Button start;
    public AudioSource audioSource;

    private void Start()
    {
        videoPlayer.Play();
        PlayerPrefs.SetInt("DoorLevel1", 0);
        PlayerPrefs.SetInt("HeartBox", 0);
        PlayerPrefs.SetInt("isHearBoxFirstPlay", 0);
        PlayerPrefs.SetInt("isGoose1", 0);
        PlayerPrefs.SetInt("isGui1", 0);
        PlayerPrefs.SetInt("isGui2", 0);
        PlayerPrefs.SetInt("isGui3", 0);
        PlayerPrefs.SetInt("isGui4", 0);
        PlayerPrefs.SetInt("isGuiClickNum", 0);
        PlayerPrefs.SetInt("isGuiWin", 0);
        
        PlayerPrefs.SetInt("candle", 0);
        PlayerPrefs.SetInt("lip", 0);
        PlayerPrefs.SetInt("note1", 0);
        PlayerPrefs.SetInt("note2", 0);
        PlayerPrefs.SetInt("note3", 0);
        PlayerPrefs.SetInt("yumao", 0);
         PlayerPrefs.SetInt("cup", 0);
        PlayerPrefs.SetInt("rawmeat", 0);
        PlayerPrefs.SetInt("scissor", 0);
        PlayerPrefs.SetInt("yandou", 0);



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
            //播放视频，播放完视频，跳转场景

            videoPlayer.clip = videoPlayer.GetComponent<VideoClips>().videoClips[1];
            videoPlayer.Play();
            audioSource.Stop();
        }
        if (videoPlayer.isPlaying && videoPlayer.clip.name == "starttoone")
        {            
            if ((int)videoPlayer.frame >= (int)videoPlayer.frameCount - 3)
            {
                SceneManager.LoadSceneAsync("DollLayer1");
            }
        }
    }

    /// <summary>
    /// 黑幕从透明变黑
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
    public void  Test()
    {
        SceneManager.LoadSceneAsync("DollLayer1");
    }
}
