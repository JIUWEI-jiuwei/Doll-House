using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

///<summary>
///��ʼ��Ϸ��ť
///</summary>
class StartGame : MonoBehaviour
{
    /// <summary>���ŵ���ƵstartCG </summary>
    public VideoPlayer videoPlayer;
    /// <summary>Ҫ�л��ĳ��� </summary>
    public string sceneName;
    /// <summary>��Ļ�����ʱ�� </summary>
    public float timeout = 2f;
    /// <summary>��Ļ </summary>
    public GameObject alfa_black;
    public Animator headline;

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
            LoadScene();
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneName);
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
            alfa_black.GetComponent<SpriteRenderer>().color.a + Time.deltaTime/timeout
            );        
    }
}
