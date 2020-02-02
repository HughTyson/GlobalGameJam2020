using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonKeypad : MonoBehaviour
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
    public bool flashingSeq = false;


    public GameObject keypadActivator;
    public Activator activator;
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
        
        if(gameObject == player.GetInteractable())
        {
            activator.activateKeypad(true);
        }
    }

    public void isClicked()
    {
        if (!flashing && !flashingSeq)
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
}
