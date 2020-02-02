using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Load scene unloads the current scene and loads the new one.

public class ChangeScene : MonoBehaviour
{

    public void LoadMenuScene()
    {
        Cursor.lockState = CursorLockMode.None;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);

        ResetGameScene();
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void LoadGameScene()
    {
        Cursor.lockState = CursorLockMode.Locked;

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
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.UnloadSceneAsync("Level");
        LoadGameScene();
    }

    // Resets the pause menu so that when the game restarts it is not paused.
    public void ResetGameScene()
    {
        Cursor.lockState = CursorLockMode.Locked;

        string currentScene = SceneManager.GetActiveScene().name;

        if(currentScene == "Level")
        {
            gameObject.GetComponent<Pause>().ResumeGame();
        }
    }
}
