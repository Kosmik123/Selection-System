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

        [SerializeField]
        private Character character;
        public Character Character
        {
            get => character;
            set => character = value;
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
