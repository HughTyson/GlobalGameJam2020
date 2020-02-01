using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Material default_mat;
    public Material mat_on = null;
    public Material mat_off = null;
    CharacterCtrl player;

    public int buttonValue;
    public bool clicked = false;

    public enum ButtonState
    {
        ON,
        OFF
    }

    public ButtonState state { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCtrl>();
        state = ButtonState.OFF;
        GetComponent<MeshRenderer>().sharedMaterial = mat_off;


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
        if (GetComponentInParent<SimonSays>().complete == false)
        {
            if (gameObject == player.GetInteractable())
            {
                state = ButtonState.ON;
            }
            else
            {
                state = ButtonState.OFF;
            }
            switch (state)
            {
                case (Button.ButtonState.ON): { lookedAt(); break; }
                case (Button.ButtonState.OFF): { notLookedAt(); break; }
                default: { GetComponent<MeshRenderer>().sharedMaterial = default_mat; Debug.LogError("Something is VERY WRONG"); break; }
            }
        }
    }

    public void lookedAt()
    {
        if (GetComponentInParent<SimonSays>().complete == false)
        {
            GetComponent<MeshRenderer>().sharedMaterial = mat_on;
        }

    }

    public void notLookedAt()
    {
        if (GetComponentInParent<SimonSays>().complete == false)
        {
            GetComponent<MeshRenderer>().sharedMaterial = mat_off;
        }
    }

    public void isClicked()
    {
        clicked = true;
        Debug.Log("Detected");
    }

    public void itsOver(bool good)
    {
        if (good)
        {
            StartCoroutine(flashGood());
        }
        else
        {
            StartCoroutine(flashBad());
        }
    }

    IEnumerator flashGood()
    {
        for (int i = 0; i < 4; i++)
        {
            GetComponent<MeshRenderer>().sharedMaterial = mat_on;
            yield return new WaitForSeconds(0.5f);

            GetComponent<MeshRenderer>().sharedMaterial = default_mat;
            yield return new WaitForSeconds(0.5f);
        }
        GetComponent<MeshRenderer>().sharedMaterial = default_mat;
    }

    IEnumerator flashBad()
    {
        for (int i = 0; i < 4; i++)
        {
            GetComponent<MeshRenderer>().sharedMaterial = mat_off;
            yield return new WaitForSeconds(0.5f);

            GetComponent<MeshRenderer>().sharedMaterial = default_mat;
            yield return new WaitForSeconds(0.5f);
        }
        GetComponent<MeshRenderer>().sharedMaterial = mat_off;
    }
}