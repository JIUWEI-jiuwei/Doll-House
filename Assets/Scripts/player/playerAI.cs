using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

///<summary>
///2D角色自动寻路脚本
///</summary>
class playerAI : MonoBehaviour
{
    /// <summary>player追踪的目标</summary>
    [SerializeField] Transform target;
    /// <summary>角色agent</summary>
    NavMeshAgent agent;

    /// <summary>将agent和target的z轴都设定为一个值（否则判定不到）</summary>
    private float mouseZ = 0;
    /// <summary>角色的动画</summary>
    public static Animator player;
    /// <summary>角色和目标之间的距离</summary>
    public float distance = 1f;
    public Transform rawmeatPos;
    public Animator rawmeatAnim;
    /// <summary>面向右边</summary>
    public bool m_FacingRight = true;
    public Transform goosePos;
    public Transform catPos;


    private void Start()
    {
        //关于agent
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        /// <summary>获取真正的角色的动画</summary>
        player = this.transform.GetChild(0).GetComponent<Animator>();
        StaticClass.isFinishedMove = false;
        //rawmeatAnim.gameObject.SetActive(false);
    }

    private void Update()
    {
        //将鼠标位置设定为target
        target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, mouseZ); ;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.name);
        }
        if (agent.isOnNavMesh)
        {
            //开始走路
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

                //转向

                if (target.position.x >= this.gameObject.transform.position.x && m_FacingRight)//向右
                {
                    Flip();
                }
                else if(target.position.x < this.gameObject.transform.position.x && !m_FacingRight)
                {
                    Flip();
                }
            }
            //结束走路
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


        //与鹅交互，角色先走过去
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
    /// 翻转图像
    /// </summary>
    public void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
