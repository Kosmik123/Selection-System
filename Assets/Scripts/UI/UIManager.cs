using System;
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
            charactersManager.OnCharacterSelected += RefreshButtonsSelection;
            charactersManager.OnCharacterRemoved += RemoveButton;
        }

        private void CreateButton(Character newCharacter)
        {
            var button = Instantiate(characterButtonPrototype, buttonsContainer);
            button.Character = newCharacter;
            characterButtons.Add(button);
            button.OnCharacterChosen += Button_OnCharacterChosen;
        }

        private void Button_OnCharacterChosen(Character character)
        {
            charactersManager.SelectCharacter(character);
        }

        private void RefreshButtonsSelection(Character character)
        {
            foreach (var button in characterButtons)
            {
                button.IsSelected = button.Character == character;
            }    
        }

        private void RemoveButton(Character character)
        {
            for (int i = 0; i < characterButtons.Count; i++)
            {
                if (characterButtons[i].Character == character)
                {
                    Destroy(characterButtons[i].gameObject);
                    characterButtons.RemoveAt(i);
                    break;
                }
            }
        }

        private void OnDisable()
        {
            charactersManager.OnCharacterSelected -= RefreshButtonsSelection;
            charactersManager.OnCharacterAdded -= CreateButton;
            charactersManager.OnCharacterRemoved -= RemoveButton;
        }
    }
}
