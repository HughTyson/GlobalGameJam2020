﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentDropScript : MonoBehaviour
{
    [SerializeField] List<GameObject> plugObjects;
    [SerializeField] List<GameObject> hatchObjects;

    [SerializeField] GameObject leverObject;

    bool has_dropped = false;

    List<Vector3> plugInitPositions = new List<Vector3>();
    List<Vector3> hatchInitPositions = new List<Vector3>();


    List<Quaternion> plugInitRotations = new List<Quaternion>();
    List<Quaternion> hatchInitRotations = new List<Quaternion>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < plugObjects.Count; i++)
        {
            plugInitPositions.Add(plugObjects[i].transform.position);
            plugInitRotations.Add(plugObjects[i].transform.rotation);
        }

        for (int i = 0; i < hatchObjects.Count; i++)
        {
            hatchInitPositions.Add(hatchObjects[i].transform.position);
            hatchInitRotations.Add(hatchObjects[i].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!has_dropped)
        {
            if (leverObject.GetComponent<LeverLogic>().IsLeverSetToOn())
            {
                has_dropped = true;
                for (int i = 0; i < hatchObjects.Count; i++)
                {
                    hatchObjects[i].GetComponent<Rigidbody>().isKinematic = false;
                    hatchObjects[i].GetComponent<Rigidbody>().useGravity = true;
                }

            }
        }
    }


    public void ResetVent()
    {
        has_dropped = false;

        for (int i = 0; i < hatchObjects.Count; i++)
        {
            hatchObjects[i].GetComponent<Rigidbody>().isKinematic = true;
            hatchObjects[i].GetComponent<Rigidbody>().useGravity = false;
            hatchObjects[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            hatchObjects[i].transform.position = hatchInitPositions[i];
            hatchObjects[i].transform.rotation = hatchInitRotations[i];
        }

        for (int i = 0; i < plugObjects.Count; i++)
        {
            if (plugObjects[i].GetComponent<WirePlugLogic>().IsInSocket())
            {
                plugObjects[i].GetComponent<WirePlugLogic>().UnplugFromSocket();
            }

            plugObjects[i].transform.position = hatchInitPositions[i];
            plugObjects[i].transform.rotation = hatchInitRotations[i];
        }


    }
}
