using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireGameScript : MonoBehaviour
{
    // Start is called before the first frame update


    public enum COLOUR_ENUM
    { 
    PURPLE,
    BLUE,
    ORANGE,
    CYAN    
    };

    [SerializeField] GameObject DoorObject;

    [SerializeField] List<GameObject> WireBoardSockets;

    [SerializeField] List<GameObject> ceilingPlugs;
    [SerializeField] List<GameObject> cryochamberPlugs;
    [SerializeField] List<GameObject> cryochamberSockets;


    enum STATE
    { 
    INCOMPLETE,
    COMPLETE
    
    };
    STATE current_state = STATE.INCOMPLETE;

    void Start()
    {
        List<COLOUR_ENUM> remaining_colours = new List<COLOUR_ENUM>();
        remaining_colours.Add(COLOUR_ENUM.PURPLE);
        remaining_colours.Add(COLOUR_ENUM.BLUE);
        remaining_colours.Add(COLOUR_ENUM.ORANGE);
        remaining_colours.Add(COLOUR_ENUM.CYAN);

        List<GameObject> remainingWireBoardSockets = new List<GameObject>();
        remainingWireBoardSockets.AddRange(WireBoardSockets);

        List<GameObject> remaininceilingPlugs = new List<GameObject>();
        ceilingPlugs.AddRange(ceilingPlugs);

        List<GameObject> remainingCryoChamberPlugs = new List<GameObject>();
        remainingCryoChamberPlugs.AddRange(cryochamberPlugs);

        List<GameObject> remainingCryoChamberSockets = new List<GameObject>();
        remainingCryoChamberSockets.AddRange(cryochamberSockets);

        for (int i = 0; i < 4; i++)
        {
            int index;
            COLOUR_ENUM colour = remaining_colours[i];

            index = Random.Range(0, 3 - i);
            remainingWireBoardSockets[index].GetComponent<WireSocketLogic>().SetColour(colour);
            remainingWireBoardSockets.RemoveAt(index);

            index = Random.Range(0, 3 - i);
            remaininceilingPlugs[index].GetComponent<WirePlugLogic>().SetColour(colour);
            remaininceilingPlugs.RemoveAt(index);

            index = Random.Range(0, 3 - i);
            remainingCryoChamberPlugs[index].GetComponent<WirePlugLogic>().SetColour(colour);
            remainingCryoChamberPlugs.RemoveAt(index);
            remainingCryoChamberSockets[index].GetComponent<WireSocketLogic>().SetColour(colour);
            remainingCryoChamberSockets.RemoveAt(index);
        }
    }

 
    // Update is called once per frame
    void Update()
    {
        switch (current_state)
        {
            case STATE.INCOMPLETE:
            {
                bool allTrue = true;
                for (int i = 0; i < 4; i++)
                {
                        if (!WireBoardSockets[i].GetComponent<WireSocketLogic>().IsColourMatched())
                        {
                            allTrue = false;
                        }
                }
                if (allTrue)
                {
                        current_state = STATE.COMPLETE;
                        DoorObject.GetComponent<DoorOpen>().OpenDoors();

                }
                break;
            }        
        }


    }

    public void Reset()
    {
        current_state = STATE.INCOMPLETE;
    }
}
