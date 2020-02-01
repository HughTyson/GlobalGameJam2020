using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRoomScript : MonoBehaviour
{

    List<GameObject> CryoChambers;
    GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetEngineRoom()
    {

        for (int i = 0; i < CryoChambers.Count; i++)
        {
            CryoChambers[i].GetComponent<CryoScript>().Reset();
        }

        

    }
}
