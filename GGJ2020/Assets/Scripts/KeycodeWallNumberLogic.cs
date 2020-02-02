using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class KeycodeWallNumberLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SetNumber(int number)
    {
        GetComponent<TextMeshPro>().text = number.ToString();
    }
    // Update is called once per frame

}
