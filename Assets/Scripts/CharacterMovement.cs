using UnityEngine;

namespace SelectionSystem
{
    public abstract class CharacterMovement : MonoBehaviour
    {
        public abstract float MoveSpeed { get; set; }
        public abstract float RotationSpeed { get; set; }
        public abstract void SetTarget(Vector3 target); 
        public abstract bool IsOnTarget { get; }
    }
}
