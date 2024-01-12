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

        public float enduranceTimer;

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
            movement.enabled = true;
            enduranceTimer = 0;
        }

        public void SetTarget(Vector3 target)
        {
            followedCharacter = null;
            targetPosition = target;
            movement.enabled = true;
            enduranceTimer = 0;
            movement.SetTarget(targetPosition);
        }

        private void Update()
        {
            if (followedCharacter)
                UpdateFollowing();

            if (movement.IsOnTarget == false)
                UpdateEndurance();
        }

        private void UpdateFollowing()
        {
            if (followedCharacter.movement.IsOnTarget == false)
            {
                movement.SetTarget(followedCharacter.transform.position);
            }
        }

        private void UpdateEndurance()
        {
            enduranceTimer += Time.deltaTime;
            if (enduranceTimer > endurance)
            {
                enduranceTimer = 0;
                movement.enabled = !movement.enabled;
            }
        }
    }
}
