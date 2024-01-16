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

        public Character SpawnRandomCharacter()
        {
            float moveSpeed = settings.GetMoveSpeed();
            float rotationSpeed = settings.GetRotationSpeed();
            float endurance = settings.GetEndurance();
            Vector2 flatPosition = 5 * Random.insideUnitCircle;
            var character = SpawnCharacter(flatPosition, moveSpeed, rotationSpeed, endurance);
            return character;
        }

        public Character SpawnCharacter(Vector2 flatPosition, float moveSpeed, float rotationSpeed, float endurance)
        {
            var character = Instantiate(characterPrototype, charactersContainer);
            character.Init(moveSpeed, rotationSpeed, endurance);
            character.name = $"{charactersContainer.childCount}";
            character.transform.position = new Vector3(flatPosition.x, 0, flatPosition.y);
            return character;
        }
    }
}
