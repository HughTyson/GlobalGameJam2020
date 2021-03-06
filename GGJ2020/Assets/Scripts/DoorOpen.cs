﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private GameObject Door1;
    [SerializeField] private GameObject Door2;

    

    public void OpenDoors()
    {
        StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        if (Door1 != null)
        {
            Door1.GetComponent<Animator>().enabled = true;
            Door1.GetComponent<Animator>().Play("DoorAnim");
            Door1.GetComponent<AudioSource>().Play();
        }
        else
        {Debug.LogError("Invalid Door 1");
        }

        yield return new WaitForSeconds(2);

        if (Door2 != null)
        {
            Door2.GetComponent<Animator>().enabled = true;
            Door2.GetComponent<Animator>().Play("DoorAnim");
            Door2.GetComponent<AudioSource>().Play();

        }

    }

    public void CloseDoor()
    {
        StartCoroutine(Close());
    }


    IEnumerator Close()
    {
        if (Door1 != null)
        {
            Door1.GetComponent<Animator>().enabled = true;
            Door1.GetComponent<Animator>().Play("CloseDoor");
        }
        else
        {
            Debug.LogError("Invalid Door 1");
        }

        yield return new WaitForSeconds(2);

        if (Door2 != null)
        {
            Door2.GetComponent<Animator>().enabled = true;
            Door2.GetComponent<Animator>().Play("CloseDoor");
        }

    }
}
