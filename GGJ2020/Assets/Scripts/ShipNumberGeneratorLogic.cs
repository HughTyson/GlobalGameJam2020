using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipNumberGeneratorLogic : MonoBehaviour
{
    [SerializeField] List<GameObject> NumberObjects;


    List<int> Numbers = new List<int>();

    [SerializeField] GameObject Keypad;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NumberObjects.Count; i++)
        {
            Numbers.Add(Random.Range(0, 9));
            NumberObjects[i].GetComponent<KeycodeWallNumberLogic>().SetNumber(Numbers[i]);
        }
        Keypad.GetComponent<Keypad>().setKeycode(Numbers[0], Numbers[1], Numbers[2], Numbers[3]);
    }


}
