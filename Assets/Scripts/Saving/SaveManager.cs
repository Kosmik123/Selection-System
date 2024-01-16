using System.IO;
using UnityEngine;

namespace SelectionSystem.Saving
{
    public class SaveManager : MonoBehaviour
    {
        public event System.Action OnGameSaved;

        private static string SavesPath => $"{Application.persistentDataPath}/Save0.sav";

        [ContextMenu("Save")]
        public void SaveGame()
        {
            var allSavables = FindObjectsOfType<SavableBehavior>();
            var gameSaveData = new GameSaveData();
            foreach (var savable in allSavables)
            {
                var data = savable.GetSaveData();
                if (data is CharactersSaveData charactersSaveData)
                    gameSaveData.charactersSaveData = charactersSaveData;
                else if (data is ObstaclesSaveData obstaclesSaveData)
                    gameSaveData.obstaclesSaveData = obstaclesSaveData;
            }

            var json = JsonUtility.ToJson(gameSaveData);
            SaveToFile(json);
        }

        private async void SaveToFile(string jsonData)
        {
            using (var writer = new StreamWriter(SavesPath))
            {
                await writer.WriteAsync(jsonData);
            }
            OnGameSaved?.Invoke();
        }
    }
}
