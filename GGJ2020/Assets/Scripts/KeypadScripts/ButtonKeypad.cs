using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonKeypad : MonoBehaviour
{
    public Material default_mat;
    public Material mat_on = null;
    public Material mat_off = null;
    public Material mat_start = null;
    CharacterCtrl player;

    public int buttonValue;
    public bool clicked = false;

    public float offsetPos1;
    public float offsetPos2;
    public float originalPos;
    public bool flashing = false;
    public bool flashingSeq = false;


    Activator activator;
    public enum ButtonState
    {
        ON,
        OFF
    }
    public enum ButtonType
    {
        START,
        GAME
    }
    public ButtonType type { get; set; }

    public ButtonState state { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCtrl>();
        state = ButtonState.OFF;
        GetComponent<MeshRenderer>().sharedMaterial = mat_off;

        activator = GetComponentInParent<Activator>();

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
            if (clicked)
            {
                activator.activateKeypad(true);
            }
        }
    }


    public void lookedAt()
    {
        
         GetComponent<MeshRenderer>().sharedMaterial = mat_on;

    }

    public void notLookedAt()
    {
        
            if (type == ButtonType.GAME)
            {
                GetComponent<MeshRenderer>().sharedMaterial = mat_off;
            }
            else
            {
                GetComponent<MeshRenderer>().sharedMaterial = mat_start;
            }

        
    }

    public void isClicked()
    {

        clicked = true;

    }

    public void setIsClicked(bool set)
    {
        clicked = set;
    }

 
}
