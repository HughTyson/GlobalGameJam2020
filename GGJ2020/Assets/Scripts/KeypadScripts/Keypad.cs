using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    //Stored passcode to get into the cockpit
    public List<int> code = new List<int>();
    int codeLength = 4;

    //Error checking
    int errorsMade = 0;

    //List of buttons on the keypad
    public GameObject buttonPrefab;
    GameObject button;
    public List<GameObject> keypadButtons = new List<GameObject>();

    //Keypad Object
    GameObject keypad;

    //Starting position for button spawns
    float offsetX = -30.0f;
    float offsetY = 20.0f;

    //List to store pressed buttons
   public List<int> input = new List<int>();

    //Show inputted numbers for player
    public Text showInput;


    // Start is called before the first frame update
    void Start()
    {
        //Keypad object
        keypad = GameObject.Find("Keypad");
        showInput.text = "";

        //Create the keypad buttons
        generateKeypadButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateKeypadButtons()
    {
        //Loop and create the buttons in a grid pattern
        for(int i =0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                button = Instantiate(buttonPrefab);
                //Keep all the buttons with the keypad
                button.transform.SetParent(keypad.transform);
                button.gameObject.transform.localPosition = new Vector3(offsetX, offsetY, 0);
                offsetX += 30.0f;

                //Fill up the list
                keypadButtons.Add(button);
            }

            offsetX = -30.0f;
            offsetY -= 20.0f;
        }

        //Assign keypad buttons 0 - 9
        for (int i = 0; i < keypadButtons.Count; i++)
        {
            keypadButtons[i].GetComponent<KeypadButton>().setNumber(i);
            keypadButtons[i].GetComponentInChildren<Text>().text = i.ToString();
        }
    }

    //Returns true or false regarding whether the right code was inputted
    public void checkCode()
    {
        //Check each position in the lists 
        for(int i =0; i < code.Count; i++)
        {
            //If the positions contents don't add up add one to the error log
            if(code[i] != input[i])
            {
                errorsMade++;
            }
        }

        //If errors, return false, reset the counter
        if(errorsMade > 0)
        {
            errorsMade = 0;
            Debug.Log("Wrong code");
            //Clear the inputted numbers
            clearInput();
        }
        else
        {
            Debug.Log("Right code");
            clearInput();
            errorsMade = 0;
        }
    }

    public void setKeycode(int y)
    {
        if (code.Count < codeLength)
        {
            code.Add(y);
        }
    }

    public void addInput(int x)
    {
        if (input.Count < codeLength)
        {
            showInput.text += x.ToString();
            input.Add(x);
        }

    }

    public void clearInput()
    {
        input.Clear();
        showInput.text = "";
    }
  
    public void clearCode()
    {
        code.Clear();
    }
}
