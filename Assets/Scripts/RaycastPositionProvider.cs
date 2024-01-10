using UnityEngine;

namespace SelectionSystem
{
    public class RaycastPositionProvider : MonoBehaviour, IPositionProvider
    {
        [SerializeField]
        private LayerMask detectedLayers;

        public bool TryGetPosition(out Vector3 position)
        {
            position = default;
            var camera = Camera.main;
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo, camera.farClipPlane, detectedLayers))
                position = hitInfo.point;

            return position != default;
        }
    }
}
