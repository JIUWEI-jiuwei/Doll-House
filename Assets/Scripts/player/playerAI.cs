
using UnityEngine;
using UnityEngine.AI;

///<summary>
///
///</summary>
class playerAI : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    private void Update()
    {
        if (agent.isOnNavMesh)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            
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
