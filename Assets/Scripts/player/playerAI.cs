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
        //rawmeatAnim.gameObject.SetActive(false);
    }

    private void Update()
    {
        //�����λ���趨Ϊtarget
        target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, mouseZ); ;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.name);
        }
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
                            {
                                player.gameObject.SetActive(false);
                                rawmeatAnim.gameObject.SetActive(true);
                            }
                            if (rawmeatAnim.GetCurrentAnimatorStateInfo(0).IsName("climbstop"))
                            {
                                Destroy(hit.collider.gameObject);
                                ItemPanelClick.ChangeItemPanel(hit.collider.gameObject.name);

                                rawmeatAnim.SetBool("reverse", true);
                            }
                            if (rawmeatAnim.GetCurrentAnimatorStateInfo(0).IsName("reversestop"))
                            {
                                player.gameObject.SetActive(true);
                                rawmeatAnim.gameObject.SetActive(false);
                            }
                        }
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
                else if(target.position.x < this.gameObject.transform.position.x && !m_FacingRight)
                {
                    Flip();
                }
            }
            //������·
            if (Vector3.Distance(target.position, this.transform.position) <= distance)
            {
                player.SetBool("startwalk", false);
                player.SetBool("walk", false);
                player.SetBool("stop", true);
                player.SetBool("backidle", true);
                StaticClass.isFinishedMove = true;
            }
            else if (Vector3.Distance(target.position, this.transform.position) >= distance+2)
            {

                StaticClass.isFinishedMove = false;
            }
        }


        //��콻������ɫ���߹�ȥ
        if (StaticClass.isMoveTarget==1)
        {
            agent.SetDestination(goosePos.position);
            if(Vector3.Distance(goosePos.position, this.transform.position) <= distance)
            {
                StaticClass.isMoveTarget = 2;
            }            
        }

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
