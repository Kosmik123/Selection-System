using UnityEngine;

namespace SelectionSystem
{
    public abstract class PathfindingBehavior : MonoBehaviour
    {
        public abstract void SetTarget(Vector3 target); 
        public abstract bool IsOnTarget { get; }
    }
}
