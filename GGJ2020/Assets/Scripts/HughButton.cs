using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HughButton : MonoBehaviour
{

    private bool opener = false;

    [SerializeField] float button_speed = 1f;

    public Material default_mat;
    public Material mat_on = null;
    public Material mat_off = null;
    public Material mat_its_here = null;
    CharacterCtrl player;
    public GameObject door;
    [SerializeField] GameObject socket;

    bool show_button = false;

    Vector3 offset;
    Vector3 basePos;

    bool clicked = false;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCtrl>();
        GetComponent<MeshRenderer>().sharedMaterial = mat_off;

        offset.y = transform.position.y - .1f;
        basePos = transform.position;

        socket.GetComponent<WireSocketLogic>().SetColour((WireGameScript.COLOUR_ENUM)Random.Range(0, 3));
    }

    private void Update()
    {
        if(clicked)
        {
            transform.position = Vector3.Lerp(transform.position, basePos, button_speed * Time.deltaTime);
        }

        if(clicked == true)
        {
            if(transform.position == basePos)
            {
                clicked = false;
            }
        }

        if(opener)
        {
           show_button = socket.GetComponent<WireSocketLogic>().IsColourMatched();
        }

        if(show_button && opener)
        {
            GetComponent<MeshRenderer>().sharedMaterial = mat_its_here;
        }
    }

    public void LookedAt()
    {
        //turn green
        GetComponent<MeshRenderer>().sharedMaterial = mat_on;
        //found
        if (opener == true)
        {
            
            Debug.Log("Found you");
        }
    }

    public void NotBeingLookedAt()
    {
        //turn button red
        GetComponent<MeshRenderer>().sharedMaterial = mat_off;
    }

    public void Clicked()
    {

        transform.position = new Vector3(transform.position.x, offset.y, transform.position.z);
        clicked = true;
        //check if this is the correct button
        if (opener == true)
        {
            door.GetComponent<DoorOpen>().OpenDoors();
        }
    }

    public bool GetOpener()
    {
        return opener;
    }

    public void setOpener(bool op)
    {
        opener = op;
    }

    public void resetButton()
    {
        clicked = false;
        show_button = false;
        GetComponent<MeshRenderer>().sharedMaterial = mat_off;

        if (socket.GetComponent<WireSocketLogic>().IsSocketBeingUsed())
        {
            socket.GetComponent<WireSocketLogic>().GetPlugObject().GetComponent<WirePlugLogic>().UnplugFromSocket();
        }
        
    }
}
