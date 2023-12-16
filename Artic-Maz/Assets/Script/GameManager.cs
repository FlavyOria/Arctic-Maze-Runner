using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagement
{
    public class GameManager : MonoBehaviour
    {
        // The name of your main menu scene
        [SerializeField]
        private string mainMenuSceneName = "MainMenuScene";

        // The name of your gameplay scene
        [SerializeField]
        private string gameplaySceneName = "GameplayScene";

        // The name of the level to load when the game starts
        [SerializeField]
        private string initialLevelName = "Level0";

        // Reference to the main menu UI
        public GameObject mainMenuUI;

        void Start()
        {
            // Load the main menu scene when the game starts
            LoadMainMenu();
        }

        // Method to load the main menu scene
        void LoadMainMenu()
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }

        // Method to show the main menu
        void ShowMainMenu()
        {
            mainMenuUI.SetActive(true);
        }

        // Method to start the game
        public void StartGame()
        {
            // Load the initial level when the player chooses to play
            SceneManager.LoadScene(Level0);
        }

        // Method to quit the game
        public void QuitGame()
        {
            // Quit the application (only works in standalone builds)
            Application.Quit();
        }

        // Properties for accessing the private string variables
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