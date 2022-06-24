using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

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
        //�����λ���趨Ϊtarget
        target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, mouseZ); ;
        if (agent.isOnNavMesh)
        {
            //��ʼ��·
            if (Input.GetMouseButtonUp(0) && StaticClass.isPlayerMove == true)
            {
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
            //������·
            if (Vector3.Distance(target.position, this.transform.position) <= distance)
            {
                playerEnd.SetBool("beginWalk", false);
                StaticClass.isFinishedMove = true;
            }
            /*else if(Vector3.Distance(target.position, this.transform.position) <= distance)
            {
                
            }*/
            else if (Vector3.Distance(target.position, this.transform.position) >= distance+2)
            {
                StaticClass.isFinishedMove = false;
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
