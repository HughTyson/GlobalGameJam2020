using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSocketLogic : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject ConnectedPlug;

    [SerializeField] Transform ConnectionTransform;

    WireGameScript.COLOUR_ENUM myColour;
    void Start()
    {
        if (ConnectedPlug != null)
        {
            ConnectPlug(ConnectedPlug);
        }
    }


    public bool IsSocketBeingUsed()
    {
        return (ConnectedPlug != null);
    }

    public GameObject GetPlugObject()
    {
        return ConnectedPlug;
    }
    public void ConnectPlug(GameObject connected)
    {
        ConnectedPlug = connected;

        ConnectedPlug.GetComponent<WirePlugLogic>().PlugIntoSocket(gameObject,ConnectionTransform);



    }
    public void DisconnectPlug()
    {
        if (ConnectedPlug != null)
        {
            ConnectedPlug = null;

        }

    }

    public void SetColour(WireGameScript.COLOUR_ENUM colour)
    {
        myColour = colour;

        switch (colour)
        {
            case WireGameScript.COLOUR_ENUM.BLUE:
                {
                    ConnectionTransform.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1);
                    break;
                }
            case WireGameScript.COLOUR_ENUM.ORANGE:
                {
                    ConnectionTransform.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.64f, 0);
                    break;
                }
            case WireGameScript.COLOUR_ENUM.CYAN:
                {
                    ConnectionTransform.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1);
                    break;
                }
            case WireGameScript.COLOUR_ENUM.PURPLE:
                {
                    ConnectionTransform.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0, 0.5f);
                    break;
                }

        }

    }

    public bool IsColourMatched()
    {
        if (ConnectedPlug != null)
        {
            return (myColour == ConnectedPlug.GetComponent<WirePlugLogic>().GetColour());
        }
        return false;
    }
    public void BeingLookedAt()
    {
        GetComponentInParent<MeshRenderer>().material.color = Color.green;
    }
    public void StoppedBeingLookedAt()
    {
        GetComponentInParent<MeshRenderer>().material.color = Color.white;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
