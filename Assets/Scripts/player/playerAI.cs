
using UnityEngine;
using UnityEngine.AI;

///<summary>
///
///</summary>
class playerAI : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    private float mouseZ = 0;
    private Animator player;
    public float distance = 0.1f;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        player = this.transform.GetChild(0).GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, mouseZ); ;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (agent.isOnNavMesh)
        {
            if (Input.GetMouseButtonUp(0))
            {
                player.SetBool("startwalk",true);
                player.SetBool("walk",true);

                agent.SetDestination(target.position);
                
            }
            if (Vector3.Distance(target.position, this.transform.position) < distance)
            {
                player.SetBool("startwalk", false);
                player.SetBool("walk", false);
                player.SetBool("stop", true);
                player.SetBool("backidle", true);
            }
        }

    }
    /*public bool TestNavigation()
    {
        if (agent.isOnNavMesh)
        {
            NavMeshHit navigationHit;
            if (NavMesh.SamplePosition(this.transform.position, out navigationHit, 15, agent.areaMask))
                return agent.SetDestination(navigationHit.position);
            return false;
        }
        else
        {
            return agent.Warp(warpPosition);
        }
    }*/
}
