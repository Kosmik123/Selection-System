using SelectionSystem.Saving;
using System.Collections;
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
                float angle = Random.Range(0, 360);

                CreateObstacle(x, z, xScale, zScale, angle);
            }
            navMeshSurface.BuildNavMesh();
        }

        private void CreateObstacle(float x, float z, float xScale, float zScale, float angle)
        {
            var obstacle = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obstacle.transform.parent = transform;
            obstacle.transform.SetPositionAndRotation(new Vector3(x, 0.5f, z), Quaternion.AngleAxis(angle, Vector3.up));
            obstacle.transform.localScale = new Vector3(xScale, 1, zScale);
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

        public override void SetSaveData(SaveData data)
        {
            if (data is ObstaclesSaveData obstaclesSaveData)
            {
                ClearObstacles();
                foreach (var obstacleData in obstaclesSaveData.obstacles)
                {
                    CreateObstacle(obstacleData.position.x, obstacleData.position.y,
                        obstacleData.scale.x, obstacleData.scale.y, obstacleData.angle);
                }
                StartCoroutine(BakeNavMeshAfterFrame());
            }
        }

        private IEnumerator BakeNavMeshAfterFrame()
        {
            yield return null;
            navMeshSurface.BuildNavMesh();
        }

        private void ClearObstacles()
        {
            var allChildren = transform.GetComponentsInChildren<Transform>();
            foreach (var obstacle in allChildren)
                if (obstacle != transform)
                    Destroy(obstacle.gameObject);
        }
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
