using UnityEngine;

namespace SelectionSystem
{
    public interface IPositionProvider
    {
        bool TryGetPosition(out Vector3 position);
    }

    public abstract class PositionProvider : MonoBehaviour, IPositionProvider
    {
        public abstract bool TryGetPosition(out Vector3 position);
    }
}
