using System;
using System.Collections.Generic;
using Code.Spawner;
using UnityEngine;

namespace Code.Main
{
    public class LevelEntryPoint : MonoBehaviour
    {
        [SerializeField]
        private SpawnerSettings spawnerSettings;

        private EnemySpawner enemySpawner;
        

        private void Awake()
        {
            enemySpawner = new EnemySpawner(spawnerSettings);
        }

        private void Update()
        {
            enemySpawner.SpawnEnemy();
        }
    }
}