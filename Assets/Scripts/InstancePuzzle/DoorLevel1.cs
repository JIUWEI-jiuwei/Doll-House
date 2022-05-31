using UnityEngine.Video;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

///<summary>
///门
///</summary>
class DoorLevel1 : MonoBehaviour
{
    public Transform doorPanel;
    public VideoPlayer doorOpen;
    private bool nextLevel=false;

    private void FixedUpdate()
    {
        if (doorOpen.isPlaying)
        {
            //判断视频是否播放完成
            if ((int)doorOpen.frame >= (int)doorOpen.frameCount - 1)
            {
                doorOpen.gameObject.SetActive(false);


            }
        }
    }
    public void ClickDoor()
    {
        if (nextLevel == false)
        {
            doorPanel.gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadSceneAsync("DollLayer2");
        }
    }
    public void ButtonWin()
    {
        doorPanel.gameObject.SetActive(false);
        doorOpen.Play();
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("黑色的门");
        nextLevel = true;
    }
    public void Back()
    {
        doorPanel.gameObject.SetActive(false);
    }

}
