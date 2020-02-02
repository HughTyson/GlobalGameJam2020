using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSocketLogic : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject ConnectedPlug;

    [SerializeField] Transform ConnectionTransform;
    [SerializeField] List<Material> colourMaterials;
    WireGameScript.COLOUR_ENUM myColour;

    Color initial_colour;
    void Start()
    {
        if (ConnectedPlug != null)
        {
            ConnectPlug(ConnectedPlug);
        }
        initial_colour = GetComponent<MeshRenderer>().material.color;
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

        ConnectionTransform.GetComponent<MeshRenderer>().material = colourMaterials[(int)colour];

    }

    public WireGameScript.COLOUR_ENUM GetColour()
    {
        return myColour;
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
        GetComponentInParent<MeshRenderer>().material.color = initial_colour;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
