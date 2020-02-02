using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltEndLogic : MonoBehaviour
{
    // Start is called before the first frame update

    public enum ALT_ENDING
    { 
        NONE,
    WON_KILLED_FEW,
    WON_PACISFIST,
    WON_KILLED_ALL
    
    }

    [SerializeField] List<GameObject> cryochambers;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ALT_ENDING GetEnding()
    {
        int killed = 0;
        for (int i = 0; i < cryochambers.Count; i++)
        {
            if (!cryochambers[i].GetComponent<CryoScript>().IsCryoUserAlive())
            {
                killed++;
            }
        }

        if (killed == 0)
        {
            return ALT_ENDING.WON_PACISFIST;
        }
        else if (killed == cryochambers.Count)
        {
            return ALT_ENDING.WON_KILLED_ALL;
        }
        else
        {
            return ALT_ENDING.WON_KILLED_FEW;
        }
    }
}
