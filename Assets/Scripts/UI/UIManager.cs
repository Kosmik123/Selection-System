using System.Collections.Generic;
using UnityEngine;

namespace SelectionSystem.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private CharactersManager charactersManager;
        [SerializeField]
        private CharacterButton characterButtonPrototype;
        [SerializeField]
        private Transform buttonsContainer;

        [Header("States")]
        [SerializeField]
        private List<CharacterButton> characterButtons;

        private void OnEnable()
        {
            charactersManager.OnCharacterAdded += CreateButton;   
        }

        private void CreateButton(Character newCharacter)
        {
            var button = Instantiate(characterButtonPrototype, buttonsContainer);
            button.Character = newCharacter;
            characterButtons.Add(button);
        }

        private void OnDisable()
        {
            charactersManager.OnCharacterAdded -= CreateButton;   
        }
    }
}
