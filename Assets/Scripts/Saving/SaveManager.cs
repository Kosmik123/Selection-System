using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SelectionSystem.Saving
{
    public class SaveManager : MonoBehaviour
    {
        public void SaveGame()
        {
            var allSavables = FindObjectsOfType<SavableBehavior>();
            var gameSaveData = new GameSaveData();
            foreach (var savable in allSavables)
            {
                var data = savable.GetSaveData();
                gameSaveData.saveDatas.Add(data);
            }

            var json = JsonUtility.ToJson(gameSaveData, true);
        }

    }
}
