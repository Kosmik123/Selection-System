using System;
using Unity.VisualScripting;
using UnityEngine;

namespace SelectionSystem
{
    public class InputManagerClickProvider : ClickProvider
    {
        public override event Action OnClicked;

        [SerializeField]
        private MouseButton mouseButton;

        private bool isPressed;

        private void Update()
        {
            if (Input.GetMouseButtonDown((int)mouseButton))
            {
                isPressed = true;
            }
            else if (isPressed &&  Input.GetMouseButtonUp((int)mouseButton)) 
            {
                isPressed = false;
                OnClicked?.Invoke();
            }
        }
    }
}
