using UnityEngine;

namespace SelectionSystem
{
    public interface IPositionProvider
    {
        bool TryGetPosition(out Vector3 position);
    }
}
