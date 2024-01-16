using System.Collections.Generic;

namespace SelectionSystem.Saving
{
    [System.Serializable]
    public class GameSaveData
    {
        public ObstaclesSaveData obstaclesSaveData;
        public CharactersSaveData charactersSaveData;
    }

    [System.Serializable]
    public abstract class SaveData
    {

    }
}
