using UnityEngine.Video;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

///<summary>
///门
///</summary>
class DoorLevel1 : MonoBehaviour
{
    /// <summary>门的panel面板</summary>
    public Transform doorPanel;
    /// <summary>开门CG</summary>
    public VideoPlayer doorOpen;
    /// <summary>判断第几次点击门按钮</summary>
    //private bool nextLevel = false;

    //密码圆圈的字段
    Vector2 lastPos;//鼠标上次位置
    Vector2 currPos;//鼠标当前位置
    Vector2 offset;//两次位置的偏移值
    /// <summary>每次旋转角度</summary>
    private float zAngle = 30f;
    /// <summary>三个密码盘</summary>
    public Transform circle1;
    public Transform circle2;
    public Transform circle3;
    /// <summary>密码盒按钮的SpriteState</summary>
    private SpriteState spriteStatus;

    private void Start()
    {
        //创建一个新的SpriteState（唯一可行的修改SpriteState的方法）
        spriteStatus = new SpriteState();
        if(PlayerPrefs.GetInt("DoorLevel1") == 1)
        {
            SwapSprite();
        }
    }
    private void FixedUpdate()
    {
        //门的
        if (doorOpen.isPlaying)
        {
            //判断视频是否播放完成
            if ((int)doorOpen.frame >= (int)doorOpen.frameCount - 1)
            {
                doorOpen.gameObject.SetActive(false);
                StaticClass.isPlayerMove = true;
                AudioManager.audioSource.Play();
            }
        }
        //点击门按钮的效果
        if (StaticClass.isFinishedMove && StaticClass.isDoorClick)
        {
            if (PlayerPrefs.GetInt("DoorLevel1") == 0)
            {
                doorPanel.gameObject.SetActive(true);
            }
            else
            {
                SceneManager.LoadSceneAsync("DollLayer2");
            }
            //StaticClass.isPlayerMove = false;
            StaticClass.isDoorClick = false;
        }
        //密码的
        //MiMaPan();
        if (circle1.eulerAngles.z % 360 == 0 && circle2.eulerAngles.z % 360 == 330 && circle3.eulerAngles.z % 360 == 270)
        {//负数也适用
            //胜利
            ButtonWin();
        }
    }
    /// <summary>
    /// 切换按钮的sprite图片
    /// </summary>
    private void SwapSprite()
    {
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("door");
        spriteStatus.highlightedSprite = Resources.Load<Sprite>("黑色的门");
        spriteStatus.pressedSprite = Resources.Load<Sprite>("黑色的门");
        spriteStatus.selectedSprite = Resources.Load<Sprite>("黑色的门");
        this.GetComponent<Button>().spriteState = spriteStatus;
    }

    /// <summary>
    /// 点击按钮1旋转
    /// </summary>
    public void ClickToRotate1()
    {
        circle1.Rotate(new Vector3(circle1.rotation.x, circle1.rotation.y, -zAngle));
    }
     public void ClickToRotate2()
    {
        circle2.Rotate(new Vector3(circle2.rotation.x, circle2.rotation.y, -zAngle));
    }
     public void ClickToRotate3()
    {
        circle3.Rotate(new Vector3(circle3.rotation.x, circle3.rotation.y, -zAngle));
    }

   /* /// <summary>
    /// 密码盘
    /// </summary>
    private void MiMaPan()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            currPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = currPos - lastPos;
            //判定鼠标的滑动区域在是哪个密码
            if (lastPos.x > -8 && lastPos.x < -4.5 && lastPos.y > -0.5 && lastPos.y < 2.5)
            {
                DoMatch(offset, circle1);
            }
            else if (lastPos.x > -3 && lastPos.x < 0 && lastPos.y > -0.5 && lastPos.y < 2.5)
            {
                DoMatch(offset, circle2);
            }
            else if (lastPos.x > 2 && lastPos.x < 5 && lastPos.y > -0.5 && lastPos.y < 2.5)
            {
                DoMatch(offset, circle3);
            }

        }
        if (circle1.eulerAngles.z % 360 == 0 && circle2.eulerAngles.z % 360 == 330 && circle3.eulerAngles.z % 360 == 270)
        {//负数也适用
            //胜利
            ButtonWin();
        }
    }

    /// <summary>
    /// 根据鼠标滑动旋转
    /// </summary>
    /// <param name="_offset">鼠标偏移量</param>
    /// <param name="circle">旋转的密码</param>
    void DoMatch(Vector2 _offset, Transform circle)
    {
        //水平移动
        if (Mathf.Abs(_offset.x) > Mathf.Abs(_offset.y))
        {
            if (_offset.x > 0)
            {
                // Debug.Log("右");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, -zAngle));
            }
            else
            {
                //Debug.Log("左");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, zAngle));
            }
        }
        else//垂直移动
        {
            if (_offset.y > 0)
            {
                //Debug.Log("上");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, zAngle));

            }
            else if (_offset.y < 0)
            {
                //Debug.Log("下");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, -zAngle));
            }

        }
    }*/
    /// <summary>
    /// 点击门
    /// </summary>
    public void ClickDoor()
    {
        StaticClass.isDoorClick = true;
    }
    /// <summary>
    /// 成功解锁
    /// </summary>
    public void ButtonWin()
    {
        doorPanel.gameObject.SetActive(false);
        doorOpen.Play();
        AudioManager.audioSource.Stop();
        Invoke("SwapSprite", 1f);//延迟1s调用是为了防止视频延迟播放的情况
        PlayerPrefs.SetInt("DoorLevel1", 1);
    }
    public void Back()
    {
        doorPanel.gameObject.SetActive(false);
        Invoke("PlayerMove", 1f);
    }
    public void PlayerMove()
    {
        StaticClass.isPlayerMove = true;
    }

}
