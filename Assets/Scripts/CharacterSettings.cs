using UnityEngine;

namespace SelectionSystem
{
    [CreateAssetMenu]
    public class CharacterSettings : ScriptableObject
    {
        [SerializeField]
        private float minMoveSpeed;
        [SerializeField]
        private float maxMoveSpeed;
        [SerializeField]
        private float minRotationSpeed;
        [SerializeField]
        private float maxRotationSpeed;
        [SerializeField]
        private float minEndurance;
        [SerializeField]
        private float maxEndurance;

        public float GetMoveSpeed() => GetRandom(minMoveSpeed, maxMoveSpeed);   
        public float GetRotationSpeed() => GetRandom(minRotationSpeed, maxRotationSpeed);
        public float GetEndurance() => GetRandom(minEndurance, maxEndurance);

        private float GetRandom(float min, float max)
        {
            return Random.Range(min, max);
        }
    }
}
