using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChoice : MonoBehaviour
{
    public FinalButton button;
    private FinalButton[] buttons = new FinalButton[2];
    private int correctChoice;
    private bool complete = false;
    public bool WinState = false; // FALSE = you lose, TRUE = you won
    // Start is called before the first frame update
    void Start()
    {
        correctChoice = Random.Range(0, 1000);
        if (correctChoice < 500)
        {
            correctChoice = 0;
        }
        else if (correctChoice >= 500)
        {
            correctChoice = 1;
        }

        int offset = 0;
        for (int i = 0; i < 2; i++)
        {
            buttons[i] = Instantiate(button, this.transform);
            buttons[i].buttonValue = i;
            buttons[i].transform.position = new Vector3(offset, 2, 0) + transform.position;

            offset += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (complete == false)
        {
            for (int i = 0; i < 2; i++)
            {
                if (buttons[i].clicked)
                {
                    if (buttons[i].buttonValue == correctChoice)
                    {
                        Debug.Log("YOU WIN!");
                        WinState = true;
                        complete = true;
                    }
                    else
                    {
                        Debug.Log("YOU LOSE! OFUCKICANTBELIEVEYOUVEDONETHIS");
                        WinState = false;
                        complete = true;
                    }
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            resetMinigame();
        }
    }

    void resetMinigame()
    {
        complete = false;
        for (int i = 0; i < 2; i++)
        {
            buttons[i].clicked = false;
        }
    }
}