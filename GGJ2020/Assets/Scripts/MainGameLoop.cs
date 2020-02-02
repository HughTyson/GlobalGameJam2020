using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameLoop : MonoBehaviour
{
    public Text timerString;
    private float timerFloat;
    private bool playFadeIn, playFadeOut;

    public SimonSays simonSays_MG;
    public ButtonSelector findButton_MG;
    public EngineRoomScript wires_MG;
    //public Keypad keypad_MG;

    public GameObject character;
    float maxTime = 1000.0f;



    // Initialise the text object
    void Start()
    {
        timerFloat = maxTime;
        timerString.text = timerFloat.ToString();
        playFadeIn = true;
    }

    void Update()
    {
        // Only start the timer if the player is ready
        if (GetComponent<GameLoop>().GetFinishedFadeOut())
            UpdateTimer();

        //  Reset everything at the end of the timer
        if (timerFloat <= 0.0f)
        {
            if(playFadeIn)
            {
                GetComponent<GameLoop>().PlayFadeIn();
                playFadeIn = false;
                playFadeOut = true;
                
            }

            if(GetComponent<GameLoop>().GetFinishedFadeIn())
            {
                ResetFade();

                if(playFadeOut)
                {
                    GetComponent<GameLoop>().PlayFadeOut();
                    playFadeOut = false;
                    
                }

                ResetCharacter();
                ResetTimer();

                simonSays_MG.resetMinigame();
                findButton_MG.resetMiniGame();
                wires_MG.ResetEngineRoom();
                //keypad_MG.resetKeypad();

                playFadeIn = true;
            }
        }
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
            timerString.text = timerFloat.ToString("F0");
        }
    }

    // Reset everything
    private void ResetCharacter()
    {
        character.GetComponent<CharacterCtrl>().ResetChar();
        character.GetComponent<CharacterInteractivity>().ResetCharacterInteractivity();
    }
    private void ResetTimer()
    {
        timerFloat = maxTime;
        timerString.text = timerFloat.ToString();
    }
    private void ResetFade()
    {
        gameObject.GetComponent<GameLoop>().SetFinishedFadeIn(false);
        gameObject.GetComponent<GameLoop>().SetFinishedFadeOut(false);
    }
}
