using UnityEngine;

namespace SelectionSystem.Saving
{
    public abstract class SavableBehavior : MonoBehaviour
    {
        public abstract SaveData GetSaveData();
        public abstract void SetSaveData(SaveData data);
    }
}
