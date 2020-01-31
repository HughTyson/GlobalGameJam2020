using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene("Scene 1 - Menu");
    }

    public void Scene2()
    {
        SceneManager.LoadScene("Scene 2 - Game");
    }

    public void Scene3()
    {
        SceneManager.LoadScene("Scene 3 - End");
    }

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
