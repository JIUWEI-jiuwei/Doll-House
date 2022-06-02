
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
    private void Start()
    {
        //����agent
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        /// <summary>��ȡ�����Ľ�ɫ�Ķ���</summary>
        player = this.transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        //�����λ���趨Ϊtarget
        target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, mouseZ); ;

        if (agent.isOnNavMesh)
        {
            //��ʼ��·
            if (Input.GetMouseButtonUp(0)&&StaticClass.isPlayerMove)
            {
                player.SetBool("startwalk",true);
                player.SetBool("walk",true);

                agent.SetDestination(target.position);
                StaticClass.isFinishedMove = false;
            }
            //������·
            if (Vector3.Distance(target.position, this.transform.position) < distance)
            {
                player.SetBool("startwalk", false);
                player.SetBool("walk", false);
                player.SetBool("stop", true);
                player.SetBool("backidle", true);
                StaticClass.isFinishedMove = true;
            }
        }

    }
}
