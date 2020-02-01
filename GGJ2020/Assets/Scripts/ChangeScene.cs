using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Load scene unloads the current scene and loads the new one.

public class ChangeScene : MonoBehaviour
{

    public void LoadMenuScene()
    {
        ResetGameScene();
        SceneManager.LoadScene("Scene 1 - Menu");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Scene 2 - Game");
    }

    public void ReloadGameScene()
    {
        SceneManager.UnloadSceneAsync("Scene 2 - Game");
        LoadGameScene();
    }

    public void LoadEndScene()
    {
        ResetGameScene();
        SceneManager.LoadScene("Scene 3 - End");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Resets the pause menu so that when the game restarts it is not paused.
    public void ResetGameScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if(currentScene == "Scene 2 - Game")
        {
            gameObject.GetComponent<Pause>().ResumeGame();
            //this.GetComponent<Pause>().ResumeGame();
        }
    }
}
