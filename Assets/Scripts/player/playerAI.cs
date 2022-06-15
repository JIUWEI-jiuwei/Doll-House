using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

///<summary>
///2D��ɫ�Զ�Ѱ·�ű�
///</summary>
class playerAI : MonoBehaviour
{
    /// <summary>player׷�ٵ�Ŀ��</summary>
    [SerializeField] Transform target;
    /// <summary>��ɫagent</summary>
    NavMeshAgent agent;

    /// <summary>��agent��target��z�ᶼ�趨Ϊһ��ֵ�������ж�������</summary>
    private float mouseZ = 0;
    /// <summary>��ɫ�Ķ���</summary>
    public static Animator player;
    /// <summary>��ɫ��Ŀ��֮��ľ���</summary>
    public float distance = 1f;
    public Transform rawmeatPos;
    public Animator rawmeatAnim;
    /// <summary>�����ұ�</summary>
    public bool m_FacingRight = true;
    public Transform goosePos;
    public Transform catPos;


    private void Start()
    {
        //����agent
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        /// <summary>��ȡ�����Ľ�ɫ�Ķ���</summary>
        player = this.transform.GetChild(0).GetComponent<Animator>();
        StaticClass.isFinishedMove = false;
    }

    private void Update()
    {
        //�����λ���趨Ϊtarget
        target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, mouseZ); ;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (agent.isOnNavMesh)
        {
            //��ʼ��·
            if (Input.GetMouseButtonUp(0) && StaticClass.isPlayerMove == true)
            {
                player.SetBool("startwalk", true);
                player.SetBool("walk", true);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.name == "rawmeat")
                    {
                        agent.SetDestination(rawmeatPos.position);
                        if (ButtonManager.isGetRawMeat)
                        {
                            if (Vector3.Distance(rawmeatPos.position, this.transform.position) <= 1.5)
                            {//����ָ���ص�
                                player.gameObject.SetActive(false);
                                rawmeatAnim.gameObject.SetActive(true);
                            }
                            if (rawmeatAnim.GetCurrentAnimatorStateInfo(0).IsName("climbstop"))
                            {//���ﶥ��
                                Destroy(hit.collider.gameObject);
                                ItemPanelClick.ChangeItemPanel(hit.collider.gameObject.name);

                                rawmeatAnim.SetBool("reverse", true);
                                //����׶˵ĺ���
                                Invoke("ArriveDown", 4f);
                            }

                        }
                    }
                    else if (hit.collider.gameObject.name == "cat")
                    {
                        agent.SetDestination(target.position);
                    }
                }
                else
                {
                    agent.SetDestination(target.position);
                }

                StaticClass.isFinishedMove = false;

                //ת��

                if (target.position.x >= this.gameObject.transform.position.x && m_FacingRight)//����
                {
                    Flip();
                }
                else if (target.position.x < this.gameObject.transform.position.x && !m_FacingRight)
                {
                    Flip();
                }
            }
            //������·
            if (Vector3.Distance(target.position, this.transform.position) <= distance)
            {
                player.SetBool("startwalk", false);
                player.SetBool("walk", true);
                player.SetBool("stop", true);
                player.SetBool("backidle", true);
                StaticClass.isFinishedMove = true;
            }
            else if (Vector3.Distance(target.position, this.transform.position) >= distance + 2)
            {               
                StaticClass.isFinishedMove = false;
            }
           
        }

        GooseAndRibbon();
        GooseAndXisheng();
    }
    /// <summary>
    /// ϸ����콻��
    /// </summary>
    private void GooseAndXisheng()
    {
        //ϸ����콻������ɫ���߹�ȥ
        if (StaticClass.isMoveTarget2 == 1)
        {
            agent.SetDestination(goosePos.position);
            if (Vector3.Distance(goosePos.position, this.transform.position) <= 2)
            {
                MouseDrag.videoPlayer.clip = MouseDrag.videoPlayer.gameObject.GetComponent<VideoClips>().videoClips[1];
                MouseDrag.videoPlayer.Play();
                Goose.goose.SetBool("closelegs", true);
                StaticClass.isPlayerMove = false;
                StaticClass.isMoveTarget2 = 2;//��ֹ���ѭ������
                PlayerPrefs.SetInt("isGoose1", 2);
            }
        }
        //�ж���Ƶ�Ƿ񲥷����(ע�⣺һ��Ҫ����update���棬�ſ����ж���Ƶ��ǰ֡��)
        if (MouseDrag.videoPlayer != null)
        {
            if (MouseDrag.videoPlayer.isPlaying)
            {
                if ((int)MouseDrag.videoPlayer.frame >= (int)MouseDrag.videoPlayer.frameCount - 1)
                {
                    MouseDrag.videoPlayer.Stop();
                    ButtonManager.yumao.SetActive(true);
                    StaticClass.isPlayerMove = true;
                }
            }
        }
    }

    /// <summary>
    /// ˿����콻��
    /// </summary>
    private void GooseAndRibbon()
    {
        //˿����콻������ɫ���߹�ȥ
        if (StaticClass.isMoveTarget == 1)
        {
            agent.SetDestination(goosePos.position);
            if (Vector3.Distance(goosePos.position, this.transform.position) <= 2)
            {
                MouseDrag.videoPlayer.Play();
                Goose.goose.SetBool("closemouth", true);
                StaticClass.isPlayerMove = false;
                StaticClass.isMoveTarget = 2;//��ֹ���ѭ������
                PlayerPrefs.SetInt("isGoose1", 1);
            }
        }
        //�ж���Ƶ�Ƿ񲥷����(ע�⣺һ��Ҫ����update���棬�ſ����ж���Ƶ��ǰ֡��)
        if (MouseDrag.videoPlayer != null)
        {
            if (MouseDrag.videoPlayer.isPlaying)
            {
                if ((int)MouseDrag.videoPlayer.frame >= (int)MouseDrag.videoPlayer.frameCount - 3)
                {
                    MouseDrag.videoPlayer.Stop();
                    ButtonManager.note2.SetActive(true);
                    StaticClass.isPlayerMove = true;
                }
            }
        }
    }

    /// <summary>
    /// ����׶�
    /// </summary>
    private void ArriveDown()
    {
        Flip();
        player.gameObject.SetActive(true);
        rawmeatAnim.gameObject.SetActive(false);
    }

    /// <summary>
    /// ��תͼ��
    /// </summary>
    public void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
