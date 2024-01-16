using SelectionSystem.Saving;
using System.Collections.Generic;
using UnityEngine;

namespace SelectionSystem
{
    public class CharactersManager : SavableBehavior
    {
        public event System.Action<Character> OnCharacterAdded;
        public event System.Action<Character> OnCharacterSelected;

        [Header("Settings")]
        [SerializeField]
        private int initialCharactersCount = 3;
        [SerializeField]
        private CharactersSpawner spawner;
        [SerializeField]
        private PositionProvider positionProvider;
        [SerializeField]
        private ClickProvider clickProvider;

        [Header("States")]
        [SerializeField]
        private List<Character> characters;
        [SerializeField]
        private Character selectedCharacter;

        private void OnEnable()
        {
            clickProvider.OnClicked += ClickProvider_OnClicked;
        }

        public void CreateRandomCharacters()
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
            OnCharacterAdded?.Invoke(character);
        }

        public void SelectCharacter(Character character)
        {
            selectedCharacter = character;
            OnCharacterSelected?.Invoke(character);
        }

        private void ClickProvider_OnClicked()
        {
            if (positionProvider.TryGetPosition(out var position))
            {
                Debug.Log(position);
                Debug.DrawLine(position, position + Vector3.up, Color.red, 5);

                foreach (var character in characters)
                {
                    if (character == selectedCharacter)
                    {
                        character.SetTarget(position);
                    }
                    else
                    {
                        character.FollowCharacter(selectedCharacter);
                    }
                }
            }
        }

        private void OnDisable()
        {
            clickProvider.OnClicked -= ClickProvider_OnClicked;
        }

        public override SaveData GetSaveData()
        {
            var saveData = new CharactersSaveData();
            for (int i = 0 ; i < characters.Count; i++) 
            {
                var character = characters[i];
                if (character == selectedCharacter)
                    saveData.selectedCharacterIndex = i;

                var characterData = CharacterData.FromCharacter(character);
                saveData.characterDatas.Add(characterData);
            }
            return saveData;
        }
    }

    [System.Serializable]
    public class CharactersSaveData : SaveData
    {
        public List<CharacterData> characterDatas = new List<CharacterData>();
        public int selectedCharacterIndex = -1;
    }

    [System.Serializable]
    public struct CharacterData
    {
        public Vector2 position;
        public float moveSpeed;
        public float rotationSpeed;
        public float endurance;
        public float currentEndurance;

        public static CharacterData FromCharacter(Character character)
        {
            return new CharacterData()
            {
                position = new Vector2(character.transform.position.x, character.transform.position.z),
                moveSpeed = character.MoveSpeed,
                rotationSpeed = character.RotationSpeed,
                endurance = character.Endurance,
                currentEndurance = character.CurrentEndurance
            };
        }
    }
}
