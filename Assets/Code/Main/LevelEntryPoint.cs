using Code.HUD;
using Code.Spawner;
using UnityEngine;

namespace Code.Main
{
    public class LevelEntryPoint : MonoBehaviour
    {
        [SerializeField]
        private SpawnerSettings spawnerSettings;
        [SerializeField]
        private ScreenService screenService;

        private EnemySpawner enemySpawner;
        

        private void Awake()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            enemySpawner = new EnemySpawner(spawnerSettings);
            ScreenSwitcher.Initialize(screenService.screens);
            ScreenSwitcher.ShowScreen(ScreenType.Menu);
        }

        private void Update()
        {
            enemySpawner.SpawnEnemy();
        }
    }
}