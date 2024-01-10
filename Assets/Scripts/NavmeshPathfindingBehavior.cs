using UnityEngine;
using UnityEngine.AI;

namespace SelectionSystem
{
    public class NavmeshPathfindingBehavior : PathfindingBehavior
    {
        [SerializeField]
        private NavMeshAgent agent;

        public override bool IsOnTarget => agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance < 0.1f;

        public override void SetTarget(Vector3 target)
        {
            agent.destination = target;
        }
    }
}
