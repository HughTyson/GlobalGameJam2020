﻿using System.Collections;
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

    public float offsetPos1;
    public float offsetPos2;
    public float originalPos;
    public bool flashing = false;
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

        originalPos = transform.position.x;
        offsetPos1 = transform.position.x - .1f;
        offsetPos2 = transform.position.x;
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
        if (GetComponentInParent<SimonSays>().complete == false && !flashing)
        {
            GetComponent<MeshRenderer>().sharedMaterial = mat_on;
        }
    }

    public void notLookedAt()
    {
        if (GetComponentInParent<SimonSays>().complete == false && !flashing)
        {
            GetComponent<MeshRenderer>().sharedMaterial = mat_off;
        }
    }

    public void isClicked()
    {
        if (!flashing)
        {
            clicked = true;

            StartCoroutine(LerpTo(true));
        }
    }

    public IEnumerator LerpTo(bool forwrd)
    {
        transform.position = new Vector3(offsetPos1, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(0.5f);
        transform.position = new Vector3(offsetPos2, transform.position.y, transform.position.z);  
    }

    public void itsOver(bool good)
    {
        flashing = true;
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
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 4; i++)
        {
            GetComponent<MeshRenderer>().sharedMaterial = mat_on;
            yield return new WaitForSeconds(0.2f);

            GetComponent<MeshRenderer>().sharedMaterial = default_mat;
            yield return new WaitForSeconds(0.2f);
        }
        flashing = false;
        //GetComponent<MeshRenderer>().sharedMaterial = default_mat;
    }

    IEnumerator flashBad()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 4; i++)
        {
            GetComponent<MeshRenderer>().sharedMaterial = mat_off;
            yield return new WaitForSeconds(0.2f);

            GetComponent<MeshRenderer>().sharedMaterial = default_mat;
            yield return new WaitForSeconds(0.2f);
        }
        flashing = false;
        //GetComponent<MeshRenderer>().sharedMaterial = mat_off;
    }

    public IEnumerator ShowSequence()
    {
        foreach (int s in GetComponentInParent<SimonSays>().sequence)
        {
            GetComponent<MeshRenderer>().sharedMaterial = default_mat;
            yield return new WaitForSeconds(0.4f);
            if (buttonValue == s)
            {
                GetComponent<MeshRenderer>().sharedMaterial = mat_on;
                yield return new WaitForSeconds(0.4f);
            }
            else
            {
                GetComponent<MeshRenderer>().sharedMaterial = default_mat;
                yield return new WaitForSeconds(0.4f);
            }
            //GetComponent<MeshRenderer>().sharedMaterial = mat_off;
        }
        flashing = false;

    }
}