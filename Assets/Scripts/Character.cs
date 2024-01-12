using UnityEngine;

namespace SelectionSystem
{
    public class Character : MonoBehaviour
    {
        [Header("To Link")]
        [SerializeField]
        private CharacterMovement movement;

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
            movement.MoveSpeed = this.moveSpeed = moveSpeed;
            movement.RotationSpeed = this.rotationSpeed = rotationSpeed;
            this.endurance = endurance;
        }

        public void FollowCharacter(Character characterToFollow)
        {
            followedCharacter = characterToFollow;
        }

        public void SetTarget(Vector3 target)
        {
            followedCharacter = null;
            targetPosition = target;
            movement.SetTarget(targetPosition);
        }

        private void Update()
        {
            if (followedCharacter)
            {
                if (followedCharacter.movement.IsOnTarget == false)
                {
                    movement.SetTarget(followedCharacter.transform.position);
                }
            }
        }
    }
}
