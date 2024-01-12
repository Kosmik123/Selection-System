using UnityEngine;

namespace SelectionSystem
{
    public class Character : MonoBehaviour
    {
        [Header("To Link")]
        [SerializeField]
        private CharacterMovement movement;

        [Header("Settings"), Tooltip("Distance from followed character to stop movement if followed character is on target")]
        [SerializeField]
        private float stoppingDistance;

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

        [SerializeField]
        private bool isMoving;

        public void Init(float moveSpeed, float rotationSpeed, float endurance)
        {
            movement.MoveSpeed = this.moveSpeed = moveSpeed;
            movement.RotationSpeed = this.rotationSpeed = rotationSpeed;
            this.endurance = endurance;
        }

        public void FollowCharacter(Character characterToFollow)
        {
            isMoving = true;
            followedCharacter = characterToFollow;
        }

        public void SetTarget(Vector3 target)
        {
            isMoving = true;
            followedCharacter = null;
            targetPosition = target;
            movement.SetTarget(targetPosition);
        }

        private void Update()
        {
            if (isMoving == false)
                return;

            if (followedCharacter)
            {
                if (followedCharacter.movement.IsOnTarget == false)
                {
                    movement.SetTarget(followedCharacter.transform.position);
                }
                else if (Vector3.Distance(followedCharacter.transform.position, transform.position) < stoppingDistance)
                {
                    movement.SetTarget(transform.position);
                }
            }

            if (movement.IsOnTarget)
                isMoving = false;
        }
    }
}
