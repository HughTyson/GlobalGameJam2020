using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Material default_mat;
    public Material mat_on = null;
    public Material mat_off = null;

    public enum ButtonState
    {
        ON,
        OFF
    }

    public ButtonState state { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        state = ButtonState.OFF;

        // Uncomment this to cycle through materials (debug)
        //StartCoroutine(debugFlicker());
    }

    // DEBUG: Cycles through different state materials every .5 sec
    private IEnumerator debugFlicker()
    {
        while (true)
        {
            if (state == ButtonState.ON)
            {
                state = ButtonState.OFF;
                yield return new WaitForSeconds(0.5f);
            }
            else if (state == ButtonState.OFF)
            {
                state = ButtonState.ON;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case (Button.ButtonState.ON): { GetComponent<MeshRenderer>().sharedMaterial = mat_on; break; }
            case (Button.ButtonState.OFF): { GetComponent<MeshRenderer>().sharedMaterial = mat_off; break; }
            default: { GetComponent<MeshRenderer>().sharedMaterial = default_mat; Debug.LogError("Something is VERY WRONG"); break; }
        }
    }
}