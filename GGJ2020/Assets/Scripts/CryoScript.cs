using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryoScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject Screen;
    [SerializeField] GameObject Plug;
    [SerializeField] GameObject Socket;

    public void Reset()
    {
        Screen.GetComponent<CryoScreenScript>().Reset();

        if (Plug.GetComponent<WirePlugLogic>().IsInSocket())
        {
            Plug.GetComponent<WirePlugLogic>().UnplugFromSocket();
        }
        
        if (Socket.GetComponent<WireSocketLogic>().IsSocketBeingUsed())
        {
            Socket.GetComponent<WireSocketLogic>().GetPlugObject().GetComponent<WirePlugLogic>().UnplugFromSocket();
        }
        Socket.GetComponent<WireSocketLogic>().ConnectPlug(Plug);


    }
}
