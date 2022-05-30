using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

///<summary>
///开始游戏按钮
///</summary>
class StartGame : MonoBehaviour
{
    /// <summary>播放的视频startCG </summary>
    public VideoPlayer videoPlayer;
    /// <summary>要切换的场景 </summary>
    public string sceneName;
    /// <summary>黑幕渐变的时间 </summary>
    public float timeout = 3f;
    /// <summary>黑幕 </summary>
    public GameObject alfa_black;

    public void OnStartButton()
    {
        videoPlayer.Pause();
        StaticClass.alfa = true;
    }
    private void Update()
    {
        if (StaticClass.alfa == true)
        {
            AlfaChange();
        }
        if (alfa_black.GetComponent<SpriteRenderer>().color.a >= 0.95f)
        {
            LoadScene();
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneName);
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
            alfa_black.GetComponent<SpriteRenderer>().color.a + Time.deltaTime/timeout
            );        
    }
}
