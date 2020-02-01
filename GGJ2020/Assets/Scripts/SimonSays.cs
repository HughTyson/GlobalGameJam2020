using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    public Button button;
    private Button[] buttons = new Button[6];

    private int number = 0;
    public List<int> sequence = new List<int>();
    public bool complete = false;
    public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        Minigame_SS();   
        int offset = -2;
        for (int i = 0; i < 5; i++)
        {
            buttons[i] = Instantiate(button, this.transform);
            buttons[i].buttonValue = i;
            buttons[i].transform.position = new Vector3(-2.3f, 2, offset) + transform.position;

            offset += 1;
        }
        buttons[5] = Instantiate(button, this.transform);
        buttons[5].buttonValue = -1;
        buttons[5].transform.position = new Vector3(-2.3f, 1, 0) + transform.position;
        //buttons[5].transform.localScale = new Vector3(0.5f,0.5f,0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (complete == false)
        {
            for (int i = 0; i < 5; i++)
            {
                if (buttons[i].clicked)
                {
                    if (sequence[number] == buttons[i].buttonValue)
                    {
                        //Debug.Log("CORRECTAMUNDO");
                        number++;
                    }
                    else
                    {
                        //Debug.Log("BIG BAD >:(");
                        onReset();
                    }
                    buttons[i].clicked = false;
                }
            }

            if (buttons[5].clicked)
            {
                for (int i = 0; i < 5; i++)
                {
                    buttons[i].flashingSeq = true;
                    StartCoroutine(buttons[i].ShowSequence());
                }
                buttons[5].clicked = false;
            }

            if (number > 3)
            {
                complete = true;
                for (int i = 0; i < 5; i++)
                {
                    buttons[i].itsOver(true);
                }
                Door.GetComponent<DoorOpen>().OpenDoors();
                //Debug.Log("Oh lawd you got it!");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            resetMinigame();
        }
    }

    private void onReset()
    {
        number = 0;
        for (int i = 0; i < 5; i++)
        {
            buttons[i].itsOver(false);
        }
       // Debug.Log("Reset, you messed it up ;(");
    }

    void Minigame_SS()
    {
        int r1, r2, r3, r4;

        int dup = -1;

        r1 = Random.Range(0, 5);
        r2 = Random.Range(0, 5);
        if (r1 == r2)
        {
            dup = r1;
        }
        r3 = dup;
        while (r3 == dup)
        {
            r3 = Random.Range(0, 5);
        }
        r4 = Random.Range(0, 5);


        sequence.Add(r1);
        sequence.Add(r2);
        sequence.Add(r3);
        sequence.Add(r4);
        string res = "";
        for (int i = 0; i < sequence.Count; i++)
        {
            res += sequence[i];
        }
    }

    public void resetMinigame()
    {
        number = 0;
        complete = false;
        for (int i = 0; i < 6; i++)
        {
            buttons[i].clicked = false;
            buttons[i].flashing = false;
            buttons[i].flashingSeq = false;
        }
    }
}
