using UnityEngine;

namespace SelectionSystem
{
    public class Character : MonoBehaviour
    {
        [Header("To Link")]
        [SerializeField]
        private PathfindingBehavior pathfindingBehavior;

        [Header("Properties")]
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float rotationSpeed;
        [SerializeField]
        private float endurance;

        [Header("States")]
        [SerializeField]
        private Vector3 targetPosition;
        [SerializeField]
        private Character followedCharacter;

        public void Init(float moveSpeed, float rotationSpeed, float endurance)
        {
            this.moveSpeed = moveSpeed;
            this.rotationSpeed = rotationSpeed;
            this.endurance = endurance;
        }

        public void FollowCharacter(Character characterToFollow)
        {
            followedCharacter = characterToFollow;
        }

        public void SetTarget(Vector3 targetPosition)
        {
            followedCharacter = null;
            this.targetPosition = targetPosition;
            pathfindingBehavior.SetTarget(targetPosition);
        }

        private void Update()
        {
            if (followedCharacter && followedCharacter.pathfindingBehavior.IsOnTarget == false)
                pathfindingBehavior.SetTarget(followedCharacter.transform.position);
        }
    }
}
