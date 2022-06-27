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
    /// <summary>player׷�ٵ�Ŀ��</summary>
    [SerializeField] Transform target;
    /// <summary>��ɫagent</summary>
    NavMeshAgent agent;

    /// <summary>��agent��target��z�ᶼ�趨Ϊһ��ֵ�������ж�������</summary>
    private float mouseZ = 0;
    /// <summary>��ɫ�Ķ���</summary>
    public Animator playerEnd;
    /// <summary>��ɫ��Ŀ��֮��ľ���</summary>
    public float distance = 1f;
    /// <summary>�����ұ�</summary>
    public bool m_FacingRight = true;
    public float x = 0.5f;
    public VideoPlayer videoPlayer;

    private void Start()
    {
        //����agent
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
                AudioManager.audioSource.Stop();
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
        
        //�����λ���趨Ϊtarget
        if (agent.isOnNavMesh)
        {
            //��ʼ��·
            if (Input.GetMouseButtonUp(0) && StaticClass.isPlayerMove == true)
            {
                target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, mouseZ); ;
                playerEnd.SetBool("beginWalk", true);
                agent.SetDestination(target.position);
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
            //Debug.Log("agent.velocity.x+" + agent.velocity.x);
            //Debug.Log("agent.velocity+" + agent.velocity);
            //������·
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
