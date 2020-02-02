using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    ButtonKeypad button;
    public GameObject keypad;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<ButtonKeypad>();
        activateKeypad(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void activateKeypad(bool set)
    {
        keypad.SetActive(set);

        if(set == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
