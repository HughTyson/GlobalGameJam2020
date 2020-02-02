using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    ButtonKeypad button;
    public GameObject keypad;

    bool inKeypad = false;
    // Start is called before the first frame update
    void Start()
    {
        activateKeypad(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool getInKeypad()
    {
        return inKeypad;
    }
    public void activateKeypad(bool set)
    {
     //   keypad.SetActive(set);
     //   inKeypad = set;

        if(set == false)
        {
            keypad.SetActive(false);
            inKeypad = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            keypad.SetActive(true);
            inKeypad = true;
            Cursor.lockState = CursorLockMode.None;
           // keypad.GetComponent<Keypad>().generateKeypadButtons();
        }
    }

}
