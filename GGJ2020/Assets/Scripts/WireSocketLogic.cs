using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSocketLogic : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject ConnectedPlug;

    [SerializeField] Transform ConnectionTransform;

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

    public void BeingLookedAt()
    {
        GetComponentInParent<MeshRenderer>().material.color = Color.green;
    }
    public void StoppedBeingLookedAt()
    {
        GetComponentInParent<MeshRenderer>().material.color = Color.red;
    }
    // Update is called once per frame
    void Update()
    {
   
    }
}
