using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    private Camera cam;

    private bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

       // cam.transform.rotation = new Vector3(,cam.transform.rotation.y,cam.transform.rotation.z)
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
           // cam.
        }
    }
}
