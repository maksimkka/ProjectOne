using System.Collections.Generic;

namespace Code.HUD
{
    public static class ScreenSwitcher
    {
        private static List<ScreenView> screens;
        private static ScreenType currentScreenType;

        public static void Initialize(List<ScreenView> screenList)
        {
            screens = screenList;
            HideAllScreens();
        }

        public static void ShowScreen(ScreenType screenType)
        {
            for (int i = 0; i < screens.Count; i++)
            {
                if (screens[i].type == screenType)
                {
                    screens[i].gameObject.SetActive(true);
                }
                else
                {
                    screens[i].gameObject.SetActive(false);
                }
            }
        }

        public static ScreenType GetCurrentScreen()
        {
            foreach (var screen in screens)
            {
                if (screen.gameObject.activeSelf)
                {
                    currentScreenType = screen.type;
                    break;
                }
            }

            return currentScreenType;
        }

        public static void HideAllScreens()
        {
            foreach (var screen in screens)
            {
                screen.gameObject.SetActive(false);
            }
        }
    }
}