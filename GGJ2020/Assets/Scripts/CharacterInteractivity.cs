using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractivity : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] Camera theCamera;

    [SerializeField] float viewingDistance;


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
            LEVER
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
        if (Physics.Raycast(ray, out raycastObjectHit, viewingDistance, Physics.AllLayers ,QueryTriggerInteraction.Collide))
        {
            if (raycastObjectHit.transform.gameObject.GetComponent<CustomTagSystem>() != null)
            {
                if (raycastObjectHit.transform.gameObject != currentlyLookingAt.reference) // looked at new thing
                {
                    LookedAwayFromCurrent();
                    SetupNewLookAt();
                    LookedAtNewCurrent();
                }
            }

        }
        else
        {
            LookedAwayFromCurrent();
            NoNewLookAt();
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

                    break;
                }
            case InteractiveObject.TYPE.HUGH_BUTTON:
                {

                    break;
                }
            case InteractiveObject.TYPE.DAN_BUTTON:
                {
                    currentlyLookingAt.reference.GetComponent<Button>().lookedAt();
                    break;
                }
            case InteractiveObject.TYPE.LEVER:
                {

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

                        break;
                    }
                case InteractiveObject.TYPE.HUGH_BUTTON:
                    {

                        break;
                    }
                case InteractiveObject.TYPE.DAN_BUTTON:
                    {
                        currentlyLookingAt.reference.GetComponent<Button>().notLookedAt();
                        break;
                    }
                case InteractiveObject.TYPE.LEVER:
                    {

                        break;
                    }



            }
        }

    }
}
