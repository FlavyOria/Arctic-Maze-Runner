using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    private void Start()
    {
        // Attach the button click listeners
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        // Load the game scene (replace "GameScene" with your actual game scene name)
        SceneManager.LoadScene("GameScene");
    }

    private void QuitGame()
    {
        // Quit the application (works in standalone builds)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
