using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    //First person Look at variables

    //Mouse position onscreen
    Vector2 mouseLook;
    //Vertical smooth value
    Vector2 smoothV;
    //Look at sensitivity
    [SerializeField] float sensitivity = 5.0f;
    //Smoothing value
    float smoothing = 2.0f;
    //Player movement speed
    [SerializeField] float moveSpeed = 5.0f;

    //Head bob variables
    //The speed of the head bob
    [SerializeField] float bobSpeed = 4.8f;
    //The width of the head bob arc
    [SerializeField] float bobAmount = 0.1f;
    //Timer for use in the head bob
    float timer = Mathf.PI / 2;
    float transitionSpeed = 20.0f;
    Vector3 restPos;
    Vector3 camPos;

    //Starting player rotation
    public float InitialRotation = 0.0f;

    //Raycast stuff
    public LayerMask interactableMask;
    private RaycastHit interactable;

    void Start()
    {
        //Initialise the camera bob positions
        restPos = Camera.main.transform.localPosition;
        camPos = Camera.main.transform.localPosition;

        //Lock the cursor in the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;

        //Init mouse lookat rotation to determine starting rotation of player
        mouseLook.x = InitialRotation;
    }

    public GameObject GetInteractable()
    {
        if (interactable.transform.gameObject != null)
        {
            return interactable.transform.gameObject;
        }
        else
        {
            Debug.LogWarning("Invalid Interactable");
            return null;
        }
    }

    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out interactable, 20.0f, interactableMask))
        {
            Debug.Log("Looking at interactable object");
        }


        //DEBUG for getting mouse cursor back
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //turn on cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }
    //This function handles physics calculations every cycle such as player movement
    private void FixedUpdate()
    {
       
           //Apply a headbob to the camera if the player is moving 
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                timer += bobSpeed * Time.deltaTime;
                Vector3 newPos = new Vector3(Mathf.Cos(timer) * bobAmount, restPos.y + Mathf.Abs(Mathf.Sin(timer) * bobAmount), restPos.z);
                Camera.main.transform.localPosition = newPos;
            }
            else
            {
                timer = Mathf.PI / 2;
                Vector3 newPos = new Vector3(Mathf.Lerp(camPos.x, restPos.x, transitionSpeed * Time.deltaTime), Mathf.Lerp(camPos.y, restPos.y, transitionSpeed * Time.deltaTime), Mathf.Lerp(camPos.z, restPos.z, transitionSpeed * Time.deltaTime));
                Camera.main.transform.localPosition = newPos;
            }

            if (timer > Mathf.PI * 2)
            {
                timer = 0;
            }

            //Turn and move the player if applicable
            Turn();
            Move(-Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        }
    

    //This function handles the rotation of the camera based on the mouse position for a first person controller
    void Turn()
    {
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1.0f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1.0f / smoothing);

        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -65.0f, 65.0f);

        Camera.main.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        GetComponent<Rigidbody>().MoveRotation(Quaternion.AngleAxis(mouseLook.x, transform.up));
    }

    //This function handles the player movement foward/back, and left/right based on input
    void Move(float h, float v)
    {
        Vector3 movement = new Vector3(h, 0.0f, v);
        movement = Camera.main.transform.forward * (-movement.x) + Camera.main.transform.right * movement.z;
        movement.y = 0.0f;
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(transform.position + movement);
    }


}