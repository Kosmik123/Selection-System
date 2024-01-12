using UnityEngine;
using UnityEngine.AI;

namespace SelectionSystem
{
    public class NavmeshCharacterMovement : CharacterMovement
    {
        [SerializeField]
        private NavMeshAgent agent;

        public override bool IsOnTarget => agent.hasPath && agent.remainingDistance < agent.stoppingDistance;

        public override float MoveSpeed 
        { 
            get => agent.speed;
            set => agent.speed = value;
        }

        public override float RotationSpeed 
        {
            get => agent.angularSpeed; 
            set => agent.angularSpeed = value;
        }

        private void OnEnable()
        {
            agent.isStopped = false;
        }

        public override void SetTarget(Vector3 target)
        {
            agent.destination = target;
        }

        private void OnDisable()
        {
            agent.isStopped = true;
        }
    }
}
