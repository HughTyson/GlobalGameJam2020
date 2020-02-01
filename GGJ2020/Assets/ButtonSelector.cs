using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelector : MonoBehaviour
{

    GameObject[] buttons;

   

    GameObject opener;
    int identifier;

    // Start is called before the first frame update
    void Start()
    {

        buttons = GameObject.FindGameObjectsWithTag("MultipleButtons");
        identifier = Random.Range(0, buttons.Length);
        opener = buttons[identifier];

        buttons[identifier].GetComponent<HughButton>().setOpener(true);
        Debug.Log(identifier);
    }

    // Update is called once per frame
    void Update()
    {





    }
}
