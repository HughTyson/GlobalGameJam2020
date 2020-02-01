using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CryoScreenScript : MonoBehaviour
{
    [SerializeField] Material deadMat;
    [SerializeField] Material aliveMat;
    [SerializeField] GameObject ThisCryoSocket;
    [SerializeField] Text Text;
    [SerializeField] string DeadText;

    [SerializeField] string AliveText;

    bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ThisCryoSocket.GetComponent<WireSocketLogic>().IsColourMatched())
        {
            alive = false;
        }

        if (alive)
        {
            Text.text = AliveText;
            GetComponent<MeshRenderer>().material = aliveMat;
        }
        else
        {
            Text.text = DeadText;
            GetComponent<MeshRenderer>().material = deadMat;
        }
    }


    public void Reset()
    {
        alive = true;
    }
}
