using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLogic : MonoBehaviour
{

    [SerializeField] bool IsInitiallyOn;
    [SerializeField] Material InitialMaterial;

    [SerializeField] float leverTransitionTime =  0.3f;

    [SerializeField] Transform HandleOrigin;

    [SerializeField] List<GameObject> ChangingColourObjects;
    enum STATE
    {
        SETTLED,
        TRANSITIONING
    
    }

    bool isOn;


    float RotXMiddle = -90.0f;
    float RotXAmplitude = 45.0f;

    STATE current_state = STATE.SETTLED;

    float currentTransitionTime = 0.0f;

    AudioSource source;
    public AudioClip clunk;
    // Start is called before the first frame update
    void Start()
    {
        isOn = IsInitiallyOn;

        if (isOn)
        {
            HandleOrigin.localRotation = Quaternion.Euler(RotXMiddle + RotXAmplitude, 0, 0);
        }
        else
        {
            HandleOrigin.localRotation = Quaternion.Euler(RotXMiddle - RotXAmplitude, 0, 0);
        }

        source = GetComponent<AudioSource>();
        source.clip = clunk;
    }

    // Update is called once per frame
    void Update()
    {

        switch (current_state)
        {
            case STATE.SETTLED:
                {

                    break;
                }
            case STATE.TRANSITIONING:
                {
                    currentTransitionTime += Time.deltaTime;
                    if (isOn)
                    {
                        HandleOrigin.localRotation = Quaternion.Euler(Mathf.Lerp(RotXMiddle - RotXAmplitude, RotXMiddle + RotXAmplitude, currentTransitionTime / leverTransitionTime),0,0);
                    }
                    else
                    {
                        HandleOrigin.localRotation = Quaternion.Euler(Mathf.Lerp(RotXMiddle + RotXAmplitude, RotXMiddle - RotXAmplitude, currentTransitionTime / leverTransitionTime), 0, 0);
                    }

                    if (currentTransitionTime >= leverTransitionTime)
                    {
                        current_state = STATE.SETTLED;
                    }
                    break;
                }
        }

    }


    public bool IsLeverSetToOn()
    {
        return isOn;
    }
    public void BeingLookedAt()
    {
        for (int i = 0; i < ChangingColourObjects.Count; i++)
        {
            ChangingColourObjects[i].GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
    public void StoppedBeingLookedAt()
    {
        for (int i = 0; i < ChangingColourObjects.Count; i++)
        {
            ChangingColourObjects[i].GetComponent<MeshRenderer>().material = InitialMaterial;
        }
       
    }
    public void WasClicked()
    {

        if (current_state == STATE.SETTLED)
        {
            isOn = !isOn;
            current_state = STATE.TRANSITIONING;
            currentTransitionTime = 0;
            source.Play();
        }
    }

    public void ResetLever()
    {
        isOn = IsInitiallyOn;

        if (isOn)
        {
            HandleOrigin.localRotation = Quaternion.Euler(RotXMiddle + RotXAmplitude, 0, 0);
        }
        else
        {
            HandleOrigin.localRotation = Quaternion.Euler(RotXMiddle - RotXAmplitude, 0, 0);
        }
    }
}
