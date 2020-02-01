using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HughButton : MonoBehaviour
{

    private bool opener = false;

    public Material default_mat;
    public Material mat_on = null;
    public Material mat_off = null;
    CharacterCtrl player;
    public GameObject door;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCtrl>();
        GetComponent<MeshRenderer>().sharedMaterial = mat_off;

        
    }

    // Update is called once per frame
    void Update()
    {
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
        //check if this is the correct button
        if (opener == true)
        {
                Debug.Log("clicked");
                door.SetActive(false);
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
}
