using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

/// <summary>
/// 鼠标拖拽物品栏的物品
/// </summary>
class MouseDragForJiTai : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    /// <summary>祭品</summary>
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

    public static VideoPlayer videoPlayer2;

    private void Start()
    {
        //祭品
        rectTrans = GetComponent<RectTransform>();
        grid = GameObject.Find("grid");
        one1 = grid.transform.GetChild(0);
        two2 = grid.transform.GetChild(1);
        three3 = grid.transform.GetChild(2);
        four4 = grid.transform.GetChild(3);

        jitaiF = GameObject.Find("JiTaiF").transform.GetChild(0);
        jitai=GameObject.Find("祭台").transform.GetChild(0);//主场景中的祭品图片
        for (int i = 0; i < 4; i++)
        {
            plates[i] = jitaiF.GetChild(i);
        }
        //视频
        videoPlayer2 = GameObject.FindGameObjectWithTag("video").GetComponent<VideoPlayer>();

        
    }
    private void FixedUpdate()
    {
        //祭品位置摆放正确
        if (PlayerPrefs.GetInt("isGui1")==1 && PlayerPrefs.GetInt("isGui2") == 1 && PlayerPrefs.GetInt("isGui3") == 1 && PlayerPrefs.GetInt("isGui4") == 1)
        {
            
            //播放盒子开启动画，得到钥匙
            videoPlayer2.Play();
            AudioManager.audioSource.Stop();
            StaticClass.isPlayerMove = false;
            jitai.gameObject.SetActive(true);
        }
        if (videoPlayer2.isPlaying&& videoPlayer2.clip.name== "打开祭台盒子的视频")
        {
            if ((int)videoPlayer2.frame >= (int)videoPlayer2.frameCount - 5)
            {
                videoPlayer2.Stop();
                AudioManager.audioSource.Play();
                jitaiF.gameObject.SetActive(false);
                StaticClass.isPlayerMove = true;
                //退回场景2清空物品栏只显示钥匙,播放给结尾的mp4
                ItemPanelClick.DestroyAllItem();
                ItemPanelClick.ChangeItemPanel("yaoshi");
                Invoke("PlayEndCGVideo", 1.5f);
            }
        }
        if (videoPlayer2.isPlaying && videoPlayer2.clip.name == "endCG")
        {
            if ((int)videoPlayer2.frame >= (int)videoPlayer2.frameCount - 5)
            {
                videoPlayer2.Stop();
                AudioManager.audioSource.Play();
                SceneManager.LoadSceneAsync("DollLayer3");
            }
        }
    }
    /// <summary>
    /// 播放endCG视频
    /// </summary>
    private void PlayEndCGVideo()
    {
        videoPlayer2.clip = videoPlayer2.GetComponent<VideoClips>().videoClips[1];
        videoPlayer2.Play();
        AudioManager.audioSource.Stop();
    }

    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
       /* //解决物体拖拽时父物体移动导致的物体遮挡问题
        tempTF = this.gameObject.transform.GetComponentInParent<Transform>().gameObject;
        this.transform.SetParent(jitaiF);*/
    }
    /// <summary>
    /// 正在拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
       /* //鼠标位置移动+矫正鼠标偏移
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.name == "UpperCanvas")
            {
                rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
                this.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }   */    
    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        /*this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //乌龟的壳+盘子1=》吸附
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
                PlayerPrefs.SetInt("isGui1", 1);
            }
            else if(this.GetComponent<Image>().sprite.name == "lung00"&& eventData.pointerCurrentRaycast.gameObject.name == "plate2")
            {
                StaticClass.two = true;
                PlayerPrefs.SetInt("isGui2", 1);
            }
            else if(this.GetComponent<Image>().sprite.name == "turtleshell00" && eventData.pointerCurrentRaycast.gameObject.name == "plate3")
            {
                StaticClass.three= true;
                PlayerPrefs.SetInt("isGui3", 1);
            }
            else if(this.GetComponent<Image>().sprite.name == "cattooth00" && eventData.pointerCurrentRaycast.gameObject.name == "plate4")
            {
                StaticClass.four = true;
                PlayerPrefs.SetInt("isGui4", 1);
            }
            else if(this.GetComponent<Image>().sprite.name == "yumao00" &&(eventData.pointerCurrentRaycast.gameObject.name == "plate2"
                ||eventData.pointerCurrentRaycast.gameObject.name == "plate3"||eventData.pointerCurrentRaycast.gameObject.name == "plate4"))
            {
                StaticClass.one = false;
                PlayerPrefs.SetInt("isGui1", 2);
            }
            else if(this.GetComponent<Image>().sprite.name == "lung00" && (eventData.pointerCurrentRaycast.gameObject.name == "plate1"
                ||eventData.pointerCurrentRaycast.gameObject.name == "plate3"||eventData.pointerCurrentRaycast.gameObject.name == "plate4"))
            {
                StaticClass.one = false;
                PlayerPrefs.SetInt("isGui2", 2);
            }
            else if(this.GetComponent<Image>().sprite.name == "turtleshell00" && (eventData.pointerCurrentRaycast.gameObject.name == "plate2"
                ||eventData.pointerCurrentRaycast.gameObject.name == "plate1"||eventData.pointerCurrentRaycast.gameObject.name == "plate4"))
            {
                StaticClass.one = false;
                PlayerPrefs.SetInt("isGui3", 2);
            }
            else if(this.GetComponent<Image>().sprite.name == "cattooth00" && (eventData.pointerCurrentRaycast.gameObject.name == "plate2"
                ||eventData.pointerCurrentRaycast.gameObject.name == "plate3"||eventData.pointerCurrentRaycast.gameObject.name == "plate1"))
            {
                StaticClass.one = false;
                PlayerPrefs.SetInt("isGui4", 2);
            }
            #endregion
        }        
        else
        {
            this.gameObject.transform.SetParent(tempTF.transform);            
        }
        FindGrid(plates[0], plates[1], plates[2], plates[3]);*/
    }
    /// <summary>
    /// 位置矫正
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

