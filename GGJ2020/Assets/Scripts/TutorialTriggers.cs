using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggers : MonoBehaviour
{

    [SerializeField] int tutNumb;
    bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (!triggered)
            {
                other.GetComponent<CharacterCtrl>().tutNumb = tutNumb;
                other.GetComponent<robotOrders>().setOrders(true);
                triggered = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (transform.tag == "Hazard")
        {
            if (other.gameObject.tag == "Player")
            {
                triggered = false;
            }
        }
    }
}
