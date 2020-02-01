using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private GameObject Door1;
    [SerializeField] private GameObject Door2;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            OpenDoors();
        }
    }

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
        }
        else
        {Debug.LogError("Invalid Door 1");
        }

        yield return new WaitForSeconds(2);

        if (Door2 != null)
        {
            Door2.GetComponent<Animator>().enabled = true;
            Door2.GetComponent<Animator>().Play("DoorAnim");
        }

    }
}
