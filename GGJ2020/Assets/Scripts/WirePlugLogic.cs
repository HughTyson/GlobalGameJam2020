using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePlugLogic : MonoBehaviour
{
    // Start is called before the first frame update


    bool isInSocket = false;
    void Start()
    {
        
    }

    public void SetIsInSocket(bool is_inSocket)
    {
        isInSocket = is_inSocket;

        if (is_inSocket)
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    public bool IsInSocket()
    {
        return isInSocket;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
