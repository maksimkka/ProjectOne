using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Spawner
{
    public class EnemySpawner
    {
        // [SerializeField] 
        // private List<GameObject> ListEnemies;
        // [SerializeField]
        // private MeshRenderer PlaceSpawnObject;
        // [SerializeField]
        // private float SpawnTimeDelay;
        // [SerializeField]
        // private int MaxCountSpawnEnemies;
        private readonly SpawnerSettings spawnerSettings;
        
        private int currentSpawnEnemies;
        private float timerElapsed;

        public EnemySpawner(SpawnerSettings spawnerSettings)
        {
            this.spawnerSettings = spawnerSettings;
        }

        public void SpawnEnemy()
        {
            timerElapsed += Time.deltaTime;

            if (!(timerElapsed >= spawnerSettings.SpawnTimeDelay)) return;
            timerElapsed = 0;
            SpawnObjects(spawnerSettings.PlaceSpawnObject);
        }
        
        private void SpawnObjects(MeshRenderer plane)
        {
            var randomEnemyIndex = Random.Range(0, spawnerSettings.ListEnemies.Count);
            var spawnPosition = GetRandomSpawnPosition(plane);
            Object.Instantiate(spawnerSettings.ListEnemies[randomEnemyIndex], spawnPosition, Quaternion.identity);
        }

        private Vector3 GetRandomSpawnPosition(MeshRenderer plane)
        {
            var planeSize = plane.bounds;
            float randomX = Random.Range(planeSize.min.x, planeSize.max.x);
            float randomZ = Random.Range(planeSize.min.z, planeSize.max.z);

            return new Vector3(randomX, 0f, randomZ);
        }
    }
}