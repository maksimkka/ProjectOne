using Code.Logger;
using UnityEngine;

namespace Code.HUD
{
    public class Pause : MonoBehaviour
    {
        private bool isPause;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && ScreenSwitcher.GetCurrentScreen() != ScreenType.Menu)
            {
                isPause = !isPause;
                if (isPause)
                {
                    PauseGame();
                }
                else
                {
                    UnPauseGame();
                }
            }
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            ScreenSwitcher.ShowScreen(ScreenType.Pause);
        }

        private void UnPauseGame()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            ScreenSwitcher.ShowScreen(ScreenType.Game);
        }
    }
}