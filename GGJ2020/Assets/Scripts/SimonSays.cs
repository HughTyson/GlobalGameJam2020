using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Minigame_SS();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Minigame_SS()
    {
        string sequence = "";
        sequence += Random.Range(1, 6);
        sequence += Random.Range(1, 6);
        sequence += Random.Range(1, 6);
        sequence += Random.Range(1, 6);
        Debug.Log(sequence);
    }
}
