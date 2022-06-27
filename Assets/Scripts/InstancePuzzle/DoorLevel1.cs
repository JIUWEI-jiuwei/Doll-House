using UnityEngine.Video;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

///<summary>
///��
///</summary>
class DoorLevel1 : MonoBehaviour
{
    /// <summary>�ŵ�panel���</summary>
    public Transform doorPanel;
    /// <summary>����CG</summary>
    public VideoPlayer doorOpen;
    /// <summary>�жϵڼ��ε���Ű�ť</summary>
    //private bool nextLevel = false;

    //����ԲȦ���ֶ�
    Vector2 lastPos;//����ϴ�λ��
    Vector2 currPos;//��굱ǰλ��
    Vector2 offset;//����λ�õ�ƫ��ֵ
    /// <summary>ÿ����ת�Ƕ�</summary>
    private float zAngle = 30f;
    /// <summary>����������</summary>
    public Transform circle1;
    public Transform circle2;
    public Transform circle3;
    /// <summary>����а�ť��SpriteState</summary>
    private SpriteState spriteStatus;

    private void Start()
    {
        //����һ���µ�SpriteState��Ψһ���е��޸�SpriteState�ķ�����
        spriteStatus = new SpriteState();
        if(PlayerPrefs.GetInt("DoorLevel1") == 1)
        {
            SwapSprite();
        }
    }
    private void FixedUpdate()
    {
        //�ŵ�
        if (doorOpen.isPlaying)
        {
            //�ж���Ƶ�Ƿ񲥷����
            if ((int)doorOpen.frame >= (int)doorOpen.frameCount - 1)
            {
                doorOpen.gameObject.SetActive(false);
                StaticClass.isPlayerMove = true;
                AudioManager.audioSource.Play();
            }
        }
        //����Ű�ť��Ч��
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
        //�����
        //MiMaPan();
        if (circle1.eulerAngles.z % 360 == 0 && circle2.eulerAngles.z % 360 == 330 && circle3.eulerAngles.z % 360 == 270)
        {//����Ҳ����
            //ʤ��
            ButtonWin();
        }
    }
    /// <summary>
    /// �л���ť��spriteͼƬ
    /// </summary>
    private void SwapSprite()
    {
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("door");
        spriteStatus.highlightedSprite = Resources.Load<Sprite>("��ɫ����");
        spriteStatus.pressedSprite = Resources.Load<Sprite>("��ɫ����");
        spriteStatus.selectedSprite = Resources.Load<Sprite>("��ɫ����");
        this.GetComponent<Button>().spriteState = spriteStatus;
    }

    /// <summary>
    /// �����ť1��ת
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
    /// ������
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
            //�ж����Ļ������������ĸ�����
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
        {//����Ҳ����
            //ʤ��
            ButtonWin();
        }
    }

    /// <summary>
    /// ������껬����ת
    /// </summary>
    /// <param name="_offset">���ƫ����</param>
    /// <param name="circle">��ת������</param>
    void DoMatch(Vector2 _offset, Transform circle)
    {
        //ˮƽ�ƶ�
        if (Mathf.Abs(_offset.x) > Mathf.Abs(_offset.y))
        {
            if (_offset.x > 0)
            {
                // Debug.Log("��");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, -zAngle));
            }
            else
            {
                //Debug.Log("��");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, zAngle));
            }
        }
        else//��ֱ�ƶ�
        {
            if (_offset.y > 0)
            {
                //Debug.Log("��");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, zAngle));

            }
            else if (_offset.y < 0)
            {
                //Debug.Log("��");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, -zAngle));
            }

        }
    }*/
    /// <summary>
    /// �����
    /// </summary>
    public void ClickDoor()
    {
        StaticClass.isDoorClick = true;
    }
    /// <summary>
    /// �ɹ�����
    /// </summary>
    public void ButtonWin()
    {
        doorPanel.gameObject.SetActive(false);
        doorOpen.Play();
        AudioManager.audioSource.Stop();
        Invoke("SwapSprite", 1f);//�ӳ�1s������Ϊ�˷�ֹ��Ƶ�ӳٲ��ŵ����
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
