using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{

    //Number assigned to the button
    int num = 0;

    //Keypad
    Keypad keypad;

    // Start is called before the first frame update
    void Start()
    {
        //Assign the keypad script
        keypad = GameObject.Find("KeypadPrefab").GetComponent<Keypad>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Call this to input numbers to the keypad
    public void pressButton()
    {
        keypad.addInput(num);
    }

    public void setNumber(int number)
    {
        num = number;
    }
    public int getNumber()
    {
        return num;
    }
}
