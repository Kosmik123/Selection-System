using SelectionSystem.Saving;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

namespace SelectionSystem
{
    public class RandomObstaclesSpawner : SavableBehavior
    {
        [SerializeField]
        private int obstaclesCount = 10;
        [SerializeField]
        private NavMeshSurface navMeshSurface;

        public void CreateRandomEnvironment()
        {
            for (int i = 0; i < obstaclesCount; i++)
            {
                float x = GetRandomValueOnTestPlane();
                float z = GetRandomValueOnTestPlane();
                float xScale = Random.Range(1f, 5f);
                float zScale = Random.Range(1f, 5f);

                var obstacle = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obstacle.transform.parent = transform;
                obstacle.transform.SetPositionAndRotation(new Vector3(x, 0.5f, z), Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up));
                obstacle.transform.localScale = new Vector3(xScale, 1, zScale);
            }
            navMeshSurface.BuildNavMesh();
        }

        private static float GetRandomValueOnTestPlane()
        {
            return Random.Range(2f, 50f) * RandomSign();
        }

        private static int RandomSign()
        {
            return 2 * Random.Range(0, 2) - 1;
        }

        public override SaveData GetSaveData()
        {
            var saveData = new ObstaclesSaveData();
            for (int i = 0; i < transform.childCount; i++)
            {
                var obstacle = transform.GetChild(i);
                var data = ObstacleData.FromTransform(obstacle);
                saveData.obstacles.Add(data);
            }
            return saveData;
        }

        [System.Serializable]
        public class ObstaclesSaveData : SaveData
        {
            public List<ObstacleData> obstacles = new List<ObstacleData>();
        }

        [System.Serializable]
        public struct ObstacleData
        {
            public Vector2 position;
            public Vector2 scale;
            public float angle;

            public static ObstacleData FromTransform(Transform transform)
            {
                var obstacleData = new ObstacleData()
                {
                    position = new Vector2(transform.position.x, transform.position.z),
                    scale = new Vector2(transform.localScale.x, transform.localScale.z),
                    angle = transform.rotation.eulerAngles.y
                };
                return obstacleData;
            }
        }
    }
}
