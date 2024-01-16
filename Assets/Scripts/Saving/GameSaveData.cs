using System.Collections.Generic;
using UnityEngine;

namespace SelectionSystem.Saving
{
    [System.Serializable]
    public class GameSaveData
    {
        public List<SaveData> saveDatas = new List<SaveData>();
    }

    [System.Serializable]
    public abstract class SaveData
    {

    }
}
