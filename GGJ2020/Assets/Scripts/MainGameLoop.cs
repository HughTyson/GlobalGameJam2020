using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameLoop : MonoBehaviour
{
    public Text timerString;
    private float timerFloat;
    private bool playOnce;

    // Initialise the text object
    void Start()
    {
        timerFloat = 6.0f;
        timerString.text = timerFloat.ToString();
        playOnce = true;
    }

    void Update()
    {
        // Only start the timer if the player is ready
        if (GetComponent<GameLoop>().GetFinishedFadeOut())
            UpdateTimer();

        // Do something at the end of the timer
        //  Reload the scene at the end of the timer
        if (timerFloat <= 0.0f)
        {
            if (playOnce)
            {
                gameObject.GetComponent<GameLoop>().PlayFadeIn();
                playOnce = false;
            }   

            if(GetComponent<GameLoop>().GetFinishedFadeIn())
                gameObject.GetComponent<ChangeScene>().ReloadGameScene();
        }

        // Sample code of how the main game loop should go
        /*
         * if(Winning condition)
         * {
         *  gameObject.GetComponent<ChangeScene>().LoadEndScene();
         * }
         * else if (timerFloat <= 0f || Some losing condition)
         * {
         *  gameObject.GetComponent<ChangeSccene>().ReloadGameScene();
         * }
         * 
         * 
         */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "win")
            gameObject.GetComponent<ChangeScene>().LoadEndScene();
    }

    private void UpdateTimer()
    {
        // While the timer is greater than 0 decrease it and convert it to a string.
        if(timerFloat > 0.0f)
        {
            timerFloat -= Time.deltaTime;
            timerString.text = timerFloat.ToString("F5");
        }
    }
}
