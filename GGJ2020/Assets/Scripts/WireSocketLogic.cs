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
            SetConnectedPlug(ConnectedPlug);
        }
    }


    public bool IsPlugBeingUsed()
    {
        return (ConnectedPlug != null);
    }
    public void SetConnectedPlug(GameObject connected)
    {
            ConnectedPlug = connected;
            ConnectedPlug.transform.position = ConnectionTransform.position;
            ConnectedPlug.transform.rotation = ConnectionTransform.rotation;
            ConnectedPlug.GetComponent<Rigidbody>().isKinematic = true;
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
