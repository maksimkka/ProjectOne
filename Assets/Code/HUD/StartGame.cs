using UnityEngine;
using UnityEngine.UI;

namespace Code.HUD
{
    public class StartGame : MonoBehaviour
    {
        private Button startGameButton;

        private void Awake()
        {
            startGameButton = gameObject.GetComponent<Button>();
            startGameButton.onClick.AddListener(PlayGame);
        }

        private void PlayGame()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            ScreenSwitcher.ShowScreen(ScreenType.Game);
        }
    }
}