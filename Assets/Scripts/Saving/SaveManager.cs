using System.IO;
using System.Threading.Tasks;
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
            WriteToSaveFile(json);
        }

        private async void WriteToSaveFile(string jsonData)
        {
            using (var writer = new StreamWriter(SavesPath))
            {
                await writer.WriteAsync(jsonData);
            }
            OnGameSaved?.Invoke();
        }

        [ContextMenu("Load")]
        public async void LoadGame()
        {
            using var reader = new StreamReader(SavesPath);
            var task = reader.ReadToEndAsync();
            var allSavables = FindObjectsOfType<SavableBehavior>();
            string json = await task;
            var gameSaveData = JsonUtility.FromJson<GameSaveData>(json);
            foreach (var savable in allSavables)
            {
                if (savable is CharactersManager charactersManager)
                    charactersManager.SetSaveData(gameSaveData.charactersSaveData);
                else if (savable is RandomObstaclesSpawner obstaclesSpawner)
                    obstaclesSpawner.SetSaveData(gameSaveData.obstaclesSaveData);
            }
        }
    }
}
