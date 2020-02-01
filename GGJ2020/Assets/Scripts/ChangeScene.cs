using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void Scene1()
    {
        ResetGameScene();
        SceneManager.LoadScene("Scene 1 - Menu");
    }

    public void Scene2()
    {
        SceneManager.LoadScene("Scene 2 - Game");
    }

    public void Scene3()
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
