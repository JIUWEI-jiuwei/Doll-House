using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

/// <summary>
/// �����ק��Ʒ������Ʒ
/// </summary>
class MouseDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    /// <summary>ͼ��λ��</summary>
    private RectTransform rectTrans;
    private Transform freePanel;
    private ItemPanelClick itemPanelClick;
    private VideoClips videoClips;
    public static VideoPlayer videoPlayer;

    private GameObject player;
    public GameObject dialogPrefab;
    public GameObject itemImage;
    public float timer = 0f;
    public float resTime = 2f;
    private GameObject dialog;
    private Transform dialogPos;
    private GameObject paiting;

    public GameObject jitaiItemPrefab;
    public GameObject seedPrefab;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "DollLayer1")
        {
            paiting = GameObject.Find("nonAnim").transform.GetChild(0).gameObject;
            videoPlayer = GameObject.Find("VideoClips").GetComponent<VideoPlayer>();
        }
        freePanel = GameObject.FindGameObjectWithTag("freePanel").transform;       
        rectTrans = GetComponent<RectTransform>();
        FindGrid();
        player = GameObject.Find("Player");
        itemPanelClick = GameObject.Find("itemPanelClick").GetComponent<ItemPanelClick>();        
        if (player != null)
        {
            dialogPos = player.transform.GetChild(0);
        }
    }
    private void FixedUpdate()
    {
        if (dialog != null&&dialogPos!=null)
        {
            dialog.transform.position = dialogPos.position;
        }
        if (MouseDragForJiTai.videoPlayer2 != null)
        {
            if (MouseDragForJiTai.videoPlayer2.isPlaying && MouseDragForJiTai.videoPlayer2.clip.name == "����������")
            {
                if ((int)MouseDragForJiTai.videoPlayer2.frame >= (int)MouseDragForJiTai.videoPlayer2.frameCount - 3)
                {
                    MouseDragForJiTai.videoPlayer2.Stop();
                }
            }
        }        
    }
    /// <summary>
    /// ��ʼ��ק
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //���������קʱ�������ƶ����µ����ƫ������
        this.transform.SetParent(freePanel);
    }
    /// <summary>
    /// ������ק
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        //���λ���ƶ�+�������ƫ��
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.name == "Canvas")
            {
                rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
                this.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
        //��Ʒ���½�+��Ʒ������ʧ+��Ʒ������ʧ
        if (TextShow.child0 != null)
        {
            TextShow.child0.gameObject.SetActive(false);
            TextShow.text_name.gameObject.SetActive(false);
        }        
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
            //���ֵ����⣺���⵽�������壨���ܹ�ѡ�˲����Ҳû��
            //����Ʒ��ק����Ʒ��֮�⣬��Ʒ���Żή��ȥ
            if (eventData.pointerCurrentRaycast.gameObject.name == "blackPanel")
            {
                ItemPanelClick.ItemPanelDown();
                ItemPanelClick.blackPanelClose();
            }
        }
    }
    /// <summary>
    /// ��ק����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        BackToItemPanel();
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (TextShow.text_name != null)
        {
            TextShow.text_name.gameObject.SetActive(true);
        }

        #region ��һ�ص���Ʒ��ק
        //�ж������ק�����������ɿ�������
        //˿��+������
        if (this.GetComponent<Image>().sprite.name == "ribbon" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {           
            if (PlayerPrefs.GetInt("isGoose1") == 0)
            {
                //���Ʊ���=1����ɫ�ƶ�
                StaticClass.isMoveTarget = 1;
            }                                   
        }
        //ϸ��+��
        else if (this.GetComponent<Image>().sprite.name == "xisheng" && eventData.pointerCurrentRaycast.gameObject.name == "goose")
        {
            //��������ѱ���,����
            if (PlayerPrefs.GetInt("isGoose1") == 1)//Goose.goose.GetCurrentAnimatorStateInfo(0).IsName("Mouseidle")
            {
                //���Ʊ���=1����ɫ�ƶ�
                StaticClass.isMoveTarget2 = 1;
                //Destroy(this.gameObject);               
            }
            else
            {
                foreach (Canvas canvas in FindObjectsOfType<Canvas>())
                {
                    if (canvas.name == "OtherCanvas")
                    {
                        dialog = Instantiate(dialogPrefab, canvas.transform);
                        dialog.transform.GetChild(0).GetComponent<Text>().text = "�����̫ϸ�ˣ����Ҹ���̵Ķ�����";
                        Invoke("DestroyDialog", 2f);
                    }
                }

            }
        }
        //����+����=������
        else if (this.GetComponent<Image>().sprite.name == "candle" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "rawmeat")
        {
            //Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("meatshu");
        }
        //����+����=������2 
        else if (this.GetComponent<Image>().sprite.name == "rawmeat" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "candle")
        {
            //Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("meatshu");
        }
        //����+è=����Һ
        else if (this.GetComponent<Image>().sprite.name == "meatshu" && eventData.pointerCurrentRaycast.gameObject.name == "cat")
        {
            ItemPanelClick.ChangeItemPanel("cattuoye");
        }
        //����+è=����Һ2
        else if (this.GetComponent<Image>().sprite.name == "cat" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "meatshu")
        {
            ItemPanelClick.ChangeItemPanel("cattuoye");
        }
        //����+����=���ս�����
        else if (this.GetComponent<Image>().sprite.name == "candle" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "meatshu")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("boiledmeat");
        }
        //����+����=���ս�����2
        else if (this.GetComponent<Image>().sprite.name == "meatshu" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "candle")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("boiledmeat");
        }
        //�ս�����+è=>�ϳ�
        else if (this.GetComponent<Image>().sprite.name == "boiledmeat" && eventData.pointerCurrentRaycast.gameObject.name == "cat")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("cattooth");
        }
        //�ս�����+è=>�ϳ�2
        else if (this.GetComponent<Image>().sprite.name == "cat" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "boiledmeat")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("cattooth");
        }
        //����+����=��ϸ��
        else if (this.GetComponent<Image>().sprite.name == "necklace" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "scissor")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("xisheng");

        }
        //����+����=��ϸ��2
        else if (this.GetComponent<Image>().sprite.name == "scissor" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "necklace")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("xisheng");
        }
        //��Һ+����=��ʢ��Һ�ı���
        else if (this.GetComponent<Image>().sprite.name == "cattuoye" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "cup")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("tuoyedebeizi");
        }
        //��Һ+����=��ʢ��Һ�ı���2
        else if (this.GetComponent<Image>().sprite.name == "cup" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "cattuoye")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("tuoyedebeizi");
        }
        //����+ֽ��1
        else if (this.GetComponent<Image>().sprite.name == "candle" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "note1")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            //���˿��
            ItemPanelClick.ChangeItemPanel("note1_b");
        }
        //����+ֽ��1 2
        else if (this.GetComponent<Image>().sprite.name == "note1" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "candle")
        {
            Destroy(this.gameObject);
            //���˿��
            ItemPanelClick.ChangeItemPanel("note1_b");
        }
        //����+ˮ��=��ˮ��
        else if (this.GetComponent<Image>().sprite.name == "cup" && eventData.pointerCurrentRaycast.gameObject.name == "bottle")
        {
            ItemPanelClick.ChangeItemPanel("shuidebeizi");
        }

        #endregion

        #region �ڶ�����Ʒ��ק
        //�ں�+�ڹ�=����panel
        else if (this.GetComponent<Image>().sprite.name == "lip" && eventData.pointerCurrentRaycast.gameObject.name == "gui")
        {
            WuGui.wuGuiPanel.SetActive(true);
        }
        //��ֲ����
        else if (this.GetComponent<Image>().sprite.name == "seed" && eventData.pointerCurrentRaycast.gameObject.name == "red")
        {
            Destroy(this.gameObject);
            GameObject s = Instantiate(seedPrefab);
            s.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            s.transform.localScale = new Vector3(1, 1, 1);
            s.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
        }
        else if (this.GetComponent<Image>().sprite.name == "seed" && eventData.pointerCurrentRaycast.gameObject.name == "yellow")
        {
            Destroy(this.gameObject);
            GameObject s = Instantiate(seedPrefab);
            s.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            s.transform.localScale = new Vector3(1, 1, 1);
            s.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
        }
        else if (this.GetComponent<Image>().sprite.name == "seed" && eventData.pointerCurrentRaycast.gameObject.name == "green")
        {
            Destroy(this.gameObject);
            GameObject s = Instantiate(seedPrefab);
            s.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            s.transform.localScale = new Vector3(1, 1, 1);
            s.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
        }
        else if (this.GetComponent<Image>().sprite.name == "seed" && eventData.pointerCurrentRaycast.gameObject.name == "purple")
        {
            Destroy(this.gameObject);
            GameObject s = Instantiate(seedPrefab);
            s.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            s.transform.localScale = new Vector3(1, 1, 1);
            s.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).position;
        }
        //�̶�+�̲�=����
        else if (this.GetComponent<Image>().sprite.name == "yancao" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "yandou")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("yan");
        }
        //�̶�+�̲�=����
        else if (this.GetComponent<Image>().sprite.name == "yandou" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "yancao")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("yan");
        }
         //����+ˮ��=����ҩ
        else if (this.GetComponent<Image>().sprite.name == "ducao" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "shuidebeizi")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("duyao");
        }
        //����+ˮ��=����ҩ
        else if (this.GetComponent<Image>().sprite.name == "shuidebeizi" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "ducao")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("duyao");
        }
        //��ҩ+���=��������֡
        else if (this.GetComponent<Image>().sprite.name == "duyao" && eventData.pointerCurrentRaycast.gameObject.name == "hama")
        {
            if (StaticClass.isHamaDrinking)
            {             
                Hama.hama.SetBool("death", true);
                StaticClass.isHamaDuyao = true;
            }                   
        }
        //����+���=�����ż�������Ƶ�õ���������֡+��  
        else if (this.GetComponent<Image>().sprite.name == "scissor" && eventData.pointerCurrentRaycast.gameObject.name == "hama")
        {
            if (StaticClass.isHamaDuyao)
            {
                MouseDragForJiTai.videoPlayer2.clip = MouseDragForJiTai.videoPlayer2.GetComponent<VideoClips>().videoClips[2];
                MouseDragForJiTai.videoPlayer2.Play();
                Hama.hama.SetBool("sci", true);
                ItemPanelClick.ChangeItemPanel("lung");
            }           
        }
        //ˮ��+���=������˵������+�ı�����ʾ����
        else if (this.GetComponent<Image>().sprite.name == "shuidebeizi" && eventData.pointerCurrentRaycast.gameObject.name == "hama")
        {
            Hama.hama.SetBool("hamatalk", true);
            Hama.hamaDialog0.SetActive(true);
            StaticClass.isHamaDrinking = false;
        }
        //��+���=�����ų��̶���+�ı�����ʾ��ˮ
        else if (this.GetComponent<Image>().sprite.name == "yan" && eventData.pointerCurrentRaycast.gameObject.name == "hama")
        {
            Hama.hama.SetBool("hamasmoke", true);//1.3f
            Invoke("HamaDialog1", 1.2f);
            StaticClass.isHamaDrinking = true;
        }
        //ʢ��Һ�ı���+����=������
        else if (this.GetComponent<Image>().sprite.name == "tuoyedebeizi" && eventData.pointerCurrentRaycast.gameObject.name == "seed(Clone)")
        {
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Animator>().SetBool("grow", true);
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Seed>().isTuoYe = true;
        }
        //ʢˮ�ı���+����=������
        else if (this.GetComponent<Image>().sprite.name == "shuidebeizi" && eventData.pointerCurrentRaycast.gameObject.name == "seed(Clone)")
        {
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Animator>().SetBool("grow", true);
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Seed>().isWater= true;
        }
        //�̲�+�̶�=����
        else if (this.GetComponent<Image>().sprite.name == "yancao" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "yandou")
        {
            Destroy(this.gameObject);
            ItemPanelClick.ChangeItemPanel("yan");
        }
        //�̲�+�̶�=����
        else if (this.GetComponent<Image>().sprite.name == "yandou" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.name == "yancao")
        {
            Destroy(eventData.pointerCurrentRaycast.gameObject);
            ItemPanelClick.ChangeItemPanel("yan");
        }



        //��̨���ڹ�Ŀ�+����1=������
        else if ((this.GetComponent<Image>().sprite.name == "turtleshell"|| this.GetComponent<Image>().sprite.name == "cattooth"||
            this.GetComponent<Image>().sprite.name == "lung" || this.GetComponent<Image>().sprite.name == "yumao") && 
            (eventData.pointerCurrentRaycast.gameObject.name == "plate1"||eventData.pointerCurrentRaycast.gameObject.name == "plate2"||
            eventData.pointerCurrentRaycast.gameObject.name == "plate3" || eventData.pointerCurrentRaycast.gameObject.name == "plate4"))
        {
            if (this.GetComponent<Image>().sprite.name == "yumao" && eventData.pointerCurrentRaycast.gameObject.name == "plate1")
            {
                //StaticClass.one = true;
                PlayerPrefs.SetInt("isGui1", 1);
            }
            else if (this.GetComponent<Image>().sprite.name == "lung" && eventData.pointerCurrentRaycast.gameObject.name == "plate2")
            {
                //StaticClass.two = true;
                PlayerPrefs.SetInt("isGui2", 1);
            }
            else if (this.GetComponent<Image>().sprite.name == "turtleshell" && eventData.pointerCurrentRaycast.gameObject.name == "plate3")
            {
                //StaticClass.three = true;
                PlayerPrefs.SetInt("isGui3", 1);
            }
            else if (this.GetComponent<Image>().sprite.name == "cattooth" && eventData.pointerCurrentRaycast.gameObject.name == "plate4")
            {
                //StaticClass.four = true;
                PlayerPrefs.SetInt("isGui4", 1);
            }
            Destroy(this.gameObject);
            GameObject a = Instantiate(jitaiItemPrefab);
            a.GetComponent<Image>().sprite = Resources.Load<Sprite>(this.GetComponent<Image>().sprite.name + "00");
            a.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            a.transform.localScale = new Vector3(1, 1, 1);
            //MouseDragForJiTai.tempTF = eventData.pointerCurrentRaycast.gameObject;
            a.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        }



        #endregion
        else
        {
            //��Ʒ���ع鲢����Ʒ���ֳ���
            ItemPanelClick.ItemPanelKing();
            ItemPanelClick.blackPanelOpen();
        }
    }

    private void DestroyDialog()
    {
        Destroy(dialog);
    }

    /// <summary>
    /// ������ק֮����Ʒ�ص���Ʒ����panel����
    /// </summary>
    private void BackToItemPanel()
    {
        if (ItemPanelClick.panel1.transform.childCount <= 5)
        {
            this.transform.SetParent(ItemPanelClick.panel1.transform);
        }
        else
        {
            this.transform.SetParent(ItemPanelClick.panel2.transform);
        }
        //��δʹ�ã���ص����λ��
        if (rectTrans != null)
        {
            FindGrid();
        }
    }

    /// <summary>
    /// ��Ƶ������ϣ�����������
    /// </summary>
    /*private void MediaVideoFinished()
    {
        player.SetActive(true);
        paiting.SetActive(true);
        ButtonManager.note2.SetActive(true);
    }
    private void MediaVideoFinished2()
    {
        player.SetActive(true);

        ButtonManager.yumao.SetActive(true);
    }*/

    /// <summary>
    /// ����Ʒλ������Ʒ��λ����ƥ��
    /// </summary>
    public void FindGrid()
    {
        for (int i = 0; i < ItemPanelClick.panel1.transform.childCount; i++)
        {
            ItemPanelClick.panel1.transform.GetChild(i).position = ItemPanelClick.panelStd.transform.GetChild(i).position;
        }
        if (ItemPanelClick.panel2 != null)
        {
            for (int i = 0; i < ItemPanelClick.panel2.transform.childCount; i++)
            {
                ItemPanelClick.panel2.transform.GetChild(i).position = ItemPanelClick.panelStd.transform.GetChild(i).position;
            }
        }
        if(ItemPanelClick.panel3 != null)
        {
            for (int i = 0; i < ItemPanelClick.panel3.transform.childCount; i++)
            {
                ItemPanelClick.panel3.transform.GetChild(i).position = ItemPanelClick.panelStd.transform.GetChild(i).position;
            }
        }        
    }
    public void HamaDialog1()
    {
        Hama.hamaDialog1.SetActive(true);
        Hama.hama.SetBool("hamasmoke", false);
    }
}

