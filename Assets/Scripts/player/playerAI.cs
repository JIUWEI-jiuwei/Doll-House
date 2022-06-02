
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
    private void Start()
    {
        //关于agent
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        /// <summary>获取真正的角色的动画</summary>
        player = this.transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        //将鼠标位置设定为target
        target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, mouseZ); ;

        if (agent.isOnNavMesh)
        {
            //开始走路
            if (Input.GetMouseButtonUp(0)&&StaticClass.isPlayerMove)
            {
                player.SetBool("startwalk",true);
                player.SetBool("walk",true);

                agent.SetDestination(target.position);
                StaticClass.isFinishedMove = false;
            }
            //结束走路
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
