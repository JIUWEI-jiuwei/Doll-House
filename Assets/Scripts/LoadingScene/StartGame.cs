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
            //播放视频，播放完视频，跳转场景
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
}
