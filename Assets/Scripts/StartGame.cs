using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

///<summary>
///开始游戏按钮
///</summary>
class StartGame : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneName;
    public float timeout = 3f;
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
    }
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    public void AlfaChange()
    {
        alfa_black.GetComponent<SpriteRenderer>().material.color = new Color(
            alfa_black.GetComponent<SpriteRenderer>().material.color.r,
            alfa_black.GetComponent<SpriteRenderer>().material.color.g,
            alfa_black.GetComponent<SpriteRenderer>().material.color.b,
            alfa_black.GetComponent<SpriteRenderer>().material.color.a + Time.deltaTime
            );
        if (alfa_black.GetComponent<SpriteRenderer>().material.color.a >= 254f)
        {
            LoadScene();
        }
    }
}
