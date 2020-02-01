using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robotOrders : MonoBehaviour
{
    // Start is called before the first frame update

    //objective: repair the ship
    string objective = "OBJECTIVE: REPAIR THE SHIP";

    public Text objectiveText;
    int position = 0;

    AudioSource source;
    public AudioClip typing;

    int length = 0;

    void Start()
    {
        objectiveText.text = "";
        length = objective.Length;

        source = GetComponent<AudioSource>();
        source.clip = typing;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            showMessage();
        }
    }

    public void showMessage()
    {
        displayNextLetter();
        startEffect();
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

    }

    void startEffect()
    {
        source.Play();
    }
}
