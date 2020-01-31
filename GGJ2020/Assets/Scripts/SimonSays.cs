using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    public Button button;
    private Button[] buttons = new Button[5];

    // Start is called before the first frame update
    void Start()
    {
        int offset = 0;
        for (int i = 0; i < 5; i++)
        {
            buttons[i] = button;
            buttons[i].transform.position = new Vector3(0,0,offset);
            Instantiate(buttons[i], this.transform);

            offset += 5;
        }
        Minigame_SS();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Minigame_SS()
    {
        string sequence = "";
        sequence += Random.Range(0, 5);
        sequence += Random.Range(0, 5);
        sequence += Random.Range(0, 5);
        sequence += Random.Range(0, 5);
        Debug.Log(sequence);
    }
}
