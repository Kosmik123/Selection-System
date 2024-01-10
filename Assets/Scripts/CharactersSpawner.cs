using UnityEngine;

namespace SelectionSystem
{
    public class CharactersSpawner : MonoBehaviour
    {
        [SerializeField] 
        private Character characterPrototype;
        [SerializeField]
        private CharacterSettings settings;
        [SerializeField]
        private Transform charactersContainer;

        public Character SpawnCharacter()
        {
            var character = Instantiate(characterPrototype, charactersContainer);
            float moveSpeed = settings.GetMoveSpeed();
            float rotationSpeed = settings.GetRotationSpeed();
            float endurance = settings.GetEndurance();
            character.Init(moveSpeed, rotationSpeed, endurance);
            character.name = $"{charactersContainer.childCount}";
            return character;
        }

        [ContextMenu("Spawn")]
        private void SpawnTest()
        {
            var character = SpawnCharacter();
            character.transform.position = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
        }
    }
}
