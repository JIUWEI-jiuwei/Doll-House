using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

///<summary>
///
///</summary>
class PlayerEnd : MonoBehaviour
{
    /// <summary>player追踪的目标</summary>
    [SerializeField] Transform target;
    /// <summary>角色agent</summary>
    NavMeshAgent agent;

    /// <summary>将agent和target的z轴都设定为一个值（否则判定不到）</summary>
    private float mouseZ = 0;
    /// <summary>角色的动画</summary>
    public Animator playerEnd;
    /// <summary>角色和目标之间的距离</summary>
    public float distance = 1f;
    /// <summary>面向右边</summary>
    public bool m_FacingRight = true;
    public float x = 0.5f;
    public VideoPlayer videoPlayer;

    private void Start()
    {
        //关于agent
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        StaticClass.isFinishedMove = false;
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.name == "father")
            {
                videoPlayer.Play();
                AudioManager2.audioSource2.Stop();
            }
        }
        if (videoPlayer != null)
        {
            if (videoPlayer.isPlaying)
            {
                if ((int)videoPlayer.frame >= (int)videoPlayer.frameCount - 3)
                {
                    SceneManager.LoadSceneAsync("CurtainCall");
                }
            }
        }
        
        //将鼠标位置设定为target
        if (agent.isOnNavMesh)
        {
            //开始走路
            if (Input.GetMouseButtonUp(0) && StaticClass.isPlayerMove == true)
            {
                target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, mouseZ); ;
                playerEnd.SetBool("beginWalk", true);
                agent.SetDestination(target.position);
                StaticClass.isFinishedMove = false;
                //转向
                if (target.position.x >= this.gameObject.transform.position.x && m_FacingRight)//向右
                {
                    Flip();
                }
                else if (target.position.x < this.gameObject.transform.position.x && !m_FacingRight)
                {
                    Flip();
                }
            }
            //Debug.Log("agent.velocity.x+" + agent.velocity.x);
            //Debug.Log("agent.velocity+" + agent.velocity);
            //结束走路
            if (Vector3.Distance(target.position, this.transform.position) <= distance)//|| Mathf.Abs(agent.velocity.x) <= x
            {
                playerEnd.SetBool("beginWalk", false);
                StaticClass.isFinishedMove = true;
            }            
            /*else if(Vector3.Distance(target.position, this.transform.position) <= distance)
            {
                
            }*/
            /*else if (Vector3.Distance(target.position, this.transform.position) >= distance+2)
            {
                StaticClass.isFinishedMove = false;
            }*/

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
