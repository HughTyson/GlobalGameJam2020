﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractivity : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] Camera theCamera;
    [SerializeField] Transform handTransform;
    [SerializeField] float viewingDistance;
    [SerializeField] LayerMask layermask;


    RaycastHit raycastObjectHit;
    RaycastHit raycastObjectHitPrevious;

    
    class InteractiveObject
    {
        public enum TYPE
        { 
            NONE,
            SOCKET,
            PLUG,
            DAN_BUTTON,
            HUGH_BUTTON,
            LEVER,
            FINAL_BUTTON,
            KEYPAD_BUTTON,
        }

        public TYPE myType;
        public GameObject reference;
    }

    InteractiveObject currentlyLookingAt = new InteractiveObject();

    InteractiveObject currentlyHolding = new InteractiveObject();


    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(theCamera.transform.position, theCamera.transform.forward);

        Debug.DrawRay(ray.origin, ray.direction* viewingDistance);
        if (Physics.Raycast(ray, out raycastObjectHit, viewingDistance, layermask, QueryTriggerInteraction.Collide))
        {
            if (raycastObjectHit.transform.gameObject.GetComponent<CustomTagSystem>() != null)
            {
                if (raycastObjectHit.transform.gameObject != currentlyLookingAt.reference && raycastObjectHit.transform.gameObject != currentlyHolding.reference) // looked at new thing
                {
                    LookedAwayFromCurrent();
                    SetupNewLookAt();
                    LookedAtNewCurrent();
                }
            }
            else
            {
                LookedAwayFromCurrent();
                NoNewLookAt();
            }
        }
        else
        {
            LookedAwayFromCurrent();
            NoNewLookAt();
        }


        if (currentlyHolding.reference == null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ClickedWhileLookingAtCurrent();
            }
        }
        else
        {
            if (Input.GetButtonUp("Fire1"))
            {
                LetGoOfHeldItem();
            }
        }
    }




    private void SetupNewLookAt()
    {
        currentlyLookingAt.reference = raycastObjectHit.transform.gameObject;

        List<CustomTagSystem.TAG> tags = raycastObjectHit.transform.gameObject.GetComponent<CustomTagSystem>().GetTags();

        for (int i = 0; i < tags.Count; i++)
        {
            bool found = false;
            switch (tags[i])
            {
                case CustomTagSystem.TAG.WIRE_SOCKET:
                    {
                        currentlyLookingAt.myType = InteractiveObject.TYPE.SOCKET; 
                        break;
                    }
                case CustomTagSystem.TAG.WIRE_PLUG:
                    {
                        currentlyLookingAt.myType = InteractiveObject.TYPE.PLUG;

                        break;
                    }
                case CustomTagSystem.TAG.LEVER:
                    {
                        currentlyLookingAt.myType = InteractiveObject.TYPE.LEVER;
                        break;
                    }
                case CustomTagSystem.TAG.DAN_BUTTON:
                    {
                        currentlyLookingAt.myType = InteractiveObject.TYPE.DAN_BUTTON;

                        break;
                    }
                case CustomTagSystem.TAG.HUGH_BUTTON:
                    {
                        currentlyLookingAt.myType = InteractiveObject.TYPE.HUGH_BUTTON;

                        break;
                    }
                case CustomTagSystem.TAG.FINAL_BUTTON:
                    {
                        currentlyLookingAt.myType = InteractiveObject.TYPE.FINAL_BUTTON;
                        break;
                    }
                case CustomTagSystem.TAG.KEYPAD_BUTTON:
                    {
                        currentlyLookingAt.myType = InteractiveObject.TYPE.KEYPAD_BUTTON;
                        break;
                    }
            }

            if (found)
            {
                break;
            }
        }
    }

    private void NoNewLookAt()
    {
        currentlyLookingAt.reference = null;
        currentlyLookingAt.myType = InteractiveObject.TYPE.NONE;
    }

    private void LookedAtNewCurrent()
    {
        switch (currentlyLookingAt.myType)
        {
            case InteractiveObject.TYPE.SOCKET:
                {

                    currentlyLookingAt.reference.GetComponent<WireSocketLogic>().BeingLookedAt();

                    break;
                }
            case InteractiveObject.TYPE.PLUG:
                {
                    currentlyLookingAt.reference.GetComponent<WirePlugLogic>().BeingLookedAt();
                    break;
                }
            case InteractiveObject.TYPE.HUGH_BUTTON:
                {
                    currentlyLookingAt.reference.GetComponent<HughButton>().LookedAt();
                    break;
                }
            case InteractiveObject.TYPE.DAN_BUTTON:
                {
                    currentlyLookingAt.reference.GetComponent<Button>().lookedAt();
                    break;
                }
            case InteractiveObject.TYPE.LEVER:
                {
                    currentlyLookingAt.reference.GetComponent<LeverLogic>().BeingLookedAt();
                    break;
                }
            case InteractiveObject.TYPE.FINAL_BUTTON:
                {
                    currentlyLookingAt.reference.GetComponent<FinalButton>().lookedAt();
                    break;
                }
            case InteractiveObject.TYPE.KEYPAD_BUTTON:
                {
                    currentlyLookingAt.reference.GetComponent<ButtonKeypad>().lookedAt();
                    break;
                }



        }
    }

    private void LookedAwayFromCurrent()
    {
        if (currentlyLookingAt.reference != null)
        {
            switch (currentlyLookingAt.myType)
            {
                case InteractiveObject.TYPE.SOCKET:
                    {

                        currentlyLookingAt.reference.GetComponent<WireSocketLogic>().StoppedBeingLookedAt();
   
                        break;
                    }
                case InteractiveObject.TYPE.PLUG:
                    {
                        currentlyLookingAt.reference.GetComponent<WirePlugLogic>().StoppedBeingLookedAt();
                        break;
                    }
                case InteractiveObject.TYPE.HUGH_BUTTON:
                    {
                        currentlyLookingAt.reference.GetComponent<HughButton>().NotBeingLookedAt();
                        break;
                    }
                case InteractiveObject.TYPE.DAN_BUTTON:
                    {
                        currentlyLookingAt.reference.GetComponent<Button>().notLookedAt();
                        break;
                    }
                case InteractiveObject.TYPE.LEVER:
                    {
                        currentlyLookingAt.reference.GetComponent<LeverLogic>().StoppedBeingLookedAt();
                        break;
                    }
                case InteractiveObject.TYPE.FINAL_BUTTON:
                    {
                        currentlyLookingAt.reference.GetComponent<FinalButton>().notLookedAt();
                        break;
                    }
                case InteractiveObject.TYPE.KEYPAD_BUTTON:
                    {
                        currentlyLookingAt.reference.GetComponent<ButtonKeypad>().notLookedAt();
                        break;
                    }

            }

        }

        currentlyLookingAt.reference = null;
        currentlyLookingAt.myType = InteractiveObject.TYPE.NONE;
    }

    private void ClickedWhileLookingAtCurrent()
    {
        if (currentlyLookingAt.reference != null)
        {
            switch (currentlyLookingAt.myType)
            {
                case InteractiveObject.TYPE.SOCKET:
                    {
                        if (currentlyHolding.reference == null)
                        {
                            if (currentlyLookingAt.reference.GetComponent<WireSocketLogic>().IsSocketBeingUsed())
                            {
                               currentlyHolding.reference = currentlyLookingAt.reference.GetComponent<WireSocketLogic>().GetPlugObject();
                               currentlyHolding.myType = InteractiveObject.TYPE.PLUG;
                               LookedAwayFromCurrent();

                                currentlyHolding.reference.GetComponent<WirePlugLogic>().PlaceIntoHand(handTransform);
                            }
                        }

                        break;
                    }
                case InteractiveObject.TYPE.PLUG:
                    {
                        currentlyHolding.reference = currentlyLookingAt.reference;
                        currentlyHolding.myType = currentlyLookingAt.myType;
                        currentlyHolding.reference.GetComponent<WirePlugLogic>().PlaceIntoHand(handTransform);

                        break;
                    }
                case InteractiveObject.TYPE.HUGH_BUTTON:
                    {
                        currentlyLookingAt.reference.GetComponent<HughButton>().Clicked();
                        break;
                    }
                case InteractiveObject.TYPE.DAN_BUTTON:
                    {
                        currentlyLookingAt.reference.GetComponent<Button>().isClicked();
                        break;
                    }
                case InteractiveObject.TYPE.LEVER:
                    {
                        currentlyLookingAt.reference.GetComponent<LeverLogic>().WasClicked();
                        break;
                    }
                case InteractiveObject.TYPE.FINAL_BUTTON:
                    {
                        currentlyLookingAt.reference.GetComponent<FinalButton>().isClicked();
                        break;
                    }
                case InteractiveObject.TYPE.KEYPAD_BUTTON:
                    {
                        currentlyLookingAt.reference.GetComponent<ButtonKeypad>().isClicked();
                        break;
                    }


            }
        }
    }


    private void LetGoOfHeldItem()
    {
        if (currentlyHolding.myType == InteractiveObject.TYPE.PLUG)
        {
            switch (currentlyLookingAt.myType)
            {
                case InteractiveObject.TYPE.SOCKET:
                    {
                        if (currentlyLookingAt.reference.GetComponent<WireSocketLogic>().IsSocketBeingUsed())
                        {
                            currentlyHolding.reference.GetComponent<WirePlugLogic>().LetGoFromHand();
                            currentlyHolding.reference = null;
                            currentlyHolding.myType = InteractiveObject.TYPE.NONE;
                        }
                        else
                        {
                            currentlyLookingAt.reference.GetComponent<WireSocketLogic>().ConnectPlug(currentlyHolding.reference);
                            currentlyHolding.reference = null;
                            currentlyHolding.myType = InteractiveObject.TYPE.NONE;
                        }

                        break;
                    }
                default:
                    {
                        currentlyHolding.reference.GetComponent<WirePlugLogic>().LetGoFromHand();
                        currentlyHolding.reference = null;
                        currentlyHolding.myType = InteractiveObject.TYPE.NONE;
                        break;
                    }

            }
        }
      
    }

    public void ResetCharacterInteractivity()
    {
        LetGoOfHeldItem();
    }

}
