using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Load scene unloads the current scene and loads the new one.

public class ChangeScene : MonoBehaviour
{

    public void LoadMenuScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);

        ResetGameScene();
        SceneManager.LoadSceneAsync("Scene 1 - Menu");
    }

    public void LoadGameScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);

        SceneManager.LoadSceneAsync("Scene 2 - Game");
    }

    public void LoadEndScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);
        ResetGameScene();
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadSceneAsync("Scene 3 - End");
    }

    public void QuitGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);

        Application.Quit();
    }

    public void ReloadGameScene()
    {
        SceneManager.UnloadSceneAsync("Scene 2 - Game");
        LoadGameScene();
    }

    // Resets the pause menu so that when the game restarts it is not paused.
    public void ResetGameScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if(currentScene == "Scene 2 - Game")
        {
            gameObject.GetComponent<Pause>().ResumeGame();
        }
    }
}
