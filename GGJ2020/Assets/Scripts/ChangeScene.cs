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
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void LoadGameScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);

        SceneManager.LoadSceneAsync("Level");
    }

    public void LoadEndScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);
        ResetGameScene();
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadSceneAsync("End Screen");
    }

    public void QuitGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);

        Application.Quit();
    }

    public void ReloadGameScene()
    {
        SceneManager.UnloadSceneAsync("Level");
        LoadGameScene();
    }

    // Resets the pause menu so that when the game restarts it is not paused.
    public void ResetGameScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if(currentScene == "Level")
        {
            gameObject.GetComponent<Pause>().ResumeGame();
        }
    }
}
