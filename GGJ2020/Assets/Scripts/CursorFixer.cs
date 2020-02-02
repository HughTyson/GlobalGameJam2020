using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFixer : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;

        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
