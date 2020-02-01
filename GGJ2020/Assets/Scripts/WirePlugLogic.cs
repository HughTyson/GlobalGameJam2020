using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePlugLogic : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject connectedSocket;

    void Start()
    {
        
    }

    public void PlugIntoSocket(GameObject socketReference)
    {
        connectedSocket = socketReference;
    }

    public void UnplugFromSocket()
    {
 //       connectedSocket.GetComponent<WireSocketLogic>().SetConnectedPlug(null);
        connectedSocket = null;
    }
    //public void SetIsInSocket(bool is_inSocket)
    //{
    //    isInSocket = is_inSocket;

    //    if (is_inSocket)
    //    {
    //        GetComponent<Rigidbody>().isKinematic = true;
    //    }
    //    else
    //    {
    //        GetComponent<Rigidbody>().isKinematic = false;
    //    }
    //}
    public bool IsInSocket()
    {
        return (connectedSocket != null);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void BeingLookedAt()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public void StoppedBeingLookedAt()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

}
