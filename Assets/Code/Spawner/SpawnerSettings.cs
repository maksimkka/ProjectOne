using System.Collections.Generic;
using UnityEngine;

namespace Code.Spawner
{
    public class SpawnerSettings : MonoBehaviour
    {
        [field: SerializeField] 
        public List<GameObject> ListEnemies { get; private set; }
        [field: SerializeField]
        public MeshRenderer PlaceSpawnObject { get; private set; }
        [field: SerializeField]
        public float SpawnTimeDelay { get; private set; }
    }
}