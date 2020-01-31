using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSocketLogic : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject ConnectedPlug;
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
            ConnectedPlug.transform.position = this.transform.position;
            ConnectedPlug.transform.rotation = this.transform.rotation;
            ConnectedPlug.GetComponent<Rigidbody>().isKinematic = true;
    }


    // Update is called once per frame
    void Update()
    {
   
    }
}
