
using UnityEngine;
using RenderHeads.Media.AVProVideo;
using UnityEngine.SceneManagement;
///<summary>
///开始游戏界面
///</summary>
class StartGame : MonoBehaviour
{
    public DisplayUGUI m_displayUGUI;
    public MediaPlayer mediaPlayer;
    public MediaPlayer mediaPlayerB;
    public string sceneName;
    public float time = 10f;
    public void OnStartButton()
    {
        m_displayUGUI.CurrentMediaPlayer = mediaPlayerB;
        mediaPlayerB.Control.Rewind(); 
        mediaPlayerB.Control.Play();
        Invoke("LoadScene", time);
    }
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
