using System.Collections.Generic;
using UnityEngine;

namespace SelectionSystem
{
    public class CharactersManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private int initialCharactersCount = 3;
        [SerializeField]
        private CharactersSpawner spawner;

        [Header("States")]
        [SerializeField]
        private List<Character> characters;

        private void Start()
        {
            for (int i = 0; i < initialCharactersCount; i++)
            {
                CreateNewCharacter();
            }
        }

        private void CreateNewCharacter()
        {
            var character = spawner.SpawnCharacter();
            Vector2 flatPosition = 5 * Random.insideUnitCircle;
            character.transform.position = new Vector3(flatPosition.x, 0, flatPosition.y);
            characters.Add(character);
        }
    }
}
