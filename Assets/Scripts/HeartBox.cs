using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;

///<summary>
///�����
///</summary>
class HeartBox : MonoBehaviour
{
    /// <summary>����е�������Ƶ</summary>
    public VideoPlayer heartVideo;
    public VideoPlayer necklaceVideo;
    public GameObject itemImage;
    private int num1 = 0;
    private int num2 = 0;
    private int num3 = 0;
    private int num4 = 0;
    public Button bt1;
    public Button bt2;
    public Button bt3;
    public Button bt4;
    /// <summary>�⿪�����panel���ĸ�����F</summary>
    private GameObject mimaPanel;
    /// <summary>�⿪�����panel���</summary>
    private Transform mimaPanel0;
    /// <summary>����а�ť��SpriteState</summary>
    private SpriteState spriteStatus;
    /// <summary>�Ƿ�Ϊ��һ�ε����ť</summary>
    private bool isFirst = true;

    private void Start()
    {
        //��ȡ��ť���ı�
        bt1.GetComponentInChildren<Text>().text = num1.ToString();
        bt2.GetComponentInChildren<Text>().text = num2.ToString();
        bt3.GetComponentInChildren<Text>().text = num3.ToString();
        bt4.GetComponentInChildren<Text>().text = num4.ToString();
        //��ȡ��������
        mimaPanel = GameObject.FindGameObjectWithTag("mimahe");
        mimaPanel0 = mimaPanel.transform.GetChild(0);
        mimaPanel0.gameObject.SetActive(false);
        //����һ���µ�SpriteState��Ψһ���е��޸�SpriteState�ķ�����
        spriteStatus = new SpriteState();
    }
    private void Update()
    {
        //�ж���Ƶ�Ƿ񲥷����(ע�⣺һ��Ҫ����update���棬�ſ����ж���Ƶ��ǰ֡��)
        if (heartVideo.isPlaying)
        {
            if ((int)heartVideo.frame >= (int)heartVideo.frameCount - 1)
            {
                heartVideo.gameObject.SetActive(false);
                mimaPanel0.gameObject.SetActive(true);
            }
        }
        //���������ȷ
        if (num1 == 0 && num2 == 8 && num3 == 1 && num4 == 4)
        {
            necklaceVideo.Play();
            if (necklaceVideo.isPlaying)
            {
                //�ж���Ƶ�Ƿ񲥷����
                if ((int)necklaceVideo.frame >= (int)necklaceVideo.frameCount - 1)
                {
                    necklaceVideo.gameObject.SetActive(false);
                    mimaPanel0.gameObject.SetActive(false);
                    //����в����ٽ���
                    GetComponent<Button>().interactable = false;
                    //�������
                    GameObject a = Instantiate(itemImage);
                    a.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("necklace");
                    //�����Ʒ����һҳδ��
                    if (UIInteractableManager.panel1.transform.childCount <= 5)
                    {
                        a.transform.SetParent(UIInteractableManager.panel1.transform);
                        a.transform.localScale = new Vector3(1, 1, 1);

                    }
                    else//�����Ʒ����һҳ����
                    {
                        a.transform.SetParent(UIInteractableManager.panel2.transform);
                        a.transform.localScale = new Vector3(1, 1, 1);
                        UIInteractableManager.panel1.SetActive(false);
                    }
                }                
            }
        }
    }
    /// <summary>
    /// ��һ�ε������У�������Ƶ
    /// </summary>
    public void FirstOpenBox()
    {       
        if (isFirst)//��һ�ε��
        {
            heartVideo.Play();
            Invoke("SwapSprite", 1f);//�ӳ�1s������Ϊ�˷�ֹ��Ƶ�ӳٲ��ŵ����
            isFirst = false;
        }
        else//�ڶ��μ��Ժ���
        {
            mimaPanel0.gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// �л���ť��spriteͼƬ
    /// </summary>
    private void SwapSprite()
    {
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("heartbox");
        spriteStatus.highlightedSprite = Resources.Load<Sprite>("heartboxY");
        spriteStatus.pressedSprite = Resources.Load<Sprite>("heartboxY");
        spriteStatus.selectedSprite = Resources.Load<Sprite>("heartboxY");
        this.GetComponent<Button>().spriteState = spriteStatus;
    }

    /// <summary>
    /// �ĸ���������
    /// </summary>
    public void Button1()
    {
        num1++;
        if (num1 > 9)
        {
            num1 = 0;
        }
        bt1.GetComponentInChildren<Text>().text = num1.ToString();
    }
    public void Button2()
    {
        num2++;
        if (num2 > 9)
        {
            num2 = 0;
        }
        bt2.GetComponentInChildren<Text>().text = num2.ToString();
    }
    public void Button3()
    {
        num3++;
        if (num3 > 9)
        {
            num3 = 0;
        }
        bt3.GetComponentInChildren<Text>().text = num3.ToString();
    }
    public void Button4()
    {
        num4++;
        if (num4 > 9)
        {
            num4 = 0;
        }
        bt4.GetComponentInChildren<Text>().text = num4.ToString();
    }
    //���ܽ���ķ��ذ�ť
    public void backGame()
    {
        mimaPanel0.gameObject.SetActive(false);
    }
}
