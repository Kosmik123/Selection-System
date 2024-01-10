using System.Collections.Generic;
using UnityEngine;

namespace SelectionSystem
{
    public class CharactersManager : MonoBehaviour
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
    }
}
