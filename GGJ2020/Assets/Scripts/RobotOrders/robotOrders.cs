using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robotOrders : MonoBehaviour
{
    

    string objective;

    string[] day_text = new string[4];
    string[] tutorial_text = new string[7];

    string outputted_text = null;

    public Text objectiveText;
    int position = 0;

    AudioSource source;
    public AudioClip typing;

    int length = 0;

    // Start is called before the first frame update
    void Start()
    {
        objectiveText.text = null;
        //length = objective.Length;

        source = GetComponent<AudioSource>();
        source.clip = typing;

        day_text[0] = " Ship Crash imminent: R3P-41R";
        day_text[1] = " Ship Crash...huh...deja vu";
        day_text[2] = " Ship C... Ahhh Beans... this is repeating";
        day_text[3] = " HECK";

        tutorial_text[0] = "Doors busted, shocking";
        tutorial_text[1] = "Big heck, that's a lotta buttons, gotta go fast";
        tutorial_text[2] = "OW";
        tutorial_text[3] = "OOOOOOOOO, I LOVE PATTERNS";
        tutorial_text[4] = "Heck forgot the code, sure wish I wrote it down someplace(or mulitple)";
        tutorial_text[5] = "More Buttons. Yay!";
        tutorial_text[6] = "One of these is bound to fix the ship!";
    }

    public void setOrders(bool tutorial)
    {
        
        if (!tutorial)
        {
            int days = GetComponent<CharacterCtrl>().day;
            if (days < day_text.Length)
            {
                objective = day_text[days];
            }
            else
            {
                objective = day_text[day_text.Length - 1];
            }
        }
        else
        {
            int tut = GetComponent<CharacterCtrl>().tutNumb;
            if (tut < tutorial_text.Length)
            {
                objective = tutorial_text[tut];
            }
            else
            {
                Debug.LogError("Invalid room number");
            }
        }

        length = objective.Length;

        showMessage(length);
        
    }

    public void showMessage(int length)
    {
        if(IsInvoking())
        {
            objectiveText.text = null;
            CancelInvoke();
            position = 0;
        }

       

        displayNextLetter();
        startEffect(length);
    }

    void displayNextLetter()
    {

        objectiveText.text += objective[position];
        position++;

        if (position != objective.Length)
        {
            Invoke("displayNextLetter", 0.1f);
        }
        else
        {
            source.Stop();
            Invoke("clearText", 1);
            Invoke("startEffect", 1);
        }
    }

    void clearText()
    {
        string newString = objective.Substring(0, length -1);
        objectiveText.text = newString;
        length--;

        if (length != 0)
        {
            Invoke("clearText", 0.1f);
        }
        else
        {
            CancelInvoke();
            source.Stop();
        }

        position = 0;
    }

    void startEffect(int len)
    {
        length = len;

        source = GetComponent<AudioSource>();
        source.clip = typing;

        source.Play();
    }
}
