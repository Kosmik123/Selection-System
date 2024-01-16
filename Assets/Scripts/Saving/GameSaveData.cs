using System.Collections.Generic;

namespace SelectionSystem.Saving
{
    [System.Serializable]
    public class GameSaveData
    {
        private List<SaveData> saveDatas =new List<SaveData>();
        public List<SaveData> SaveDatas
        {
            get => saveDatas;
            set => saveDatas = value;   
        }
    }

    [System.Serializable]
    public abstract class SaveData
    {

    }
}
