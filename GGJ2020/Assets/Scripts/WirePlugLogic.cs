﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePlugLogic : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject connectedSocket;

    Transform attachedTransform;

    enum STATE
    { 
    IN_HAND,
    FREE,
    PLUGGED    
    }
    STATE current_state = STATE.FREE;

    void Start()
    {
        
    }

    public void PlugIntoSocket(GameObject socketReference, Transform connectedTransform)
    {
        connectedSocket = socketReference;
        attachedTransform = connectedTransform;

         current_state = STATE.PLUGGED;
    }

    public void UnplugFromSocket()
    {
        if (connectedSocket != null)
        {
            connectedSocket.GetComponent<WireSocketLogic>().DisconnectPlug();
            GetComponent<Rigidbody>().isKinematic = false;
            connectedSocket = null;
            current_state = STATE.FREE;
        }
    }


    public void PlaceIntoHand(Transform handTransform_)
    {
        switch (current_state)
        {
            case STATE.FREE:
                {
                    attachedTransform = handTransform_;
                    current_state = STATE.IN_HAND;
                    break;
                }
            case STATE.PLUGGED:
                {
                    UnplugFromSocket();
                    attachedTransform = handTransform_;
                    current_state = STATE.IN_HAND;
                    break;
                }
        }



    }
    public void LetGoFromHand()
    {
        attachedTransform = null;
        current_state = STATE.FREE;
    }

    public bool IsInSocket()
    {
        return (connectedSocket != null);
    }


    // Update is called once per frame
    void Update()
    {
        switch (current_state)
        {
            case STATE.FREE:
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                    break;
                }
            case STATE.PLUGGED:
                {
                    GetComponent<Rigidbody>().isKinematic = true;
                    transform.position = attachedTransform.position;
                    transform.transform.rotation = attachedTransform.rotation;
                    break;
                }
            case STATE.IN_HAND:
                {
                    GetComponent<Rigidbody>().isKinematic = true;
                    transform.position = attachedTransform.position;
                    transform.transform.rotation = attachedTransform.rotation;
                    break;
                }
        
        }

    }


    public void BeingLookedAt()
    {
        if (current_state == STATE.PLUGGED)
        {
            connectedSocket.GetComponent<WireSocketLogic>().BeingLookedAt();
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }

    }

    public void StoppedBeingLookedAt()
    {
        if (current_state == STATE.PLUGGED)
        {
            connectedSocket.GetComponent<WireSocketLogic>().StoppedBeingLookedAt();
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }

    }

}
