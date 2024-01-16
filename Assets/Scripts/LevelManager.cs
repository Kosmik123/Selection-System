using UnityEngine;

namespace SelectionSystem
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private RandomObstaclesSpawner environmentManager;

        [SerializeField]
        private CharactersManager charactersManager;

        private void Start()
        {
            environmentManager.CreateRandomEnvironment();
            charactersManager.CreateRandomCharacters();
        }
    }
}
