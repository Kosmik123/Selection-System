using System;
using UnityEngine;

namespace SelectionSystem
{
    public abstract class ClickProvider : MonoBehaviour
    {
        public abstract event Action OnClicked;
    }
}
