using UnityEngine;
using UnityEngine.UI;

namespace SelectionSystem.UI
{
    [RequireComponent(typeof(Button))]
    public class CharacterButton : MonoBehaviour
    {
        public event System.Action<Character> OnCharacterChosen;

        private Button _button;
        public Button Button
        {
            get
            {
                if ( _button == null )
                    _button = GetComponent<Button>();
                return _button;
            }
        }

        [Header("To Link")]
        [SerializeField]
        private TMPro.TMP_Text label;

        [Header("Properties")]
        [SerializeField]
        private Character character;
        public Character Character
        {
            get => character;
            set
            {
                character = value;
                label.text = character.name;
            }
        }

        [SerializeField]
        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                Button.interactable = !isSelected;
                if (isSelected)
                    label.fontStyle |= TMPro.FontStyles.Bold;
                else
                    label.fontStyle &= ~TMPro.FontStyles.Bold;
            }
        }

        private void OnEnable()
        {
            Button.onClick.AddListener(Button_OnClick);       
        }

        private void Button_OnClick()
        {
            OnCharacterChosen?.Invoke(character);
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(Button_OnClick);       
        }
    }
}
