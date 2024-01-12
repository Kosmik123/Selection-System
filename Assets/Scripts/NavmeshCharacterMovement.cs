using UnityEngine;
using UnityEngine.AI;

namespace SelectionSystem
{
    public class NavmeshCharacterMovement : CharacterMovement
    {
        [SerializeField]
        private NavMeshAgent agent;

        public override bool IsOnTarget => agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance < 0.1f;

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

        public override void SetTarget(Vector3 target)
        {
            agent.destination = target;
        }
    }
}
