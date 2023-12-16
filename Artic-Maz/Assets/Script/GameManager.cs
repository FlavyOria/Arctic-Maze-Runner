using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagement
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private string mainMenuSceneName = "MainMenuScene";

        [SerializeField]
        private string gameplaySceneName = "GameplayScene";

        [SerializeField]
        private string initialLevelName = "Level0";

        public GameObject mainMenuUI;

        void Start()
        {
            LoadMainMenu();
        }

        void LoadMainMenu()
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }

        void ShowMainMenu()
        {
            mainMenuUI.SetActive(true);
        }

        public void StartGame()
        {
            SceneManager.LoadScene(Level0);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        public string MainMenuSceneName
        {
            get { return mainMenuSceneName; }
            set { mainMenuSceneName = value; }
        }

        public string Level0
        {
            get => Level0;
            set => Level0 = value; 
        }
    }
}