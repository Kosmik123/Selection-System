using UnityEngine;

namespace SelectionSystem.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private CharactersManager charactersManager;

        private void OnEnable()
        {
            charactersManager.OnCharacterAdded += CharactersManager_OnCharacterAdded;   
        }

        private void CharactersManager_OnCharacterAdded(Character newCharacter)
        {

        }

        private void OnDisable()
        {
            charactersManager.OnCharacterAdded -= CharactersManager_OnCharacterAdded;   
        }
    }
}
