using UnityEngine;

namespace SelectionSystem
{
    public class Character : MonoBehaviour
    {
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
    }
}
