using System;
using UnityEngine.EventSystems;

namespace SelectionSystem
{
    public class WalkableSurfaceClickProvider : ClickProvider, IPointerClickHandler
    {
        public override event Action OnClicked; 
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke();
        }
    }
}
