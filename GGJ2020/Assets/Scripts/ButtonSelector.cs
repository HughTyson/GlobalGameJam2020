using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelector : MonoBehaviour
{
    GameObject[] buttons;
    GameObject opener;

    
    [SerializeField] GameObject door;

    [SerializeField] GameObject socket = null;
    [SerializeField] GameObject plug = null;

    int col;

    int identifier = 0;
    int prev_ident;
   
    bool same = false;


    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("MultipleButtons");
        buttons[identifier].GetComponent<HughButton>().setOpener(false);

       

        //get a new random button that is not the same as the last button

        identifier = Random.Range(0, buttons.Length);
        opener = buttons[identifier];

        buttons[identifier].GetComponent<HughButton>().setOpener(true);
        buttons[identifier].GetComponent<HughButton>().door = door;

        Debug.Log(identifier);
        Initilise();




    }

    private void Update()
    {
        plug.GetComponent<WirePlugLogic>().SetColour(socket.GetComponent<WireSocketLogic>().GetColour());
    }

    public void Initilise()
    {
        prev_ident = identifier;
        buttons[prev_ident].GetComponent<HughButton>().setOpener(false);

        //get a new random button that is not the same as the last button
        do
        {
            identifier = Random.Range(0, buttons.Length);

        } while (identifier == prev_ident);

        
        
        opener = buttons[identifier];

        buttons[identifier].GetComponent<HughButton>().setOpener(true);
        buttons[identifier].GetComponent<HughButton>().door = door;

        Debug.Log(identifier);

        //set colour of the socket and plug

        plug.GetComponent<WirePlugLogic>().SetColour(socket.GetComponent<WireSocketLogic>().GetColour());

    }

    public void resetMiniGame()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<HughButton>().resetButton();
        }

        door.GetComponent<DoorOpen>().CloseDoor();
    }
    
}
