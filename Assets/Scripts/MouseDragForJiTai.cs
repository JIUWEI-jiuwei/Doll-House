using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

/// <summary>
/// �����ק��Ʒ������Ʒ
/// </summary>
class MouseDragForJiTai : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    /// <summary>��Ʒ</summary>
    private RectTransform rectTrans;
    public GameObject jitaiItemPrefab;
    public static GameObject tempTF;
    private Transform one1;
    private Transform two2;
    private Transform three3;
    private Transform four4;
    private GameObject grid;
    private Transform jitaiF;
    private Transform jitai;
    private Transform[] plates=new Transform[4];

    private VideoPlayer videoPlayer2;

    private void Start()
    {
        //��Ʒ
        rectTrans = GetComponent<RectTransform>();
        grid = GameObject.Find("grid");
        one1 = grid.transform.GetChild(0);
        two2 = grid.transform.GetChild(1);
        three3 = grid.transform.GetChild(2);
        four4 = grid.transform.GetChild(3);

        jitaiF = GameObject.Find("JiTaiF").transform.GetChild(0);
        jitai=GameObject.Find("��̨").transform.GetChild(0);
        for (int i = 0; i < 4; i++)
        {
            plates[i] = jitaiF.GetChild(i);
        }
        //��Ƶ
        videoPlayer2 = GameObject.FindGameObjectWithTag("video").GetComponent<VideoPlayer>();
    }
    private void FixedUpdate()
    {
        //��Ʒλ�ðڷ���ȷ
        if (StaticClass.one && StaticClass.two && StaticClass.three && StaticClass.four)
        {
            //���ź��ӿ������������ӿ�������ȡԿ��
            videoPlayer2.Play();
            StaticClass.isPlayerMove = false;
            jitai.gameObject.SetActive(true);
        }
        if (videoPlayer2.isPlaying)
        {
            if ((int)videoPlayer2.frame >= (int)videoPlayer2.frameCount - 1)
            {
                videoPlayer2.Stop();
                StaticClass.isPlayerMove = true;
            }
        }
    }
    /// <summary>
    /// ��ʼ��ק
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //���������קʱ�������ƶ����µ������ڵ�����
        tempTF = this.gameObject.transform.GetComponentInParent<Transform>().gameObject;
        this.transform.SetParent(jitaiF);
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
            if (canvas.name == "UpperCanvas")
            {
                rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
                this.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }       
    }
    /// <summary>
    /// ��ק����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //�ڹ�Ŀ�+����1=������
        if ((this.GetComponent<Image>().sprite.name == "turtleshell00"|| this.GetComponent<Image>().sprite.name == "cattooth00"||
            this.GetComponent<Image>().sprite.name == "lung00" || this.GetComponent<Image>().sprite.name == "yumao00") && 
            (eventData.pointerCurrentRaycast.gameObject.name == "plate1"||eventData.pointerCurrentRaycast.gameObject.name == "plate2"||
            eventData.pointerCurrentRaycast.gameObject.name == "plate3" || eventData.pointerCurrentRaycast.gameObject.name == "plate4"))
        {
            this.gameObject.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            #region 
            if (this.GetComponent<Image>().sprite.name == "yumao00"&& eventData.pointerCurrentRaycast.gameObject.name == "plate1")
            {
                StaticClass.one = true;
            }
            else if(this.GetComponent<Image>().sprite.name == "lung00"&& eventData.pointerCurrentRaycast.gameObject.name == "plate2")
            {
                StaticClass.two = true;
            }
            else if(this.GetComponent<Image>().sprite.name == "turtleshell00" && eventData.pointerCurrentRaycast.gameObject.name == "plate3")
            {
                StaticClass.three= true;
            }
            else if(this.GetComponent<Image>().sprite.name == "cattooth00" && eventData.pointerCurrentRaycast.gameObject.name == "plate4")
            {
                StaticClass.four = true;
            }
            else if(this.GetComponent<Image>().sprite.name == "yumao00" &&(eventData.pointerCurrentRaycast.gameObject.name == "plate2"
                ||eventData.pointerCurrentRaycast.gameObject.name == "plate3"||eventData.pointerCurrentRaycast.gameObject.name == "plate4"))
            {
                StaticClass.one = false;
            }
            else if(this.GetComponent<Image>().sprite.name == "lung00" && (eventData.pointerCurrentRaycast.gameObject.name == "plate1"
                ||eventData.pointerCurrentRaycast.gameObject.name == "plate3"||eventData.pointerCurrentRaycast.gameObject.name == "plate4"))
            {
                StaticClass.one = false;
            }
            else if(this.GetComponent<Image>().sprite.name == "turtleshell00" && (eventData.pointerCurrentRaycast.gameObject.name == "plate2"
                ||eventData.pointerCurrentRaycast.gameObject.name == "plate1"||eventData.pointerCurrentRaycast.gameObject.name == "plate4"))
            {
                StaticClass.one = false;
            }
            else if(this.GetComponent<Image>().sprite.name == "cattooth00" && (eventData.pointerCurrentRaycast.gameObject.name == "plate2"
                ||eventData.pointerCurrentRaycast.gameObject.name == "plate3"||eventData.pointerCurrentRaycast.gameObject.name == "plate1"))
            {
                StaticClass.one = false;
            }
            #endregion
        }        
        else
        {
            this.gameObject.transform.SetParent(tempTF.transform);            
        }
        FindGrid(plates[0], plates[1], plates[2], plates[3]);
    }
    /// <summary>
    /// λ�ý���
    /// </summary>
    public void FindGrid(Transform a, Transform b, Transform c,Transform d)
    {
        if (a.transform.childCount > 0)
        {
            a.transform.GetChild(0).position = one1.position;
            if (a.transform.childCount>1)
            {
                a.transform.GetChild(1).position = one1.position;
            }
        }
        if (b.transform.childCount > 0)
        {
            b.transform.GetChild(0).position = two2.position;
            if (b.transform.childCount > 1)
            {
                b.transform.GetChild(1).position = two2.position;
            }
        }
        if (c.transform.childCount > 0)
        {
            c.transform.GetChild(0).position = three3.position;
            if (c.transform.childCount > 1)
            {
                c.transform.GetChild(1).position = three3.position;
            }
        }
        if (d.transform.childCount > 0)
        {
            d.transform.GetChild(0).position = four4.position;
            if (d.transform.childCount > 1)
                d.transform.GetChild(1).position = four4.position;
        }

    }
}
